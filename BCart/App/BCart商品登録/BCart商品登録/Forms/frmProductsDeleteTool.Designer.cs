namespace BCart商品登録.Forms
{
    partial class frmProductsDeleteTool
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
            lblInputFile = new Label();
            txtInputFile = new TextBox();
            btnInputFile = new Button();
            panel1 = new Panel();
            btnDoDelete = new Button();
            lblInfo2 = new Label();
            lblInfo1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            btnClose = new Button();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblInputFile
            // 
            lblInputFile.AutoSize = true;
            lblInputFile.Location = new Point(12, 21);
            lblInputFile.Name = "lblInputFile";
            lblInputFile.Size = new Size(307, 32);
            lblInputFile.TabIndex = 0;
            lblInputFile.Text = "削除するBカート商品IDのリスト";
            // 
            // txtInputFile
            // 
            txtInputFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInputFile.Location = new Point(391, 18);
            txtInputFile.Name = "txtInputFile";
            txtInputFile.Size = new Size(556, 39);
            txtInputFile.TabIndex = 1;
            // 
            // btnInputFile
            // 
            btnInputFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInputFile.Location = new Point(953, 14);
            btnInputFile.Name = "btnInputFile";
            btnInputFile.Size = new Size(106, 46);
            btnInputFile.TabIndex = 2;
            btnInputFile.Text = "参照";
            btnInputFile.UseVisualStyleBackColor = true;
            btnInputFile.Click += btnInputFile_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnDoDelete);
            panel1.Controls.Add(lblInfo2);
            panel1.Controls.Add(lblInfo1);
            panel1.Location = new Point(12, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 130);
            panel1.TabIndex = 3;
            // 
            // btnDoDelete
            // 
            btnDoDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDoDelete.Location = new Point(727, 10);
            btnDoDelete.Name = "btnDoDelete";
            btnDoDelete.Size = new Size(304, 46);
            btnDoDelete.TabIndex = 6;
            btnDoDelete.Text = "削除用ファイルを作成する";
            btnDoDelete.UseVisualStyleBackColor = true;
            btnDoDelete.Click += btnDoDelete_Click;
            // 
            // lblInfo2
            // 
            lblInfo2.AutoSize = true;
            lblInfo2.Location = new Point(16, 62);
            lblInfo2.Name = "lblInfo2";
            lblInfo2.Size = new Size(394, 32);
            lblInfo2.TabIndex = 5;
            lblInfo2.Text = "Bカートインポート用ファイルを出力します。";
            // 
            // lblInfo1
            // 
            lblInfo1.AutoSize = true;
            lblInfo1.Location = new Point(16, 17);
            lblInfo1.Name = "lblInfo1";
            lblInfo1.Size = new Size(351, 32);
            lblInfo1.TabIndex = 4;
            lblInfo1.Text = "連携用DBの商品に削除を設定し、";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(884, 358);
            btnClose.Margin = new Padding(4, 2, 4, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(175, 47);
            btnClose.TabIndex = 18;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 214);
            panel2.Name = "panel2";
            panel2.Size = new Size(1047, 90);
            panel2.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 5);
            label1.Name = "label1";
            label1.Size = new Size(693, 32);
            label1.TabIndex = 0;
            label1.Text = "※削除前にBカートの商品をエクスポートしておけばバックアップとなります。";
            // 
            // frmProductsDeleteTool
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 416);
            Controls.Add(panel2);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            Controls.Add(btnInputFile);
            Controls.Add(txtInputFile);
            Controls.Add(lblInputFile);
            Name = "frmProductsDeleteTool";
            Text = "frmProductsDeleteTool";
            Load += frmProductsDeleteTool_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblInputFile;
        private TextBox txtInputFile;
        private Button btnInputFile;
        private Panel panel1;
        private Button btnDoDelete;
        private Label lblInfo2;
        private Label lblInfo1;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private Button btnClose;
        private Panel panel2;
        private Label label1;
    }
}