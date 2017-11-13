using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Net;
using System.IO;
using System.Text;
using System.Configuration;
using System.Linq;
using System.Net.Http;

namespace RB10.Bot.Azure.Functions.Crawler
{
    public static class ToysrusCrawler
    {
        [FunctionName("ToysrusCrawler")]
        public static void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            //log.Info($"{DateTime.Now}：スタート");

            try
            {
                // 商品検索
                var janCode = ConfigurationManager.AppSettings["TargetGoods"].Split(',')[0];
                var goodsName = ConfigurationManager.AppSettings["TargetGoods"].Split(',')[1];
                Core.Crawler.Toysrus crawler = new Core.Crawler.Toysrus();
                Core.Crawler.Toysrus.Result result = crawler.Run(janCode);

                if (result.Exist)
                {
                    var message = $"【{goodsName}】が見つかりました。\n下記URLから購入を行ってください。\n{result.TargetUrl}";
                    var messaging = new Library.LINE.Messaging(ConfigurationManager.AppSettings["AccessToken"]);
                    messaging.Push(ConfigurationManager.AppSettings["SendUserID"], message);
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
    }
}
