using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RB10.Bot.Amazon
{
    public partial class ExecForm : Form
    {
        private bool _isPause;

        public ExecForm()
        {
            InitializeComponent();
        }

        private void ExecForm_Load(object sender, EventArgs e)
        {
            UrlTextBox.Text = Properties.Settings.Default.ItemUrl;
            ShopNameTextBox.Text = Properties.Settings.Default.ShopName;
            UpperLimitPriceTextBox.Text = Properties.Settings.Default.UpperLimitPrice.ToString();
            LoginIDTextBox.Text = Properties.Settings.Default.LoginID;
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenQA.Selenium.Remote.RemoteWebDriver webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
                webDriver.Url = UrlTextBox.Text;

                while (true)
                {
                    while (true)
                    {
                        try
                        {
                            // 販売元確認
                            var shop = webDriver.FindElementById("merchant-info").Text;
                            shop =
                                shop.Split(new string[1] { "が販売" }, StringSplitOptions.None)[0]
                                .Split(new string[1] { "この商品は、" }, StringSplitOptions.None)[1];

                            //if (ShopNameTextBox.Text != shop)
                            //{
                            //    throw new Exception("not Amazon.");
                            //}

                            // カートに入れる
                            webDriver.FindElementById("add-to-cart-button").Click();
                            break;
                        }
                        catch (Exception)
                        {
                            System.Threading.Thread.Sleep(30000);
                            webDriver.Url = UrlTextBox.Text;
                        }
                    }

                    // 購入手続き
                    webDriver.Url = "https://www.amazon.co.jp/gp/cart/view.html/ref=nav_cart";
                    webDriver.FindElementByName("proceedToCheckout").Click();

                    // ログイン
                    try
                    {
                        webDriver.FindElementById("ap_email").SendKeys(LoginIDTextBox.Text);
                        webDriver.FindElementById("ap_password").SendKeys(PasswordTextBox.Text);
                        webDriver.FindElementById("signInSubmit").Click();
                    }
                    catch (Exception)
                    {
                    }

                    // 値段の確認
                    var p = webDriver.FindElementByCssSelector("td.grand-total-price").Text;
                    if (Convert.ToInt32(p.Split(' ')[1].Replace(",", "")) > Convert.ToInt32(UpperLimitPriceTextBox.Text))
                    {
                        continue;
                    }

                    //// 注文の確定
                    //webDriver.FindElementByName("placeYourOrder1").Click();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                _isPause = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
