using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Library
{
    public class Configuration
    {
        public class CommonConfig
        {
            public string ToMailAddress { get; set; }
        }

        public class EcSiteConfig
        {
            public class AmazonConfig
            {
                public string ItemUrl { get; set; }
                public string ShopName { get; set; }
                public Decimal UpperLimitPrice { get; set; }
                public string LoginID { get; set; }
            }

            public class RakutenConfig
            {
                public string LoginID { get; set; }
            }

            public AmazonConfig Amazon { get; set; }
            public RakutenConfig Rakuten { get; set; }
        }

        public CommonConfig Common { get; set; }
        public EcSiteConfig EcSite { get; set; }

        public Configuration()
        {

        }

        public Configuration(string fileName)
        {
            var config = Deserialize<Configuration>(fileName);
            Common = config.Common;
            EcSite = config.EcSite;
        }

        private T Deserialize<T>(string fileName)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fileName, new System.Text.UTF8Encoding(false)))
            {
                return (T)serializer.Deserialize(sr);
            }
        }
    }
}
