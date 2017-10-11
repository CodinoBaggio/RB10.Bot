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
            this.label1 = new System.Windows.Forms.Label();
            this.UrlTextBox = new System.Windows.Forms.TextBox();
            this.ShopNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpperLimitPriceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LoginIDTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.RunButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ChromeRadioButton = new System.Windows.Forms.RadioButton();
            this.IERadioButton = new System.Windows.Forms.RadioButton();
            this.FirefoxRadioButton = new System.Windows.Forms.RadioButton();
            this.SafariRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品URL";
            // 
            // UrlTextBox
            // 
            this.UrlTextBox.Location = new System.Drawing.Point(137, 9);
            this.UrlTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UrlTextBox.Name = "UrlTextBox";
            this.UrlTextBox.Size = new System.Drawing.Size(797, 25);
            this.UrlTextBox.TabIndex = 1;
            // 
            // ShopNameTextBox
            // 
            this.ShopNameTextBox.Location = new System.Drawing.Point(137, 42);
            this.ShopNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShopNameTextBox.Name = "ShopNameTextBox";
            this.ShopNameTextBox.Size = new System.Drawing.Size(116, 25);
            this.ShopNameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ショップ名";
            // 
            // UpperLimitPriceTextBox
            // 
            this.UpperLimitPriceTextBox.Location = new System.Drawing.Point(137, 75);
            this.UpperLimitPriceTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.UpperLimitPriceTextBox.Name = "UpperLimitPriceTextBox";
            this.UpperLimitPriceTextBox.Size = new System.Drawing.Size(116, 25);
            this.UpperLimitPriceTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "上限価格";
            // 
            // LoginIDTextBox
            // 
            this.LoginIDTextBox.Location = new System.Drawing.Point(137, 152);
            this.LoginIDTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LoginIDTextBox.Name = "LoginIDTextBox";
            this.LoginIDTextBox.Size = new System.Drawing.Size(452, 25);
            this.LoginIDTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "ログインID";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(137, 185);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(196, 25);
            this.PasswordTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "パスワード";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(702, 269);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(113, 26);
            this.RunButton.TabIndex = 11;
            this.RunButton.Text = "実行";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(821, 268);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(113, 26);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "キャンセル";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SafariRadioButton);
            this.groupBox1.Controls.Add(this.FirefoxRadioButton);
            this.groupBox1.Controls.Add(this.IERadioButton);
            this.groupBox1.Controls.Add(this.ChromeRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(17, 236);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 58);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用ブラウザ";
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
            // ExecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 306);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LoginIDTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.UpperLimitPriceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ShopNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UrlTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "ExecForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ExecForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UrlTextBox;
        private System.Windows.Forms.TextBox ShopNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UpperLimitPriceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LoginIDTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton IERadioButton;
        private System.Windows.Forms.RadioButton ChromeRadioButton;
        private System.Windows.Forms.RadioButton SafariRadioButton;
        private System.Windows.Forms.RadioButton FirefoxRadioButton;
    }
}

