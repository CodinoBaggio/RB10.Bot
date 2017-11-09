using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RB10.Bot.Crawler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void Start(string janCode)
        {
            while (true)
            {
                try
                {
                    string url = $"http://ecsitescraping.azurewebsites.net/api/toysrus/?janCode={janCode}";
                    string json = new HttpClient().GetStringAsync(url).Result;
                    JObject jobj = JObject.Parse(json);

                    var status = jobj.GetValue("Status") as JValue;
                    var onlineStock = jobj.GetValue("OnlineStock") as JValue;
                    if (status.Value.ToString() == "0" && onlineStock.Value.ToString() == "在庫あり")
                    {
                        break;
                    }
                    else
                    {
                        Task.Delay(60000).Wait();
                    }
                }
                catch (Exception)
                {
                }
            }

            MessageBox.Show("あるよ");
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            Task.Run(() => Start(JanCodeTextBox.Text));
        }
    }
}
