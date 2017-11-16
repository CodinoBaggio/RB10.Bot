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
            //log.Info($"{DateTime.Now}�F�X�^�[�g");

            try
            {
                // ���i����
                GetGoods(ConfigurationManager.AppSettings["TargetGoods"], 0, out var janCode, out var goodsName);
                if (janCode == "") return;
                Core.Crawler.Toysrus crawler = new Core.Crawler.Toysrus();
                Core.Crawler.Toysrus.Result result = crawler.Run(janCode);

                if (result.Exist)
                {
                    var message = $"�y{goodsName}�z��������܂����B\n���LURL����w�����s���Ă��������B\n{result.TargetUrl}";
                    var messaging = new Library.LINE.Messaging(ConfigurationManager.AppSettings["AccessToken"]);
                    messaging.Push(ConfigurationManager.AppSettings["SendUserID"], message);
                }
            }
            catch (Exception ex)
            {
                log.Verbose($"{DateTime.Now}�F{ex.ToString()}");
            }
            finally
            {
                //log.Info($"{DateTime.Now}�F�G���h");
            }
        }

        [FunctionName("ToysrusCrawlerUsingProxy")]
        public static void RunUsingProxy([TimerTrigger("0 * * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            //log.Info($"{DateTime.Now}�F�X�^�[�g");

            try
            {
                // ���i����
                GetGoods(ConfigurationManager.AppSettings["TargetGoods"], 1, out var janCode, out var goodsName);
                if (janCode == "") return;
                Core.Crawler.Toysrus crawler = new Core.Crawler.Toysrus();
                Core.Crawler.Toysrus.Result result = crawler.Run(janCode, true);

                if (result.Exist)
                {
                    var message = $"�y{goodsName}�z��������܂����B\n���LURL����w�����s���Ă��������B\n{result.TargetUrl}";
                    var messaging = new Library.LINE.Messaging(ConfigurationManager.AppSettings["AccessToken"]);
                    messaging.Push(ConfigurationManager.AppSettings["SendUserID"], message);
                }
            }
            catch (Exception ex)
            {
                log.Verbose($"{DateTime.Now}�F{ex.ToString()}");
            }
            finally
            {
                //log.Info($"{DateTime.Now}�F�G���h");
            }
        }

        private static void GetGoods(string config, int index, out string jancode, out string goodsName)
        {
            var goodsArr = config.Split('|');
            if(index + 1 <= goodsArr.Length)
            {
                jancode = goodsArr[index].Split(',')[0];
                goodsName = goodsArr[index].Split(',')[1];
            }
            else
            {
                jancode = "";
                goodsName = "";
            }
        }
    }
}
