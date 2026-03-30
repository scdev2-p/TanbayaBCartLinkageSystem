namespace BCart商品登録.Forms
{
    partial class frmChangePickingFloor
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
            btnClose = new Button();
            panel1 = new Panel();
            lblInfo1 = new Label();
            btnInputFile = new Button();
            txtInputFile = new TextBox();
            lblInputFile = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(884, 291);
            btnClose.Margin = new Padding(4, 2, 4, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(175, 47);
            btnClose.TabIndex = 24;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblInfo1);
            panel1.Location = new Point(12, 187);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 84);
            panel1.TabIndex = 23;
            // 
            // lblInfo1
            // 
            lblInfo1.AutoSize = true;
            lblInfo1.Location = new Point(16, 17);
            lblInfo1.Name = "lblInfo1";
            lblInfo1.Size = new Size(383, 32);
            lblInfo1.TabIndex = 4;
            lblInfo1.Text = "Bカート商品のフロアを一括変更します。";
            // 
            // btnInputFile
            // 
            btnInputFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnInputFile.Location = new Point(953, 13);
            btnInputFile.Name = "btnInputFile";
            btnInputFile.Size = new Size(106, 46);
            btnInputFile.TabIndex = 22;
            btnInputFile.Text = "参照";
            btnInputFile.UseVisualStyleBackColor = true;
            // 
            // txtInputFile
            // 
            txtInputFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInputFile.Location = new Point(391, 17);
            txtInputFile.Name = "txtInputFile";
            txtInputFile.Size = new Size(556, 39);
            txtInputFile.TabIndex = 21;
            // 
            // lblInputFile
            // 
            lblInputFile.AutoSize = true;
            lblInputFile.Location = new Point(12, 20);
            lblInputFile.Name = "lblInputFile";
            lblInputFile.Size = new Size(303, 32);
            lblInputFile.TabIndex = 20;
            lblInputFile.Text = "移動する商品バーコードのリスト";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(158, 32);
            label1.TabIndex = 25;
            label1.Text = "移動先のフロア";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "B1F", "１F", "２F", "３F", "４F", "5課", "営業支援" });
            comboBox1.Location = new Point(391, 72);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(135, 40);
            comboBox1.TabIndex = 26;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(681, 122);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.Size = new Size(377, 47);
            button1.TabIndex = 27;
            button1.Text = "商品の移動先フロアを登録する";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmChangePickingFloor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1071, 349);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            Controls.Add(btnInputFile);
            Controls.Add(txtInputFile);
            Controls.Add(lblInputFile);
            Name = "frmChangePickingFloor";
            Text = "frmChangePickingFloor";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnClose;
        private Panel panel1;
        private Label lblInfo1;
        private Button btnInputFile;
        private TextBox txtInputFile;
        private Label lblInputFile;
        private Label label1;
        private ComboBox comboBox1;
        private Button button1;
    }
}