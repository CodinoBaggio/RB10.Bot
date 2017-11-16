using Line.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RB10.Bot.Debug
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var message = $"商品が見つかりました。\n下記URLから商品購入を行ってください。\nhttps://www.toysrus.co.jp/search/?q=4902370537789";
            LineMessagingClient lineMessagingClient = new LineMessagingClient("42ndcVVsa4VFSJD9vtyuslUG6VLkWz+i96cu5AFJlsjdOgyQx0SZO0k/4sDu7dE7iFoMl34+qBkUKnjecyjWDItkpWmIOtAxGGupCH/93zeKW/jsY4oS5UDXkBPYZunZxlbP8Qv2wH9slZLA5N+3ZAdB04t89/1O/w1cDnyilFU=");
            lineMessagingClient.PushMessageAsync("U40ab91bbe212e2256a52157bf13c5705", message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Core.Crawler.BicCamera crawler = new Core.Crawler.BicCamera();
            crawler.Run("4904810408444");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetGoods(@"4902370535709,Nintendo Switch Joy-Con (L) / (R) グレー|4902370535716,Nintendo Switch [ネオンブルー/ネオンレッド]", 0, out var janCode, out var goodsName);


            Core.Crawler.Toysrus crawler = new Core.Crawler.Toysrus();
            crawler.Run(janCode, true);
        }

        private static void GetGoods(string config, int index, out string jancode, out string goodsName)
        {
            var goodsArr = config.Split('|');
            if (index + 1 <= goodsArr.Length)
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
