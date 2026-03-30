namespace Bcart受注管理.Forms
{
    partial class frmProductImgInport
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
            txtCsvFileName = new TextBox();
            button1 = new Button();
            label3 = new Label();
            btnInport = new Button();
            openFileDialog1 = new OpenFileDialog();
            chkContinue = new CheckBox();
            btnClose = new Button();
            label4 = new Label();
            lblOutFolder = new Label();
            lblWait = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 76);
            label1.Name = "label1";
            label1.Size = new Size(143, 32);
            label1.TabIndex = 0;
            label1.Text = "商品画像csv";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(871, 50);
            label2.TabIndex = 1;
            label2.Text = "ピッキングリスト用商品画像取込";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtCsvFileName
            // 
            txtCsvFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCsvFileName.Location = new Point(171, 73);
            txtCsvFileName.Name = "txtCsvFileName";
            txtCsvFileName.Size = new Size(588, 39);
            txtCsvFileName.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(765, 69);
            button1.Name = "button1";
            button1.Size = new Size(118, 46);
            button1.TabIndex = 3;
            button1.Text = "参照";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(12, 235);
            label3.Name = "label3";
            label3.Size = new Size(871, 142);
            label3.TabIndex = 4;
            label3.Text = "Bカートの商品一覧から「商品画像取得用[SC]」でcsvをダウンロードしてください。\r\nBカートのメイン商品画像をピッキングリスト印刷用に保存します。\r\n";
            // 
            // btnInport
            // 
            btnInport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInport.Location = new Point(644, 318);
            btnInport.Name = "btnInport";
            btnInport.Size = new Size(222, 46);
            btnInport.TabIndex = 5;
            btnInport.Text = "メイン画像を保存";
            btnInport.UseVisualStyleBackColor = true;
            btnInport.Click += btnInport_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // chkContinue
            // 
            chkContinue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkContinue.AutoSize = true;
            chkContinue.Checked = true;
            chkContinue.CheckState = CheckState.Checked;
            chkContinue.Location = new Point(664, 185);
            chkContinue.Name = "chkContinue";
            chkContinue.Size = new Size(219, 36);
            chkContinue.TabIndex = 6;
            chkContinue.Text = "新規のみ取り込む";
            chkContinue.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom;
            btnClose.Location = new Point(381, 404);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 46);
            btnClose.TabIndex = 7;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 136);
            label4.Name = "label4";
            label4.Size = new Size(110, 32);
            label4.TabIndex = 8;
            label4.Text = "保存場所";
            // 
            // lblOutFolder
            // 
            lblOutFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblOutFolder.BorderStyle = BorderStyle.Fixed3D;
            lblOutFolder.Location = new Point(171, 133);
            lblOutFolder.Name = "lblOutFolder";
            lblOutFolder.Size = new Size(588, 38);
            lblOutFolder.TabIndex = 9;
            lblOutFolder.Text = "label5";
            lblOutFolder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblWait
            // 
            lblWait.Anchor = AnchorStyles.Top;
            lblWait.BackColor = Color.Yellow;
            lblWait.Font = new Font("Yu Gothic UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblWait.ForeColor = Color.Red;
            lblWait.Location = new Point(171, 202);
            lblWait.Name = "lblWait";
            lblWait.Size = new Size(557, 64);
            lblWait.TabIndex = 10;
            lblWait.Text = "取込中・・・";
            lblWait.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmProductImgInport
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 462);
            Controls.Add(lblWait);
            Controls.Add(lblOutFolder);
            Controls.Add(label4);
            Controls.Add(btnClose);
            Controls.Add(chkContinue);
            Controls.Add(btnInport);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(txtCsvFileName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmProductImgInport";
            Text = "frmProductImgInport";
            Load += frmProductImgInport_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCsvFileName;
        private Button button1;
        private Label label3;
        private Button btnInport;
        private OpenFileDialog openFileDialog1;
        private CheckBox chkContinue;
        private Button btnClose;
        private Label label4;
        private Label lblOutFolder;
        private Label lblWait;
    }
}