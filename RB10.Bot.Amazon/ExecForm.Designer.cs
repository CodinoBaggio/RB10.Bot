namespace RB10.Bot.Amazon
{
    partial class ExecForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.RunAmazonButton = new System.Windows.Forms.Button();
            this.CancelAmazonButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SafariRadioButton = new System.Windows.Forms.RadioButton();
            this.FirefoxRadioButton = new System.Windows.Forms.RadioButton();
            this.IERadioButton = new System.Windows.Forms.RadioButton();
            this.ChromeRadioButton = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LoginIDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UpperLimitPriceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ShopNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.PurchaseCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RunAmazonButton
            // 
            this.RunAmazonButton.Location = new System.Drawing.Point(705, 389);
            this.RunAmazonButton.Name = "RunAmazonButton";
            this.RunAmazonButton.Size = new System.Drawing.Size(113, 26);
            this.RunAmazonButton.TabIndex = 11;
            this.RunAmazonButton.Text = "実行";
            this.RunAmazonButton.UseVisualStyleBackColor = true;
            this.RunAmazonButton.Click += new System.EventHandler(this.RunAmazonButton_Click);
            // 
            // CancelAmazonButton
            // 
            this.CancelAmazonButton.Location = new System.Drawing.Point(824, 389);
            this.CancelAmazonButton.Name = "CancelAmazonButton";
            this.CancelAmazonButton.Size = new System.Drawing.Size(113, 26);
            this.CancelAmazonButton.TabIndex = 12;
            this.CancelAmazonButton.Text = "キャンセル";
            this.CancelAmazonButton.UseVisualStyleBackColor = true;
            this.CancelAmazonButton.Click += new System.EventHandler(this.CancelAmazonButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SafariRadioButton);
            this.groupBox1.Controls.Add(this.FirefoxRadioButton);
            this.groupBox1.Controls.Add(this.IERadioButton);
            this.groupBox1.Controls.Add(this.ChromeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 58);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用ブラウザ";
            // 
            // SafariRadioButton
            // 
            this.SafariRadioButton.AutoSize = true;
            this.SafariRadioButton.Enabled = false;
            this.SafariRadioButton.Location = new System.Drawing.Point(211, 25);
            this.SafariRadioButton.Name = "SafariRadioButton";
            this.SafariRadioButton.Size = new System.Drawing.Size(60, 22);
            this.SafariRadioButton.TabIndex = 3;
            this.SafariRadioButton.Text = "Safari";
            this.SafariRadioButton.UseVisualStyleBackColor = true;
            // 
            // FirefoxRadioButton
            // 
            this.FirefoxRadioButton.AutoSize = true;
            this.FirefoxRadioButton.Enabled = false;
            this.FirefoxRadioButton.Location = new System.Drawing.Point(139, 25);
            this.FirefoxRadioButton.Name = "FirefoxRadioButton";
            this.FirefoxRadioButton.Size = new System.Drawing.Size(66, 22);
            this.FirefoxRadioButton.TabIndex = 2;
            this.FirefoxRadioButton.Text = "Firefox";
            this.FirefoxRadioButton.UseVisualStyleBackColor = true;
            // 
            // IERadioButton
            // 
            this.IERadioButton.AutoSize = true;
            this.IERadioButton.Enabled = false;
            this.IERadioButton.Location = new System.Drawing.Point(95, 25);
            this.IERadioButton.Name = "IERadioButton";
            this.IERadioButton.Size = new System.Drawing.Size(38, 22);
            this.IERadioButton.TabIndex = 1;
            this.IERadioButton.Text = "IE";
            this.IERadioButton.UseVisualStyleBackColor = true;
            // 
            // ChromeRadioButton
            // 
            this.ChromeRadioButton.AutoSize = true;
            this.ChromeRadioButton.Checked = true;
            this.ChromeRadioButton.Location = new System.Drawing.Point(19, 25);
            this.ChromeRadioButton.Name = "ChromeRadioButton";
            this.ChromeRadioButton.Size = new System.Drawing.Size(70, 22);
            this.ChromeRadioButton.TabIndex = 0;
            this.ChromeRadioButton.TabStop = true;
            this.ChromeRadioButton.Text = "chrome";
            this.ChromeRadioButton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 452);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PurchaseCheckBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.PasswordTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.CancelAmazonButton);
            this.tabPage1.Controls.Add(this.LoginIDTextBox);
            this.tabPage1.Controls.Add(this.RunAmazonButton);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.UpperLimitPriceTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.ShopNameTextBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.UrlTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(949, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Amazon";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(140, 206);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(196, 25);
            this.PasswordTextBox.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 18;
            this.label5.Text = "パスワード";
            // 
            // LoginIDTextBox
            // 
            this.LoginIDTextBox.Location = new System.Drawing.Point(140, 173);
            this.LoginIDTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginIDTextBox.Name = "LoginIDTextBox";
            this.LoginIDTextBox.Size = new System.Drawing.Size(452, 25);
            this.LoginIDTextBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 16;
            this.label4.Text = "ログインID";
            // 
            // UpperLimitPriceTextBox
            // 
            this.UpperLimitPriceTextBox.Location = new System.Drawing.Point(140, 82);
            this.UpperLimitPriceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpperLimitPriceTextBox.Name = "UpperLimitPriceTextBox";
            this.UpperLimitPriceTextBox.Size = new System.Drawing.Size(116, 25);
            this.UpperLimitPriceTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "上限価格";
            // 
            // ShopNameTextBox
            // 
            this.ShopNameTextBox.Location = new System.Drawing.Point(140, 49);
            this.ShopNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShopNameTextBox.Name = "ShopNameTextBox";
            this.ShopNameTextBox.Size = new System.Drawing.Size(116, 25);
            this.ShopNameTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "ショップ名";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(140, 16);
            this.UrlTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(797, 25);
            this.UrlTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 10;
            this.label1.Text = "商品URL";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(949, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "楽天";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "商品発見時";
            // 
            // PurchaseCheckBox
            // 
            this.PurchaseCheckBox.AutoSize = true;
            this.PurchaseCheckBox.Location = new System.Drawing.Point(140, 114);
            this.PurchaseCheckBox.Name = "PurchaseCheckBox";
            this.PurchaseCheckBox.Size = new System.Drawing.Size(75, 22);
            this.PurchaseCheckBox.TabIndex = 21;
            this.PurchaseCheckBox.Text = "購入する";
            this.PurchaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 537);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ExecForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExecForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button RunAmazonButton;
        private System.Windows.Forms.Button CancelAmazonButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton IERadioButton;
        private System.Windows.Forms.RadioButton ChromeRadioButton;
        private System.Windows.Forms.RadioButton SafariRadioButton;
        private System.Windows.Forms.RadioButton FirefoxRadioButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox LoginIDTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UpperLimitPriceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ShopNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox PurchaseCheckBox;
        private System.Windows.Forms.Label label6;
    }
}

