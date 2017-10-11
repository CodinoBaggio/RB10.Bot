using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Library.ECSite
{
    public class Amazon : ECBase
    {
        public string ShopName { get; set; }
        private System.Text.RegularExpressions.Regex _reg = new System.Text.RegularExpressions.Regex(@"この商品は、(?<shop>.*)が販売");

        public override void Run()
        {
            var webDriver = GetWebDriver(WebDriver);
            webDriver.Url = ItemUrl;

            while (true)
            {
                while (true)
                {
                    try
                    {
                        // 販売元確認
                        var merchant = webDriver.FindElementById("merchant-info").Text;
                        var match = _reg.Match(merchant);
                        string shopName = match.Success ? match.Groups["shop"].Value : "";

                        if (ShopName != shopName)
                        {
                            throw new Exception($"not {ShopName}.");
                        }

                        // カートに入れる
                        webDriver.FindElementById("add-to-cart-button").Click();
                        break;
                    }
                    catch (Exception)
                    {
                        System.Threading.Thread.Sleep(30000);
                        webDriver.Url = ItemUrl;
                    }
                }

                // 購入手続き
                webDriver.Url = "https://www.amazon.co.jp/gp/cart/view.html/ref=nav_cart";
                webDriver.FindElementByName("proceedToCheckout").Click();

                // ログイン
                try
                {
                    webDriver.FindElementById("ap_email").SendKeys(LoginID);
                    webDriver.FindElementById("ap_password").SendKeys(Password);
                    webDriver.FindElementById("signInSubmit").Click();
                }
                catch (Exception)
                {
                }

                // 値段の確認
                var p = webDriver.FindElementByCssSelector("td.grand-total-price").Text;
                if (Convert.ToInt32(p.Split(' ')[1].Replace(",", "")) > Convert.ToInt32(UpperLimitPrice))
                {
                    continue;
                }

                if (FixedOrder)
                {
                    // 注文の確定
                    webDriver.FindElementByName("placeYourOrder1").Click();
                }
                
                break;
            }
        }
    }
}
