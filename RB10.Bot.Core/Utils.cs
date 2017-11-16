using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Core
{
    public class Utils
    {
        public static string GetHtml(string url, bool useProxy = false)
        {
            HttpWebRequest req = null;

            try
            {
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Timeout = 100000;
                req.UserAgent = "Rb10Crawler (+codino.baggio10@gmail.com)";
                if (useProxy)
                {
                    req.Proxy = new WebProxy("165084167054.ctinets.com", 8080);
                }

                // html取得文字列
                string html = "";

                using (var res = (HttpWebResponse)req.GetResponse())
                using (var resSt = res.GetResponseStream())
                using (var sr = new StreamReader(resSt, Encoding.UTF8))
                {
                    html = sr.ReadToEnd();
                }

                return html;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (req != null) req.Abort();
            }
        }
    }
}
