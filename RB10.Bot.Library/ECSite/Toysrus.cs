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
            public string ProductName { get; set; } = "";
            public string OnlineStock { get; set; } = "在庫なし";
            public int StoreStockCount { get; set; } = -1;
            public int StoreLessStockCount { get; set; } = -1;
        }

        public class ToysrusParameters : ExecParameters
        {
            public string JanCodeFileName { get; set; }
            public string OutputFilePath { get; set; }
        }

        private ToysrusParameters _parameters { get; set; }
        private System.Text.RegularExpressions.Regex _regStoreStock = new System.Text.RegularExpressions.Regex(@"在庫のある店舗：(?<shop>.*)店舗");
        private System.Text.RegularExpressions.Regex _exist = new System.Text.RegularExpressions.Regex("<div class=\"status\">在庫あり</div>");
        private System.Text.RegularExpressions.Regex _lessExist = new System.Text.RegularExpressions.Regex("<div class=\"status\">在庫わずか</div>");

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

                    var result = new SearchResul();
                    results.Add(result);
                    result.JanCode = line;

                    try
                    {
                        // 検索実行
                        webDriver.FindElementById("q").SendKeys(line);
                        webDriver.FindElementById("UPPER_SEARCH").Click();

                        var productName = webDriver.FindElementsById("DISP_GOODS_NM");
                        if (productName.Count == 0)
                        {
                            result.OnlineStock = "商品登録なし";
                            continue;
                        }
                        else
                        {
                            result.ProductName = productName.First().Text;
                        }
                        var stock = webDriver.FindElementsById("isStock");
                        if (0 < stock.Count)
                        {
                            result.OnlineStock = stock.First().Text;
                        }
                        else
                        {
                            result.OnlineStock = "-";
                        }

                        var currentHandle = webDriver.CurrentWindowHandle;

                        bool switchSuccess = false;
                        string lastHandle = "";

                        try
                        {
                            // 店舗在庫取得
                            webDriver.FindElementById("StockSearchButton").Click();

                            lastHandle = webDriver.WindowHandles.Last();
                            webDriver.SwitchTo().Window(lastHandle);
                            switchSuccess = true;

                            int existCount = _exist.Matches(webDriver.PageSource).Count;
                            int lessExistCount = _lessExist.Matches(webDriver.PageSource).Count;
                            result.StoreStockCount = existCount;
                            result.StoreLessStockCount = lessExistCount;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        finally
                        {
                            if (switchSuccess) webDriver.Close();
                            webDriver.SwitchTo().Window(currentHandle);
                        }
                    }
                    catch (Exception ex)
                    {
                        ReportStatus(EC_SITE, ex.ToString(), ReportState.Warning);
                    }
                }

                // ファイル出力
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("JANコード,商品名,オンライン在庫,店舗在庫あり数,店舗在庫わずか数");
                foreach (var result in results)
                {
                    sb.AppendLine($"{result.JanCode},{result.ProductName},{result.OnlineStock},{result.StoreStockCount},{result.StoreLessStockCount}");
                }
                if(0 < results.Count) System.IO.File.WriteAllText(_parameters.OutputFilePath, sb.ToString());
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
