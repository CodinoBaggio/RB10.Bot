using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Library.ECSite
{
    public class Toysrus : ECBase
    {
        private const string EC_SITE = "トイザらス";

        private class SearchResul
        {
            public string JanCode { get; set; }
            public string ProductName { get; set; }
            public string OnlineStock { get; set; } = "在庫なし";
            public string StoreStock { get; set; } = "在庫なし";
            public int StoreStockCount { get; set; }
            public string StoreLessStock { get; set; } = "在庫なし";
            public int StoreLessStockCount { get; set; }
        }

        public class ToysrusParameters : ExecParameters
        {
            public string JanCodeFileName { get; set; }
            public string OutputFilePath { get; set; }
        }

        private ToysrusParameters _parameters { get; set; }
        private System.Text.RegularExpressions.Regex _regStoreStock = new System.Text.RegularExpressions.Regex(@"在庫のある店舗：(?<shop>.*)店舗");
        private System.Text.RegularExpressions.Regex _regStoreLessStock = new System.Text.RegularExpressions.Regex(@"この商品は、(?<shop>.*)が販売");

        public Toysrus(ToysrusParameters parameters) : base(parameters)
        {
            _parameters = parameters;
        }

        public override void Run()
        {
            var webDriver = GetWebDriver(Parameters.WebDriver);
            webDriver.Url = Parameters.ItemUrl;

            try
            {
                // ファイル読み込み
                List<string> lines = System.IO.File.ReadLines(_parameters.JanCodeFileName, Encoding.GetEncoding("shift-jis")).ToList();

                // 情報取得
                List<SearchResul> results = new List<SearchResul>();
                foreach (var line in lines)
                {
                    if (CancelToken.IsCancellationRequested) return;

                    webDriver.FindElementById("q").SendKeys(line);
                    webDriver.FindElementById("UPPER_SEARCH").Click();
                    var productName = webDriver.FindElementById("DISP_GOODS_NM").Text;
                    var stock = webDriver.FindElementById("isStock").Text;

                    var aaa = webDriver.FindElementById("pref-list");
                    aaa.SendKeys("北海道");

                    var bbb = webDriver.FindElementById("StockSearchButton");
                    bbb.Click();

                    var current = webDriver.CurrentWindowHandle;
                    var last = webDriver.WindowHandles.Last();
                    webDriver.SwitchTo().Window(last);

                    var vvv = webDriver.FindElementByClassName("list-up");

                    





                    var result = new SearchResul();
                    result.JanCode = line;
                    result.ProductName = productName;
                    result.OnlineStock = stock;

                    try
                    {
                        var storeStock = webDriver.FindElementById("hogehoge");
                        if (storeStock != null)
                        {

                        }



                    }
                    catch (Exception)
                    {
                    }
                }

                // ファイル出力
                StringBuilder sb = new StringBuilder();
                foreach (var result in results)
                {
                    sb.AppendLine($"{result.JanCode},{result.ProductName},{result.OnlineStock},{result.StoreStock},{result.StoreStockCount},{result.StoreLessStock},{result.StoreLessStockCount}");
                }
                System.IO.File.WriteAllText(_parameters.OutputFilePath, sb.ToString());

                //while (true)
                //{
                //    if (CancelToken.IsCancellationRequested) return;

                //    while (true)
                //    {
                //        if (CancelToken.IsCancellationRequested) return;

                //        // 販売元確認
                //        var merchant = webDriver.FindElementById("merchant-info").Text;
                //        var match = _reg.Match(merchant);
                //        string shopName = match.Success ? match.Groups["shop"].Value : "";
                //        if (Parameters.PurchaseShopName.ToLower() != shopName.ToLower())
                //        {
                //            ReportStatus(EC_SITE, $"商品が指定したショップのものではありません。ショップ名：{shopName}", ReportState.Warning);
                //            System.Threading.Thread.Sleep(10000);
                //            webDriver.Url = Parameters.ItemUrl;
                //        }
                //        else
                //        {
                //            ReportStatus(EC_SITE, $"指定したショップの商品が見つかりました。ショップ名：{Parameters.PurchaseShopName}", ReportState.Information);
                //            break;
                //        }
                //    }

                //    // カートに入れる
                //    webDriver.FindElementById("add-to-cart-button").Click();
                //    ReportStatus(EC_SITE, $"商品をカートに入れました。", ReportState.Information);

                //    // 購入手続き
                //    webDriver.Url = "https://www.amazon.co.jp/gp/cart/view.html/ref=nav_cart";
                //    webDriver.FindElementByName("proceedToCheckout").Click();
                //    ReportStatus(EC_SITE, $"購入手続きに進みました。", ReportState.Information);

                //    // ログイン
                //    try
                //    {
                //        webDriver.FindElementById("ap_email").SendKeys(Parameters.LoginID);
                //        webDriver.FindElementById("ap_password").SendKeys(Parameters.Password);
                //        webDriver.FindElementById("signInSubmit").Click();
                //        ReportStatus(EC_SITE, $"ログインを行いました。", ReportState.Information);
                //    }
                //    catch (Exception)
                //    {
                //    }

                //    // 値段の確認
                //    var p = webDriver.FindElementByCssSelector("td.grand-total-price").Text;
                //    if (Convert.ToInt32(p.Split(' ')[1].Replace(",", "")) > Convert.ToInt32(Parameters.UpperLimitPrice))
                //    {
                //        ReportStatus(EC_SITE, $"商品の値段が上限を超えているので、再度商品検索を行います。", ReportState.Information);
                //        continue;
                //    }

                //    if (Parameters.FixedOrder)
                //    {
                //        // 注文の確定
                //        webDriver.FindElementByName("placeYourOrder1").Click();
                //        ReportStatus(EC_SITE, $"注文の確定を行いました。", ReportState.Information);
                //    }

                //    if (Parameters.IsSendMail)
                //    {
                //        Library.Mail.Gmail.Send(Parameters.ToMailAddress, Parameters.MailPassword);
                //    }

                //    break;
                //}
            }
            catch (Exception ex)
            {
                ReportStatus(EC_SITE, ex.ToString(), ReportState.Exception);
            }
            finally
            {
                webDriver.Quit();
            }
        }
    }
}
