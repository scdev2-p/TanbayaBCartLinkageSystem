namespace BCart商品登録.Forms.SubForms
{
    partial class frmCheckBcBarcode
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
            dgvBarcodeList = new DataGridView();
            btnClose = new Button();
            lblMessage = new Label();
            label1 = new Label();
            lblBarcode = new Label();
            bcProductID = new DataGridViewTextBoxColumn();
            BC商品名 = new DataGridViewTextBoxColumn();
            BCSetID = new DataGridViewTextBoxColumn();
            BCSetName = new DataGridViewTextBoxColumn();
            bcProductSetCode = new DataGridViewTextBoxColumn();
            BCJodai = new DataGridViewTextBoxColumn();
            BCStock = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBarcodeList).BeginInit();
            SuspendLayout();
            // 
            // dgvBarcodeList
            // 
            dgvBarcodeList.AllowUserToAddRows = false;
            dgvBarcodeList.AllowUserToDeleteRows = false;
            dgvBarcodeList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBarcodeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarcodeList.Columns.AddRange(new DataGridViewColumn[] { bcProductID, BC商品名, BCSetID, BCSetName, bcProductSetCode, BCJodai, BCStock });
            dgvBarcodeList.Location = new Point(12, 163);
            dgvBarcodeList.Name = "dgvBarcodeList";
            dgvBarcodeList.ReadOnly = true;
            dgvBarcodeList.RowHeadersVisible = false;
            dgvBarcodeList.RowHeadersWidth = 82;
            dgvBarcodeList.Size = new Size(1244, 247);
            dgvBarcodeList.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom;
            btnClose.Location = new Point(564, 437);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 46);
            btnClose.TabIndex = 1;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(12, 9);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(1278, 88);
            lblMessage.TabIndex = 2;
            lblMessage.Text = "※ 指定のバーコードはBカートの以下の商品にも使われています。\r\n確認してください。";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 112);
            label1.Name = "label1";
            label1.Size = new Size(97, 32);
            label1.TabIndex = 3;
            label1.Text = "バーコード";
            // 
            // lblBarcode
            // 
            lblBarcode.BorderStyle = BorderStyle.Fixed3D;
            lblBarcode.Location = new Point(125, 106);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(156, 44);
            lblBarcode.TabIndex = 4;
            lblBarcode.Text = "label2";
            lblBarcode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bcProductID
            // 
            bcProductID.DataPropertyName = "ProductsID";
            bcProductID.HeaderText = "BC商品ID";
            bcProductID.MinimumWidth = 10;
            bcProductID.Name = "bcProductID";
            bcProductID.ReadOnly = true;
            bcProductID.Width = 150;
            // 
            // BC商品名
            // 
            BC商品名.DataPropertyName = "ProductsName";
            BC商品名.HeaderText = "商品名";
            BC商品名.MinimumWidth = 10;
            BC商品名.Name = "BC商品名";
            BC商品名.ReadOnly = true;
            BC商品名.Width = 400;
            // 
            // BCSetID
            // 
            BCSetID.DataPropertyName = "ProductSetID";
            BCSetID.HeaderText = "セットID";
            BCSetID.MinimumWidth = 10;
            BCSetID.Name = "BCSetID";
            BCSetID.ReadOnly = true;
            BCSetID.Width = 150;
            // 
            // BCSetName
            // 
            BCSetName.DataPropertyName = "ProductSetName";
            BCSetName.HeaderText = "セット名";
            BCSetName.MinimumWidth = 10;
            BCSetName.Name = "BCSetName";
            BCSetName.ReadOnly = true;
            BCSetName.Width = 300;
            // 
            // bcProductSetCode
            // 
            bcProductSetCode.DataPropertyName = "ProductSetCD";
            bcProductSetCode.HeaderText = "型番";
            bcProductSetCode.MinimumWidth = 10;
            bcProductSetCode.Name = "bcProductSetCode";
            bcProductSetCode.ReadOnly = true;
            bcProductSetCode.Width = 200;
            // 
            // BCJodai
            // 
            BCJodai.DataPropertyName = "Jodai";
            BCJodai.HeaderText = "上代";
            BCJodai.MinimumWidth = 10;
            BCJodai.Name = "BCJodai";
            BCJodai.ReadOnly = true;
            BCJodai.Width = 150;
            // 
            // BCStock
            // 
            BCStock.DataPropertyName = "Stock";
            BCStock.HeaderText = "在庫";
            BCStock.MinimumWidth = 10;
            BCStock.Name = "BCStock";
            BCStock.ReadOnly = true;
            BCStock.Width = 150;
            // 
            // frmCheckBcBarcode
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 495);
            Controls.Add(lblBarcode);
            Controls.Add(label1);
            Controls.Add(lblMessage);
            Controls.Add(btnClose);
            Controls.Add(dgvBarcodeList);
            Name = "frmCheckBcBarcode";
            Text = "Bカートバーコード確認";
            Load += frmCheckBcBarcode_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBarcodeList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvBarcodeList;
        private Button btnClose;
        private Label lblMessage;
        private Label label1;
        private Label lblBarcode;
        private DataGridViewTextBoxColumn bcProductID;
        private DataGridViewTextBoxColumn BC商品名;
        private DataGridViewTextBoxColumn BCSetID;
        private DataGridViewTextBoxColumn BCSetName;
        private DataGridViewTextBoxColumn bcProductSetCode;
        private DataGridViewTextBoxColumn BCJodai;
        private DataGridViewTextBoxColumn BCStock;
    }
}