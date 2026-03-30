namespace BCart商品登録.Forms
{
    partial class frmImportProductsInformation
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
            txtFileName = new TextBox();
            btnFileName = new Button();
            btnImport = new Button();
            btnClose = new Button();
            textBox2 = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(13, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(928, 64);
            label1.TabIndex = 1;
            label1.Text = "メーカー商品情報登録";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 104);
            label2.Name = "label2";
            label2.Size = new Size(243, 32);
            label2.TabIndex = 3;
            label2.Text = "メーカーー商品情報Excel";
            // 
            // txtFileName
            // 
            txtFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFileName.Location = new Point(272, 101);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(521, 39);
            txtFileName.TabIndex = 4;
            // 
            // btnFileName
            // 
            btnFileName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFileName.Location = new Point(807, 97);
            btnFileName.Name = "btnFileName";
            btnFileName.Size = new Size(122, 46);
            btnFileName.TabIndex = 5;
            btnFileName.Text = "参照";
            btnFileName.UseVisualStyleBackColor = true;
            btnFileName.Click += btnFileName_Click;
            // 
            // btnImport
            // 
            btnImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImport.Location = new Point(514, 174);
            btnImport.Name = "btnImport";
            btnImport.Size = new Size(415, 55);
            btnImport.TabIndex = 6;
            btnImport.Text = "商品情報を中間DBに取り込む";
            btnImport.UseVisualStyleBackColor = true;
            btnImport.Click += btnImport_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Location = new Point(792, 461);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(137, 55);
            btnClose.TabIndex = 7;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(23, 269);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(906, 174);
            textBox2.TabIndex = 8;
            textBox2.Text = "メーカーの商品情報を中間DBに取り込むと、\r\n商品登録画面でバーコードを入力した時に該当商品情報が\r\n入力項目に読み込まれます。\r\n同一商品を取り込んだ場合、最新の商品情報が反映されます。";
            textBox2.WordWrap = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmImportProductsInformation
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 528);
            Controls.Add(textBox2);
            Controls.Add(btnClose);
            Controls.Add(btnImport);
            Controls.Add(btnFileName);
            Controls.Add(txtFileName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmImportProductsInformation";
            Text = "frmImportProductsInformation";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtFileName;
        private Button btnFileName;
        private Button btnImport;
        private Button btnClose;
        private TextBox textBox2;
        private OpenFileDialog openFileDialog1;
    }
}