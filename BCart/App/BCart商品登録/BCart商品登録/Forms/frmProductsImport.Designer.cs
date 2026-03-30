namespace BCart商品登録.Forms
{
    partial class frmProductsImport
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
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            label6 = new Label();
            txtIDOnlly = new TextBox();
            txtIDRangeTo = new TextBox();
            label5 = new Label();
            label4 = new Label();
            txtIDRangeFrom = new TextBox();
            rdoIDOnly = new RadioButton();
            rdoIDRange = new RadioButton();
            groupBox2 = new GroupBox();
            rdoOverrideON = new RadioButton();
            rdoOverrideOff = new RadioButton();
            btnDoImport = new Button();
            btnClose = new Button();
            label7 = new Label();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
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
            label1.Size = new Size(1179, 64);
            label1.TabIndex = 16;
            label1.Text = "Bカート商品の再取込";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(13, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(1179, 107);
            panel1.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 56);
            label3.Name = "label3";
            label3.Size = new Size(611, 32);
            label3.TabIndex = 1;
            label3.Text = "取り込まれた商品は価格・在庫が基幹システムと連携されます。";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 11);
            label2.Name = "label2";
            label2.Size = new Size(720, 32);
            label2.TabIndex = 0;
            label2.Text = "Bカート側で登録/変更された商品の情報を連携用システムに取り込みます。";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtIDOnlly);
            groupBox1.Controls.Add(txtIDRangeTo);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtIDRangeFrom);
            groupBox1.Controls.Add(rdoIDOnly);
            groupBox1.Controls.Add(rdoIDRange);
            groupBox1.Location = new Point(13, 200);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(849, 186);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "取込方法";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(644, 52);
            label6.Name = "label6";
            label6.Size = new Size(38, 32);
            label6.TabIndex = 24;
            label6.Text = "～";
            // 
            // txtIDOnlly
            // 
            txtIDOnlly.Location = new Point(499, 144);
            txtIDOnlly.Name = "txtIDOnlly";
            txtIDOnlly.Size = new Size(139, 39);
            txtIDOnlly.TabIndex = 23;
            // 
            // txtIDRangeTo
            // 
            txtIDRangeTo.Location = new Point(688, 49);
            txtIDRangeTo.Name = "txtIDRangeTo";
            txtIDRangeTo.Size = new Size(139, 39);
            txtIDRangeTo.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(344, 146);
            label5.Name = "label5";
            label5.Size = new Size(149, 32);
            label5.TabIndex = 21;
            label5.Text = "Bカート商品ID";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(344, 52);
            label4.Name = "label4";
            label4.Size = new Size(149, 32);
            label4.TabIndex = 20;
            label4.Text = "Bカート商品ID";
            // 
            // txtIDRangeFrom
            // 
            txtIDRangeFrom.Location = new Point(499, 50);
            txtIDRangeFrom.Name = "txtIDRangeFrom";
            txtIDRangeFrom.Size = new Size(139, 39);
            txtIDRangeFrom.TabIndex = 19;
            txtIDRangeFrom.Leave += txtIDRangeFrom_Leave;
            // 
            // rdoIDOnly
            // 
            rdoIDOnly.AutoSize = true;
            rdoIDOnly.Location = new Point(15, 144);
            rdoIDOnly.Name = "rdoIDOnly";
            rdoIDOnly.Size = new Size(263, 36);
            rdoIDOnly.TabIndex = 1;
            rdoIDOnly.Text = "指定の商品を取り込む";
            rdoIDOnly.UseVisualStyleBackColor = true;
            // 
            // rdoIDRange
            // 
            rdoIDRange.AutoSize = true;
            rdoIDRange.Checked = true;
            rdoIDRange.Location = new Point(15, 50);
            rdoIDRange.Name = "rdoIDRange";
            rdoIDRange.Size = new Size(278, 36);
            rdoIDRange.TabIndex = 0;
            rdoIDRange.TabStop = true;
            rdoIDRange.Text = "範囲を指定して取り込む";
            rdoIDRange.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(rdoOverrideON);
            groupBox2.Controls.Add(rdoOverrideOff);
            groupBox2.Location = new Point(868, 200);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(324, 186);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "上書き";
            // 
            // rdoOverrideON
            // 
            rdoOverrideON.AutoSize = true;
            rdoOverrideON.Location = new Point(17, 123);
            rdoOverrideON.Name = "rdoOverrideON";
            rdoOverrideON.Size = new Size(149, 36);
            rdoOverrideON.TabIndex = 1;
            rdoOverrideON.Text = "上書きする";
            rdoOverrideON.UseVisualStyleBackColor = true;
            // 
            // rdoOverrideOff
            // 
            rdoOverrideOff.AutoSize = true;
            rdoOverrideOff.Checked = true;
            rdoOverrideOff.Location = new Point(17, 50);
            rdoOverrideOff.Name = "rdoOverrideOff";
            rdoOverrideOff.Size = new Size(287, 36);
            rdoOverrideOff.TabIndex = 0;
            rdoOverrideOff.TabStop = true;
            rdoOverrideOff.Text = "上書きしない（スキップ）";
            rdoOverrideOff.UseVisualStyleBackColor = true;
            // 
            // btnDoImport
            // 
            btnDoImport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDoImport.Location = new Point(846, 392);
            btnDoImport.Name = "btnDoImport";
            btnDoImport.Size = new Size(347, 46);
            btnDoImport.TabIndex = 20;
            btnDoImport.Text = "Bカートの商品を取り込む";
            btnDoImport.UseVisualStyleBackColor = true;
            btnDoImport.Click += btnDoImport_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1019, 461);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(174, 46);
            btnClose.TabIndex = 21;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(560, 92);
            label7.Name = "label7";
            label7.Size = new Size(210, 32);
            label7.TabIndex = 25;
            label7.Text = "（最大100件まで）";
            // 
            // frmProductsImport
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 519);
            Controls.Add(btnClose);
            Controls.Add(btnDoImport);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "frmProductsImport";
            Text = "frmProductsImport";
            Load += frmProductsImport_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private GroupBox groupBox1;
        private TextBox txtIDOnlly;
        private TextBox txtIDRangeTo;
        private Label label5;
        private Label label4;
        private TextBox txtIDRangeFrom;
        private RadioButton rdoIDOnly;
        private RadioButton rdoIDRange;
        private Label label6;
        private GroupBox groupBox2;
        private RadioButton rdoOverrideON;
        private RadioButton rdoOverrideOff;
        private Button btnDoImport;
        private Button btnClose;
        private Label label7;
    }
}