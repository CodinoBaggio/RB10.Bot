using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using System.IO;
using System.Text;
using AngleSharp.Parser.Html;
using System.Configuration;
using System.Linq;
using System.Net.Http;

namespace RB10.Bot.Functions.Toysrus
{
    public static class Crawler
    {
        [FunctionName("Crawler")]
        public static async void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"{DateTime.Now}：スタート");

            try
            {
                // html取得文字列
                string html = GetHtml($"https://www.toysrus.co.jp/search/?q={ConfigurationManager.AppSettings["TargetJanCode"]}");
                var parser = new HtmlParser();
                var doc = parser.Parse(html);

                var productName = doc.GetElementById("DISP_GOODS_NM");
                if (productName == null) return;

                bool hit = false;
                var isLotManegeYes = doc.GetElementById("isLotManegeYes") as AngleSharp.Dom.Html.IHtmlSpanElement;
                if (isLotManegeYes == null || isLotManegeYes.IsHidden)
                {
                    var stock = doc.GetElementById("isStock") as AngleSharp.Dom.Html.IHtmlSpanElement;
                    if (stock != null && !stock.IsHidden)
                    {
                        var stockStatus = stock.Children[0].Children.Where(x => (x as AngleSharp.Dom.Html.IHtmlSpanElement).IsHidden == false);
                        if (0 < stockStatus.Count())
                        {
                            var f = stockStatus.First().InnerHtml;
                            if (f == "在庫あり") hit = true;
                        }
                    }
                }
                else
                {
                    var isLot_a = doc.GetElementById("isLot_a") as AngleSharp.Dom.Html.IHtmlLabelElement;
                    if (!isLot_a.IsHidden) hit = true;
                    var isLot_b = doc.GetElementById("isLot_b") as AngleSharp.Dom.Html.IHtmlLabelElement;
                    if (!isLot_b.IsHidden) hit = true;
                }

                if (hit)
                {
                    using (var client = new HttpClient())
                    {
                        // リクエストデータを作成
                        // ※HttpClientで[application/json]をHTTPヘッダに追加するときは下記のコーディングじゃないとエラーになる
                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://rb10-bot")
                        {
                            Content = new StringContent(reqData, Encoding.UTF8, "application/json")
                        };

                        //　認証ヘッダーを追加
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {channelAccessToken}");

                        // 非同期でPOST
                        var res = await client.SendAsync(request);

                        return req.CreateResponse(res.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Verbose($"{DateTime.Now}：{ex.ToString()}");
            }
            finally
            {
                log.Info($"{DateTime.Now}：エンド");
            }
        }

        private static string GetHtml(string url)
        {
            HttpWebRequest req = null;

            try
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 100000;
                req.UserAgent = "ToysrusCrawler (+codino.baggio10@gmail.com)";

                // html取得文字列
                string html = "";

                using (var res = (HttpWebResponse)req.GetResponse())
                using (var resSt = res.GetResponseStream())
                using (var sr = new StreamReader(resSt, Encoding.UTF8))
                {
                    html = sr.ReadToEnd();
                }

                return html;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (req != null) req.Abort();
            }
        }
    }
}
