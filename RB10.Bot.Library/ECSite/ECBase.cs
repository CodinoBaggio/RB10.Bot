using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Library.ECSite
{
    public abstract class ECBase
    {
        public enum WebDriverType
        {
            Chrome,
            IE,
            Firefox,
            Safari
        }

        public WebDriverType WebDriver { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string ItemUrl { get; set; }
        public decimal UpperLimitPrice { get; set; }
        public bool FixedOrder { get; set; } = false;

        public abstract void Run();

        public static OpenQA.Selenium.Remote.RemoteWebDriver GetWebDriver(WebDriverType webDriver)
        {
            switch (webDriver)
            {
                case WebDriverType.Chrome:
                    return new OpenQA.Selenium.Chrome.ChromeDriver();
                case WebDriverType.IE:
                    throw new NotImplementedException();
                case WebDriverType.Firefox:
                    throw new NotImplementedException();
                case WebDriverType.Safari:
                    throw new NotImplementedException();
                default:
                    throw new ApplicationException();
            }
        }
    }
}
