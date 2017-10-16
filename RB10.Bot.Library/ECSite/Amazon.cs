using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Library.ECSite
{
    public class Amazon : ECBase
    {
        private const string EC_SITE = "Amazon";

        public class AmazonParameters : ExecParameters
        {
            public string PurchaseShopName { get; set; }
        }

        public new AmazonParameters Parameters { get; set; }
        private System.Text.RegularExpressions.Regex _reg = new System.Text.RegularExpressions.Regex(@"この商品は、(?<shop>.*)が販売");

        public Amazon(AmazonParameters parameters) : base(parameters)
        {
            Parameters = parameters;
        }

        public override void Run()
        {
            var webDriver = GetWebDriver(Parameters.WebDriver);

            try
            {
                webDriver.Url = Parameters.ItemUrl;

                while (true)
                {
                    if (CancelToken.IsCancellationRequested) return;

                    while (true)
                    {
                        if (CancelToken.IsCancellationRequested) return;

                        // 販売元確認
                        var merchant = webDriver.FindElementById("merchant-info").Text;
                        var match = _reg.Match(merchant);
                        string shopName = match.Success ? match.Groups["shop"].Value : "";
                        if (Parameters.PurchaseShopName.ToLower() != shopName.ToLower())
                        {
                            ReportStatus(EC_SITE, $"商品が指定したショップのものではありません。ショップ名：{shopName}", ReportState.Warning);
                            System.Threading.Thread.Sleep(10000);
                            webDriver.Url = Parameters.ItemUrl;
                        }
                        else
                        {
                            ReportStatus(EC_SITE, $"指定したショップの商品が見つかりました。ショップ名：{Parameters.PurchaseShopName}", ReportState.Information);
                            break;
                        }
                    }

                    // カートに入れる
                    webDriver.FindElementById("add-to-cart-button").Click();
                    ReportStatus(EC_SITE, $"商品をカートに入れました。", ReportState.Information);

                    // 購入手続き
                    webDriver.Url = "https://www.amazon.co.jp/gp/cart/view.html/ref=nav_cart";
                    webDriver.FindElementByName("proceedToCheckout").Click();
                    ReportStatus(EC_SITE, $"購入手続きに進みました。", ReportState.Information);

                    // ログイン
                    try
                    {
                        webDriver.FindElementById("ap_email").SendKeys(Parameters.LoginID);
                        webDriver.FindElementById("ap_password").SendKeys(Parameters.Password);
                        webDriver.FindElementById("signInSubmit").Click();
                        ReportStatus(EC_SITE, $"ログインを行いました。", ReportState.Information);
                    }
                    catch (Exception)
                    {
                    }

                    // 値段の確認
                    var p = webDriver.FindElementByCssSelector("td.grand-total-price").Text;
                    if (Convert.ToInt32(p.Split(' ')[1].Replace(",", "")) > Convert.ToInt32(Parameters.UpperLimitPrice))
                    {
                        ReportStatus(EC_SITE, $"商品の値段が上限を超えているので、再度商品検索を行います。", ReportState.Information);
                        continue;
                    }

                    if (Parameters.FixedOrder)
                    {
                        // 注文の確定
                        webDriver.FindElementByName("placeYourOrder1").Click();
                        ReportStatus(EC_SITE, $"注文の確定を行いました。", ReportState.Information);
                    }

                    if (Parameters.IsSendMail)
                    {
                        Library.Mail.Gmail.Send(Parameters.ToMailAddress, Parameters.MailPassword);
                    }

                    break;
                }
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
