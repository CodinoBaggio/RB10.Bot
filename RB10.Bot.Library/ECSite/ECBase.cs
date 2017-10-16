using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public class ExecParameters
        {
            public WebDriverType WebDriver { get; set; }
            public string LoginID { get; set; }
            public string Password { get; set; }
            public string ItemUrl { get; set; }
            public decimal UpperLimitPrice { get; set; }
            public bool FixedOrder { get; set; } = false;
            public bool IsSendMail { get; set; }
            public string ToMailAddress { get; set; }
            public string MailPassword { get; set; }
        }

        #region 状態通知イベント

        public enum ReportState
        {
            Information,
            Warning,
            Error,
            Exception
        }

        public class ExecutingStateEventArgs : EventArgs
        {
            public string EcSite { get; set; }
            public string Message { get; set; }
            public ReportState ReportState { get; set; }
        }

        public delegate void ExecutingStateEventHandler(object sender, ExecutingStateEventArgs e);
        public event ExecutingStateEventHandler ExecutingStateChanged;

        #endregion

        public ExecParameters Parameters { get; set; }
        private CancellationTokenSource _tokenSource;
        public CancellationToken CancelToken { get; private set; }

        public ECBase(ExecParameters parameters)
        {
            Parameters = parameters;
        }

        public void Start()
        {
            _tokenSource = new CancellationTokenSource();
            CancelToken = _tokenSource.Token;

            Task.Run(() => Run(), CancelToken);           
        }

        public abstract void Run();

        public void Stop()
        {
            if (_tokenSource != null) _tokenSource.Cancel();
        }

        protected OpenQA.Selenium.Remote.RemoteWebDriver GetWebDriver(WebDriverType webDriver)
        {
            switch (webDriver)
            {
                case WebDriverType.Chrome:
                    var driverService = OpenQA.Selenium.Chrome.ChromeDriverService.CreateDefaultService();
                    driverService.HideCommandPromptWindow = true;
                    var options = new OpenQA.Selenium.Chrome.ChromeOptions();
                    options.AddArgument("--headless");
                    //options.AddArgument("--window-size=100,100");
                    return new OpenQA.Selenium.Chrome.ChromeDriver(driverService, options);
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

        protected virtual void OnExecutingStateChanged(ExecutingStateEventArgs e)
        {
            if (ExecutingStateChanged != null)
                ExecutingStateChanged.Invoke(this, e);
        }

        protected void ReportStatus(string ecSite, string message, ReportState reportState)
        {
            var eventArgs = new ExecutingStateEventArgs()
            {
                EcSite = ecSite,
                Message = message,
                ReportState = reportState
            };
            OnExecutingStateChanged(eventArgs);
        }
    }
}
