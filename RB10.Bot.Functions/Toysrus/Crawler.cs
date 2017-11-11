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
using Line.Messaging;

namespace RB10.Bot.Functions.Toysrus
{
    public static class Crawler
    {
        [FunctionName("Crawler")]
        public static void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            //log.Info($"{DateTime.Now}：スタート");

            try
            {
                // html取得文字列
                var janCode = ConfigurationManager.AppSettings["TargetGoods"].Split(',')[0];
                var goodsName = ConfigurationManager.AppSettings["TargetGoods"].Split(',')[1];
                string html = GetHtml($"https://www.toysrus.co.jp/search/?q={janCode}");
                var parser = new HtmlParser();
                var doc = parser.Parse(html);

                var productName = doc.GetElementById("DISP_GOODS_NM");
                if (productName == null)
                {
                    log.Info($"{DateTime.Now}：商品なし");
                    return;
                }

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
                    var message = $"【{goodsName}】が見つかりました。\n下記URLから購入を行ってください。\n{html}";
                    LineMessagingClient lineMessagingClient = new LineMessagingClient(ConfigurationManager.AppSettings["AccessToken"]);
                    lineMessagingClient.PushMessageAsync(ConfigurationManager.AppSettings["SendUserID"], message);
                }
            }
            catch (Exception ex)
            {
                log.Verbose($"{DateTime.Now}：{ex.ToString()}");
            }
            finally
            {
                //log.Info($"{DateTime.Now}：エンド");
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
