using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Core.Crawler
{
    public class Toysrus
    {
        public class Result
        {
            public string JanCode { get; set; }
            public string ProductName { get; set; } = "-";
            public bool Exist { get; set; }
            public string TargetUrl { get; set; } = "";
        }

        public virtual Result Run(string janCode, bool useProxy = false)
        {
            var url = $"https://www.toysrus.co.jp/search/?q={janCode}";

            Result result = new Result
            {
                JanCode = janCode,
                TargetUrl = url
            };

            // html取得文字列
            string html = Utils.GetHtml(url, useProxy);
            var parser = new HtmlParser();
            var doc = parser.Parse(html);

            var productName = doc.GetElementById("DISP_GOODS_NM");
            if (productName == null)
            {
                return result;
            }
            else
            {
                result.ProductName = productName.InnerHtml;
            }

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
                        if (f == "在庫あり") result.Exist = true;
                    }
                }
            }
            else
            {
                var isLot_a = doc.GetElementById("isLot_a") as AngleSharp.Dom.Html.IHtmlLabelElement;
                if (!isLot_a.IsHidden) result.Exist = true;
                var isLot_b = doc.GetElementById("isLot_b") as AngleSharp.Dom.Html.IHtmlLabelElement;
                if (!isLot_b.IsHidden) result.Exist = true;
            }

            return result;
        }
    }
}
