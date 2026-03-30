namespace Bcart受注管理.Forms
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtLoginID = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Gray;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 64);
            label1.Name = "label1";
            label1.Size = new Size(229, 39);
            label1.TabIndex = 0;
            label1.Text = "社員番号";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Gray;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(22, 123);
            label2.Name = "label2";
            label2.Size = new Size(229, 39);
            label2.TabIndex = 1;
            label2.Text = "パスワード";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtLoginID
            // 
            txtLoginID.Location = new Point(257, 64);
            txtLoginID.Name = "txtLoginID";
            txtLoginID.Size = new Size(406, 39);
            txtLoginID.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(257, 123);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(406, 39);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogin.Location = new Point(332, 234);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 46);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "ログイン";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(513, 234);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 46);
            btnClose.TabIndex = 5;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 310);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtLoginID);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmLogin";
            Text = "ログイン";
            Load += frmLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtLoginID;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnClose;
    }
}