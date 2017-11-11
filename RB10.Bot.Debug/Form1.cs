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
    }
}
