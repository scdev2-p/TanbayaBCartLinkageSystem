namespace BCart商品登録.Forms
{
    partial class frmProductSetRegist
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
            lblProductsID = new Label();
            lblName = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            txtSetName = new TextBox();
            txtBarcode = new TextBox();
            lblJyodai = new Label();
            label12 = new Label();
            btnRegist = new Button();
            btnClose = new Button();
            lblSetID = new Label();
            label14 = new Label();
            label5 = new Label();
            lblStock = new Label();
            lblNoData = new Label();
            label6 = new Label();
            txtSetNo = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(30, 14);
            label1.Name = "label1";
            label1.Size = new Size(156, 50);
            label1.TabIndex = 0;
            label1.Text = "Bカート商品ID";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProductsID
            // 
            lblProductsID.BorderStyle = BorderStyle.Fixed3D;
            lblProductsID.Location = new Point(192, 14);
            lblProductsID.Name = "lblProductsID";
            lblProductsID.Size = new Size(146, 50);
            lblProductsID.TabIndex = 1;
            lblProductsID.Text = "label2";
            lblProductsID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            lblName.BorderStyle = BorderStyle.Fixed3D;
            lblName.Location = new Point(192, 73);
            lblName.Name = "lblName";
            lblName.Size = new Size(562, 50);
            lblName.TabIndex = 3;
            lblName.Text = "label2";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Location = new Point(30, 73);
            label3.Name = "label3";
            label3.Size = new Size(156, 50);
            label3.TabIndex = 2;
            label3.Text = "商品名";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Location = new Point(30, 197);
            label2.Name = "label2";
            label2.Size = new Size(156, 50);
            label2.TabIndex = 4;
            label2.Text = "セット名";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Location = new Point(30, 247);
            label4.Name = "label4";
            label4.Size = new Size(156, 50);
            label4.TabIndex = 5;
            label4.Text = "バーコード";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSetName
            // 
            txtSetName.Location = new Point(192, 203);
            txtSetName.Name = "txtSetName";
            txtSetName.Size = new Size(562, 39);
            txtSetName.TabIndex = 6;
            // 
            // txtBarcode
            // 
            txtBarcode.BackColor = Color.FromArgb(255, 255, 192);
            txtBarcode.Location = new Point(192, 253);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(226, 39);
            txtBarcode.TabIndex = 7;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            txtBarcode.KeyPress += txtBarcode_KeyPress;
            // 
            // lblJyodai
            // 
            lblJyodai.BorderStyle = BorderStyle.Fixed3D;
            lblJyodai.Location = new Point(192, 369);
            lblJyodai.Name = "lblJyodai";
            lblJyodai.Size = new Size(132, 50);
            lblJyodai.TabIndex = 13;
            lblJyodai.Text = "label2";
            lblJyodai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            label12.Location = new Point(30, 371);
            label12.Name = "label12";
            label12.Size = new Size(156, 50);
            label12.TabIndex = 12;
            label12.Text = "上代";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnRegist
            // 
            btnRegist.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegist.Location = new Point(673, 353);
            btnRegist.Name = "btnRegist";
            btnRegist.Size = new Size(333, 46);
            btnRegist.TabIndex = 16;
            btnRegist.Text = "追加登録/変更";
            btnRegist.UseVisualStyleBackColor = true;
            btnRegist.Click += btnRegist_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(856, 440);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 46);
            btnClose.TabIndex = 17;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblSetID
            // 
            lblSetID.BorderStyle = BorderStyle.Fixed3D;
            lblSetID.Location = new Point(192, 136);
            lblSetID.Name = "lblSetID";
            lblSetID.Size = new Size(146, 50);
            lblSetID.TabIndex = 19;
            lblSetID.Text = "label2";
            lblSetID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Location = new Point(30, 136);
            label14.Name = "label14";
            label14.Size = new Size(156, 50);
            label14.TabIndex = 18;
            label14.Text = "セットID";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Location = new Point(30, 430);
            label5.Name = "label5";
            label5.Size = new Size(156, 50);
            label5.TabIndex = 20;
            label5.Text = "在庫";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStock
            // 
            lblStock.BorderStyle = BorderStyle.Fixed3D;
            lblStock.Location = new Point(192, 430);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(146, 50);
            lblStock.TabIndex = 21;
            lblStock.Text = "label2";
            lblStock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNoData
            // 
            lblNoData.AutoSize = true;
            lblNoData.ForeColor = Color.Red;
            lblNoData.Location = new Point(424, 256);
            lblNoData.Name = "lblNoData";
            lblNoData.Size = new Size(260, 32);
            lblNoData.TabIndex = 22;
            lblNoData.Text = "※ 商品マスタにありません";
            // 
            // label6
            // 
            label6.Location = new Point(30, 305);
            label6.Name = "label6";
            label6.Size = new Size(156, 50);
            label6.TabIndex = 23;
            label6.Text = "品番";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSetNo
            // 
            txtSetNo.Location = new Point(192, 311);
            txtSetNo.Name = "txtSetNo";
            txtSetNo.Size = new Size(226, 39);
            txtSetNo.TabIndex = 24;
            // 
            // frmProductSetRegist
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 498);
            Controls.Add(txtSetNo);
            Controls.Add(label6);
            Controls.Add(lblNoData);
            Controls.Add(lblStock);
            Controls.Add(label5);
            Controls.Add(lblSetID);
            Controls.Add(label14);
            Controls.Add(btnClose);
            Controls.Add(btnRegist);
            Controls.Add(lblJyodai);
            Controls.Add(label12);
            Controls.Add(txtBarcode);
            Controls.Add(txtSetName);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(lblName);
            Controls.Add(label3);
            Controls.Add(lblProductsID);
            Controls.Add(label1);
            Name = "frmProductSetRegist";
            Text = "frmProductSetAdd";
            Load += frmProductSetRegist_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblProductsID;
        private Label lblName;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox txtSetName;
        private TextBox txtBarcode;
        private Label lblJyodai;
        private Label label12;
        private Button btnRegist;
        private Button btnClose;
        private Label lblSetID;
        private Label label14;
        private Label label5;
        private Label lblStock;
        private Label lblNoData;
        private Label label6;
        private TextBox txtSetNo;
    }
}