using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace RB10.Bot.WebApi.Controllers
{
    public class ToysrusController : ApiController
    {
        public enum Status
        {
            Success,
            Warning,
            Fail
        }
        public class SearchResult
        {
            public string JanCode { get; set; }
            public string ProductName { get; set; } = "-";
            public string OnlineStock { get; set; } = "-";
            public int StoreStockCount { get; set; } = -1;
            public int StoreLessStockCount { get; set; } = -1;

            public string Message { get; set; } = "";
            public Status Status { get; set; }
        }

        private System.Text.RegularExpressions.Regex _exist = new System.Text.RegularExpressions.Regex("<div class=\"status\">在庫あり</div>");
        private System.Text.RegularExpressions.Regex _lessExist = new System.Text.RegularExpressions.Regex("<div class=\"status\">在庫わずか</div>");

        public ToysrusController() : base()
        {
        }

        /// <summary>
        /// GETメソッド
        /// </summary>
        /// <param name="janCode"></param>
        /// <returns></returns>
        public SearchResult Get(string janCode)
        {
            return Post(janCode);
        }

        /// <summary>
        /// POSTメソッド
        /// </summary>
        /// <param name="janCode"></param>
        /// <returns></returns>
        public SearchResult Post(string janCode)
        {
            var result = new SearchResult();
            result.JanCode = janCode;

            try
            {
                var url = $"https://www.toysrus.co.jp/search/?q={janCode}";
                var req = (HttpWebRequest)WebRequest.Create(url);

                // html取得文字列
                string html;

                using (var res = (HttpWebResponse)req.GetResponse())
                using (var resSt = res.GetResponseStream())
                using (var sr = new StreamReader(resSt, Encoding.UTF8))
                {
                    html = sr.ReadToEnd();
                }

                var parser = new HtmlParser();
                var doc = parser.Parse(html);

                var productName = doc.GetElementById("DISP_GOODS_NM");
                if (productName == null)
                {
                    throw new ApplicationException("商品がありません。");
                }
                else
                {
                    result.ProductName = productName.InnerHtml;
                }

                var stock = doc.GetElementById("isStock");
                if (stock == null || (stock as AngleSharp.Dom.Html.IHtmlSpanElement).IsHidden)
                {
                    result.OnlineStock = "不明";
                    throw new ApplicationException("在庫状況が確認できません。");
                }
                else
                {
                    var stockStatus = stock.Children[0].Children.Where(x => (x as AngleSharp.Dom.Html.IHtmlSpanElement).IsHidden == false);
                    if (stockStatus.Count() == 0)
                    {
                        result.OnlineStock = "不明";
                        throw new ApplicationException("在庫状況が確認できません。");
                    }
                    else
                    {
                        var f = stockStatus.First().InnerHtml;
                        result.OnlineStock = f;
                    }
                }

                var sku = doc.GetElementsByName("MAIN_SKU");
                if (sku == null)
                {
                    throw new ApplicationException("トイザらスの商品コードが取得できなかったため、店舗在庫の取得ができません。");
                }
                var storeUrl = $"https://www.toysrus.co.jp/disp/CSfGoodsPageRealShop_001.jsp?sku={(sku[0] as AngleSharp.Dom.Html.IHtmlInputElement).Value}&shopCd=";

                req = (HttpWebRequest)WebRequest.Create(storeUrl);
                using (var res = (HttpWebResponse)req.GetResponse())
                using (var resSt = res.GetResponseStream())
                using (var sr = new StreamReader(resSt, Encoding.UTF8))
                {
                    html = sr.ReadToEnd();
                }
                doc = parser.Parse(html);

                var source = doc.Source.Text;

                int existCount = _exist.Matches(source).Count;
                int lessExistCount = _lessExist.Matches(source).Count;
                result.StoreStockCount = existCount;
                result.StoreLessStockCount = lessExistCount;

                result.Status = Status.Success;
            }
            catch (ApplicationException ex)
            {
                result.Message = ex.Message;
                result.Status = Status.Warning;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Status = Status.Fail;
            }

            return result;
        }
    }
}