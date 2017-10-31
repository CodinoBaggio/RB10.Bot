namespace RB10.Bot.Ec
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
            this.StopAmazonButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.MailPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MailPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ToMailAddressTextBox = new System.Windows.Forms.TextBox();
            this.MailCheckBox = new System.Windows.Forms.CheckBox();
            this.SafariRadioButton = new System.Windows.Forms.RadioButton();
            this.FirefoxRadioButton = new System.Windows.Forms.RadioButton();
            this.IERadioButton = new System.Windows.Forms.RadioButton();
            this.ChromeRadioButton = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PurchaseCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ToysrusUrlTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ToysrusJanCodeFilePathTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.RunToysrusButton = new System.Windows.Forms.Button();
            this.ToysrusFileSelectButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.MailPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // RunAmazonButton
            // 
            this.RunAmazonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RunAmazonButton.Location = new System.Drawing.Point(705, 206);
            this.RunAmazonButton.Name = "RunAmazonButton";
            this.RunAmazonButton.Size = new System.Drawing.Size(113, 26);
            this.RunAmazonButton.TabIndex = 12;
            this.RunAmazonButton.Text = "実行";
            this.RunAmazonButton.UseVisualStyleBackColor = true;
            this.RunAmazonButton.Click += new System.EventHandler(this.RunAmazonButton_Click);
            // 
            // StopAmazonButton
            // 
            this.StopAmazonButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopAmazonButton.Location = new System.Drawing.Point(824, 205);
            this.StopAmazonButton.Name = "StopAmazonButton";
            this.StopAmazonButton.Size = new System.Drawing.Size(113, 26);
            this.StopAmazonButton.TabIndex = 13;
            this.StopAmazonButton.Text = "停止";
            this.StopAmazonButton.UseVisualStyleBackColor = true;
            this.StopAmazonButton.Click += new System.EventHandler(this.StopAmazonButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.MailPanel);
            this.groupBox1.Controls.Add(this.MailCheckBox);
            this.groupBox1.Controls.Add(this.SafariRadioButton);
            this.groupBox1.Controls.Add(this.FirefoxRadioButton);
            this.groupBox1.Controls.Add(this.IERadioButton);
            this.groupBox1.Controls.Add(this.ChromeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "共通設定";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 0;
            this.label9.Text = "使用ブラウザ";
            // 
            // MailPanel
            // 
            this.MailPanel.Controls.Add(this.label7);
            this.MailPanel.Controls.Add(this.label8);
            this.MailPanel.Controls.Add(this.MailPasswordTextBox);
            this.MailPanel.Controls.Add(this.ToMailAddressTextBox);
            this.MailPanel.Enabled = false;
            this.MailPanel.Location = new System.Drawing.Point(308, 50);
            this.MailPanel.Name = "MailPanel";
            this.MailPanel.Size = new System.Drawing.Size(406, 67);
            this.MailPanel.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 18);
            this.label7.TabIndex = 0;
            this.label7.Text = "送信先メールアドレス";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 18);
            this.label8.TabIndex = 2;
            this.label8.Text = "メールパスワード";
            // 
            // MailPasswordTextBox
            // 
            this.MailPasswordTextBox.Location = new System.Drawing.Point(139, 37);
            this.MailPasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MailPasswordTextBox.Name = "MailPasswordTextBox";
            this.MailPasswordTextBox.Size = new System.Drawing.Size(258, 25);
            this.MailPasswordTextBox.TabIndex = 3;
            // 
            // ToMailAddressTextBox
            // 
            this.ToMailAddressTextBox.Location = new System.Drawing.Point(139, 4);
            this.ToMailAddressTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToMailAddressTextBox.Name = "ToMailAddressTextBox";
            this.ToMailAddressTextBox.Size = new System.Drawing.Size(258, 25);
            this.ToMailAddressTextBox.TabIndex = 1;
            // 
            // MailCheckBox
            // 
            this.MailCheckBox.AutoSize = true;
            this.MailCheckBox.Location = new System.Drawing.Point(308, 21);
            this.MailCheckBox.Name = "MailCheckBox";
            this.MailCheckBox.Size = new System.Drawing.Size(231, 22);
            this.MailCheckBox.TabIndex = 5;
            this.MailCheckBox.Text = "商品がヒットしたらメール送信を行う";
            this.MailCheckBox.UseVisualStyleBackColor = true;
            this.MailCheckBox.CheckedChanged += new System.EventHandler(this.MailCheckBox_CheckedChanged);
            // 
            // SafariRadioButton
            // 
            this.SafariRadioButton.AutoSize = true;
            this.SafariRadioButton.Enabled = false;
            this.SafariRadioButton.Location = new System.Drawing.Point(213, 43);
            this.SafariRadioButton.Name = "SafariRadioButton";
            this.SafariRadioButton.Size = new System.Drawing.Size(60, 22);
            this.SafariRadioButton.TabIndex = 4;
            this.SafariRadioButton.Text = "Safari";
            this.SafariRadioButton.UseVisualStyleBackColor = true;
            // 
            // FirefoxRadioButton
            // 
            this.FirefoxRadioButton.AutoSize = true;
            this.FirefoxRadioButton.Enabled = false;
            this.FirefoxRadioButton.Location = new System.Drawing.Point(141, 43);
            this.FirefoxRadioButton.Name = "FirefoxRadioButton";
            this.FirefoxRadioButton.Size = new System.Drawing.Size(66, 22);
            this.FirefoxRadioButton.TabIndex = 3;
            this.FirefoxRadioButton.Text = "Firefox";
            this.FirefoxRadioButton.UseVisualStyleBackColor = true;
            // 
            // IERadioButton
            // 
            this.IERadioButton.AutoSize = true;
            this.IERadioButton.Enabled = false;
            this.IERadioButton.Location = new System.Drawing.Point(97, 43);
            this.IERadioButton.Name = "IERadioButton";
            this.IERadioButton.Size = new System.Drawing.Size(38, 22);
            this.IERadioButton.TabIndex = 2;
            this.IERadioButton.Text = "IE";
            this.IERadioButton.UseVisualStyleBackColor = true;
            // 
            // ChromeRadioButton
            // 
            this.ChromeRadioButton.AutoSize = true;
            this.ChromeRadioButton.Checked = true;
            this.ChromeRadioButton.Location = new System.Drawing.Point(21, 43);
            this.ChromeRadioButton.Name = "ChromeRadioButton";
            this.ChromeRadioButton.Size = new System.Drawing.Size(70, 22);
            this.ChromeRadioButton.TabIndex = 1;
            this.ChromeRadioButton.TabStop = true;
            this.ChromeRadioButton.Text = "chrome";
            this.ChromeRadioButton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 147);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 273);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PurchaseCheckBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.PasswordTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.StopAmazonButton);
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
            this.tabPage1.Size = new System.Drawing.Size(949, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Amazon";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PurchaseCheckBox
            // 
            this.PurchaseCheckBox.AutoSize = true;
            this.PurchaseCheckBox.Location = new System.Drawing.Point(140, 114);
            this.PurchaseCheckBox.Name = "PurchaseCheckBox";
            this.PurchaseCheckBox.Size = new System.Drawing.Size(75, 22);
            this.PurchaseCheckBox.TabIndex = 7;
            this.PurchaseCheckBox.Text = "購入する";
            this.PurchaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "商品発見時";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(140, 206);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(196, 25);
            this.PasswordTextBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "パスワード";
            // 
            // LoginIDTextBox
            // 
            this.LoginIDTextBox.Location = new System.Drawing.Point(140, 173);
            this.LoginIDTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginIDTextBox.Name = "LoginIDTextBox";
            this.LoginIDTextBox.Size = new System.Drawing.Size(452, 25);
            this.LoginIDTextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "ログインID";
            // 
            // UpperLimitPriceTextBox
            // 
            this.UpperLimitPriceTextBox.Location = new System.Drawing.Point(140, 82);
            this.UpperLimitPriceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpperLimitPriceTextBox.Name = "UpperLimitPriceTextBox";
            this.UpperLimitPriceTextBox.Size = new System.Drawing.Size(116, 25);
            this.UpperLimitPriceTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "上限価格";
            // 
            // ShopNameTextBox
            // 
            this.ShopNameTextBox.Location = new System.Drawing.Point(140, 49);
            this.ShopNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShopNameTextBox.Name = "ShopNameTextBox";
            this.ShopNameTextBox.Size = new System.Drawing.Size(116, 25);
            this.ShopNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ショップ名";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(140, 16);
            this.UrlTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(797, 25);
            this.UrlTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品URL";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(949, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "楽天";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(12, 462);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(953, 328);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "EcSite";
            this.Column1.HeaderText = "ECサイト名";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "LogDate";
            this.Column2.HeaderText = "日時";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Status";
            this.Column4.HeaderText = "ステータス";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Message";
            this.Column3.HeaderText = "メッセージ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 480;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 441);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 18);
            this.label10.TabIndex = 3;
            this.label10.Text = "ログ";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ToysrusFileSelectButton);
            this.tabPage3.Controls.Add(this.RunToysrusButton);
            this.tabPage3.Controls.Add(this.ToysrusJanCodeFilePathTextBox);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.ToysrusUrlTextBox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(949, 242);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "トイザらス";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ToysrusUrlTextBox
            // 
            this.ToysrusUrlTextBox.Location = new System.Drawing.Point(154, 23);
            this.ToysrusUrlTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToysrusUrlTextBox.Name = "ToysrusUrlTextBox";
            this.ToysrusUrlTextBox.Size = new System.Drawing.Size(780, 25);
            this.ToysrusUrlTextBox.TabIndex = 3;
            this.ToysrusUrlTextBox.Text = "https://www.toysrus.co.jp/";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 18);
            this.label11.TabIndex = 2;
            this.label11.Text = "トイザらスon line URL";
            // 
            // ToysrusJanCodeFilePathTextBox
            // 
            this.ToysrusJanCodeFilePathTextBox.Location = new System.Drawing.Point(154, 56);
            this.ToysrusJanCodeFilePathTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ToysrusJanCodeFilePathTextBox.Name = "ToysrusJanCodeFilePathTextBox";
            this.ToysrusJanCodeFilePathTextBox.Size = new System.Drawing.Size(745, 25);
            this.ToysrusJanCodeFilePathTextBox.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 18);
            this.label12.TabIndex = 4;
            this.label12.Text = "JANコードファイルパス";
            // 
            // RunToysrusButton
            // 
            this.RunToysrusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RunToysrusButton.Location = new System.Drawing.Point(821, 210);
            this.RunToysrusButton.Name = "RunToysrusButton";
            this.RunToysrusButton.Size = new System.Drawing.Size(113, 26);
            this.RunToysrusButton.TabIndex = 13;
            this.RunToysrusButton.Text = "実行";
            this.RunToysrusButton.UseVisualStyleBackColor = true;
            this.RunToysrusButton.Click += new System.EventHandler(this.RunToysrusButton_Click);
            // 
            // ToysrusFileSelectButton
            // 
            this.ToysrusFileSelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ToysrusFileSelectButton.Location = new System.Drawing.Point(905, 56);
            this.ToysrusFileSelectButton.Name = "ToysrusFileSelectButton";
            this.ToysrusFileSelectButton.Size = new System.Drawing.Size(29, 26);
            this.ToysrusFileSelectButton.TabIndex = 14;
            this.ToysrusFileSelectButton.Text = "...";
            this.ToysrusFileSelectButton.UseVisualStyleBackColor = true;
            this.ToysrusFileSelectButton.Click += new System.EventHandler(this.ToysrusFileSelectButton_Click);
            // 
            // ExecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 801);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dataGridView1);
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
            this.MailPanel.ResumeLayout(false);
            this.MailPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button RunAmazonButton;
        private System.Windows.Forms.Button StopAmazonButton;
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
        private System.Windows.Forms.CheckBox MailCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ToMailAddressTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox MailPasswordTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel MailPanel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button ToysrusFileSelectButton;
        private System.Windows.Forms.Button RunToysrusButton;
        private System.Windows.Forms.TextBox ToysrusJanCodeFilePathTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox ToysrusUrlTextBox;
        private System.Windows.Forms.Label label11;
    }
}

