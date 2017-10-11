using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RB10.Bot.Amazon
{
    public partial class ExecForm : Form
    {
        private Library.ECSite.ECBase _ec;

        public ExecForm()
        {
            InitializeComponent();
        }

        private void ExecForm_Load(object sender, EventArgs e)
        {
            UrlTextBox.Text = Properties.Settings.Default.ItemUrl;
            ShopNameTextBox.Text = Properties.Settings.Default.ShopName;
            UpperLimitPriceTextBox.Text = Properties.Settings.Default.UpperLimitPrice.ToString();
            LoginIDTextBox.Text = Properties.Settings.Default.LoginID;
        }

        private void RunAmazonButton_Click(object sender, EventArgs e)
        {
            try
            {
                _ec = new Library.ECSite.Amazon
                {
                    ItemUrl = UrlTextBox.Text,
                    LoginID = LoginIDTextBox.Text,
                    Password = PasswordTextBox.Text,
                    PurchaseShopName = ShopNameTextBox.Text,
                    UpperLimitPrice = Convert.ToDecimal(UpperLimitPriceTextBox.Text),
                    WebDriver = Library.ECSite.ECBase.WebDriverType.Chrome,
                    FixedOrder = PurchaseCheckBox.Checked
                };
                _ec.Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelAmazonButton_Click(object sender, EventArgs e)
        {
            try
            {
                _ec.Cancel = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
