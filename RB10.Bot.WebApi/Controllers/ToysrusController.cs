using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace RB10.Bot.WebApi.Controllers
{
    public class ToysrusController : ApiController
    {
        public enum ResultStatus
        {
            Success,
            Error
        }
        public class Result : Core.Crawler.Toysrus.Result
        {
            public ResultStatus ResultStatus { get; set; }
        }

        public ToysrusController() : base()
        {
        }

        /// <summary>
        /// GETメソッド
        /// </summary>
        /// <param name="janCode"></param>
        /// <returns></returns>
        public Result Get(string janCode)
        {
            return Post(janCode);
        }

        /// <summary>
        /// POSTメソッド
        /// </summary>
        /// <param name="janCode"></param>
        /// <returns></returns>
        public Result Post(string janCode)
        {
            Result ret = new Result();

            try
            {
                Core.Crawler.Toysrus crawler = new Core.Crawler.Toysrus();
                ret = (Result)crawler.Run(janCode);
                ret.ResultStatus = ResultStatus.Success;
            }
            catch (Exception)
            {
                ret.ResultStatus = ResultStatus.Error;
            }

            return ret;
        }
    }
}