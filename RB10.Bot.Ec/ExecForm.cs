using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RB10.Bot.Ec
{
    public partial class ExecForm : Form
    {
        private Library.Configuration _config;
        private Core.Selenium.ECSite.ECBase _ec;

        public ExecForm()
        {
            InitializeComponent();

            _config = new Library.Configuration(Properties.Settings.Default.BotConfigurationFileName);
        }

        private void ExecForm_Load(object sender, EventArgs e)
        {
            ToMailAddressTextBox.Text = _config.Common.ToMailAddress;
            UrlTextBox.Text = _config.EcSite.Amazon.ItemUrl;
            ShopNameTextBox.Text = _config.EcSite.Amazon.ShopName;
            UpperLimitPriceTextBox.Text = _config.EcSite.Amazon.UpperLimitPrice.ToString();
            LoginIDTextBox.Text = _config.EcSite.Amazon.LoginID;
        }

        private void RunAmazonButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MailCheckBox.Checked)
                {
                    if (ToMailAddressTextBox.Text == "") throw new ApplicationException("送信先メールアドレスを入力してください。");
                    if (MailPasswordTextBox.Text == "") throw new ApplicationException("メールパスワードを入力して下しさい。");
                }
                if (UrlTextBox.Text == "") throw new ApplicationException("商品URLを入力してください。");
                if (ShopNameTextBox.Text == "") throw new ApplicationException("ショップ名を入力してください。");
                if (UpperLimitPriceTextBox.Text == "") throw new ApplicationException("上限価格を入力してください。");
                if (LoginIDTextBox.Text == "") throw new ApplicationException("ログインIDを入力してください。");
                if (PasswordTextBox.Text == "") throw new ApplicationException("パスワードを入力してください。");

                var param = new Core.Selenium.ECSite.Amazon.AmazonParameters
                {
                    WebDriver = GetWebDriverType(),
                    ItemUrl = UrlTextBox.Text,
                    LoginID = LoginIDTextBox.Text,
                    Password = PasswordTextBox.Text,
                    PurchaseShopName = ShopNameTextBox.Text,
                    UpperLimitPrice = Convert.ToDecimal(UpperLimitPriceTextBox.Text),
                    FixedOrder = PurchaseCheckBox.Checked,
                    IsSendMail = MailCheckBox.Checked,
                    ToMailAddress = ToMailAddressTextBox.Text,
                    MailPassword = MailPasswordTextBox.Text
                };

                _ec = new Core.Selenium.ECSite.Amazon(param);
                _ec.ExecutingStateChanged += Ec_ExecutingStateChanged;
                _ec.Start();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopAmazonButton_Click(object sender, EventArgs e)
        {
            try
            {
                _ec.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MailCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var chkBox = (CheckBox)sender;
            MailPanel.Enabled = chkBox.Checked;
        }

        private Core.Selenium.ECSite.ECBase.WebDriverType GetWebDriverType()
        {
            if (ChromeRadioButton.Checked) return Core.Selenium.ECSite.ECBase.WebDriverType.Chrome;
            if (IERadioButton.Checked) return Core.Selenium.ECSite.ECBase.WebDriverType.IE;
            if (FirefoxRadioButton.Checked) return Core.Selenium.ECSite.ECBase.WebDriverType.Firefox;
            if (SafariRadioButton.Checked) return Core.Selenium.ECSite.ECBase.WebDriverType.Safari;

            return Core.Selenium.ECSite.ECBase.WebDriverType.Chrome;
        }

        private void Ec_ExecutingStateChanged(object sender, Core.Selenium.ECSite.ECBase.ExecutingStateEventArgs e)
        {
            Invoke(new LogDelegate(AddLog), e.EcSite, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), e.ReportState.ToString(), e.Message);
        }

        private class Log
        {
            public string EcSite { get; set; }
            public string LogDate { get; set; }
            public string Status { get; set; }
            public string Message { get; set; }
        }

        private BindingList<Log> _logs { get; set; }
        delegate void LogDelegate(string ecSite, string logDate, string status, string message);

        private void AddLog(string ecSite, string logDate, string status, string message)
        {
            if (_logs == null)
            {
                _logs = new BindingList<Log>();
                dataGridView1.DataSource = _logs;
            }

            _logs.Insert(0, new Log { EcSite = ecSite, LogDate = logDate, Status = status, Message = message });
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == -1) return;

            if (e.ColumnIndex == 2)
            {
                if (e.Value.ToString() == "Warning")
                {
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle() { BackColor = System.Drawing.Color.Yellow, ForeColor = System.Drawing.Color.Black };
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle = cellStyle;
                }
                else if (e.Value.ToString() == "Error")
                {
                    DataGridViewCellStyle cellStyle = new DataGridViewCellStyle() { BackColor = System.Drawing.Color.Red, ForeColor = System.Drawing.Color.White };
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle = cellStyle;
                }
            }
        }

        private void ToysrusFileSelectButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "csvファイル (*.csv)|*.csv|すべてのファイル (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.Cancel) return;

            ToysrusJanCodeFilePathTextBox.Text = dlg.FileName;
        }

        private void RunToysrusButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ToysrusUrlTextBox.Text == "") throw new ApplicationException("トイザらスon line URLを入力してください。");
                if (ToysrusJanCodeFilePathTextBox.Text == "") throw new ApplicationException("JANコードファイルパスを入力してください。");

                SaveFileDialog dlg = new SaveFileDialog();
                dlg.FileName = System.IO.Path.GetFileNameWithoutExtension(ToysrusJanCodeFilePathTextBox.Text) + "_result.csv";
                if (dlg.ShowDialog() == DialogResult.Cancel) return;

                var param = new Core.Selenium.ECSite.Toysrus.ToysrusParameters
                {
                    WebDriver = GetWebDriverType(),
                    ItemUrl = ToysrusUrlTextBox.Text,
                    JanCodeFileName = ToysrusJanCodeFilePathTextBox.Text,
                    OutputFilePath = dlg.FileName
                };

                _ec = new Core.Selenium.ECSite.Toysrus(param);
                _ec.ExecutingStateChanged += Ec_ExecutingStateChanged;
                _ec.Start();
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
