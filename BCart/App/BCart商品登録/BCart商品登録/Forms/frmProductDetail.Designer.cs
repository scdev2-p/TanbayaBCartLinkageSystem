namespace BCart商品登録.Forms
{
    partial class frmProductDetail
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            dgvMainList = new DataGridView();
            bsMainList = new BindingSource(components);
            btnClose = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            lblTnbProductsNo = new Label();
            lblBarcode = new Label();
            lblFloor = new Label();
            lblOversea = new Label();
            lblNetNG = new Label();
            lblProductsName = new Label();
            lblRegisted = new Label();
            btnDelete = new DataGridViewButtonColumn();
            削除フラグ = new DataGridViewTextBoxColumn();
            tnb商品管理番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セットカスタム項目1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            基本商品名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            基本Bカート商品IDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セットBカートセットIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット上代DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット単価DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット在庫DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            eC移行フラグDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsMainList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 393);
            label1.Name = "label1";
            label1.Size = new Size(343, 32);
            label1.TabIndex = 0;
            label1.Text = "Bカート登録済  バーコード重複商品";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(1512, 64);
            label2.TabIndex = 1;
            label2.Text = "商品詳細情報";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { btnDelete, 削除フラグ, tnb商品管理番号DataGridViewTextBoxColumn, セットカスタム項目1DataGridViewTextBoxColumn, 基本商品名DataGridViewTextBoxColumn, 基本Bカート商品IDDataGridViewTextBoxColumn, セットBカートセットIDDataGridViewTextBoxColumn, セット上代DataGridViewTextBoxColumn, セット単価DataGridViewTextBoxColumn, セット在庫DataGridViewTextBoxColumn, eC移行フラグDataGridViewCheckBoxColumn });
            dgvMainList.DataSource = bsMainList;
            dgvMainList.Location = new Point(12, 428);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(1512, 348);
            dgvMainList.TabIndex = 2;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            // 
            // bsMainList
            // 
            bsMainList.DataMember = "S_バーコード重複商品抽出";
            bsMainList.DataSource = typeof(AppData.dsTnbToBCart);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1350, 795);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(174, 46);
            btnClose.TabIndex = 5;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Gray;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 89);
            label3.Name = "label3";
            label3.Size = new Size(201, 42);
            label3.TabIndex = 7;
            label3.Text = "商品管理番号";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.Gray;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 131);
            label4.Name = "label4";
            label4.Size = new Size(201, 42);
            label4.TabIndex = 8;
            label4.Text = "バーコード";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.Gray;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 173);
            label5.Name = "label5";
            label5.Size = new Size(201, 42);
            label5.TabIndex = 10;
            label5.Text = "商品名";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.Gray;
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 215);
            label6.Name = "label6";
            label6.Size = new Size(201, 42);
            label6.TabIndex = 11;
            label6.Text = "フロア";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.BackColor = Color.Gray;
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.ForeColor = Color.White;
            label7.Location = new Point(12, 257);
            label7.Name = "label7";
            label7.Size = new Size(201, 42);
            label7.TabIndex = 12;
            label7.Text = "海外禁止";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.Gray;
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.ForeColor = Color.White;
            label8.Location = new Point(12, 299);
            label8.Name = "label8";
            label8.Size = new Size(201, 42);
            label8.TabIndex = 13;
            label8.Text = "Net販売NG";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTnbProductsNo
            // 
            lblTnbProductsNo.BackColor = SystemColors.Control;
            lblTnbProductsNo.BorderStyle = BorderStyle.Fixed3D;
            lblTnbProductsNo.ForeColor = Color.Black;
            lblTnbProductsNo.Location = new Point(221, 89);
            lblTnbProductsNo.Name = "lblTnbProductsNo";
            lblTnbProductsNo.Size = new Size(201, 42);
            lblTnbProductsNo.TabIndex = 14;
            lblTnbProductsNo.Text = "xxxx";
            lblTnbProductsNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBarcode
            // 
            lblBarcode.BackColor = SystemColors.Control;
            lblBarcode.BorderStyle = BorderStyle.Fixed3D;
            lblBarcode.ForeColor = Color.Black;
            lblBarcode.Location = new Point(219, 131);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(201, 42);
            lblBarcode.TabIndex = 15;
            lblBarcode.Text = "xxxx";
            lblBarcode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFloor
            // 
            lblFloor.BackColor = SystemColors.Control;
            lblFloor.BorderStyle = BorderStyle.Fixed3D;
            lblFloor.ForeColor = Color.Black;
            lblFloor.Location = new Point(221, 215);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(201, 42);
            lblFloor.TabIndex = 16;
            lblFloor.Text = "xxxx";
            lblFloor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOversea
            // 
            lblOversea.BackColor = SystemColors.Control;
            lblOversea.BorderStyle = BorderStyle.Fixed3D;
            lblOversea.ForeColor = Color.Black;
            lblOversea.Location = new Point(219, 257);
            lblOversea.Name = "lblOversea";
            lblOversea.Size = new Size(201, 42);
            lblOversea.TabIndex = 17;
            lblOversea.Text = "xxxx";
            lblOversea.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNetNG
            // 
            lblNetNG.BackColor = SystemColors.Control;
            lblNetNG.BorderStyle = BorderStyle.Fixed3D;
            lblNetNG.ForeColor = Color.Black;
            lblNetNG.Location = new Point(219, 299);
            lblNetNG.Name = "lblNetNG";
            lblNetNG.Size = new Size(201, 42);
            lblNetNG.TabIndex = 18;
            lblNetNG.Text = "xxxx";
            lblNetNG.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProductsName
            // 
            lblProductsName.BackColor = SystemColors.Control;
            lblProductsName.BorderStyle = BorderStyle.Fixed3D;
            lblProductsName.ForeColor = Color.Black;
            lblProductsName.Location = new Point(221, 173);
            lblProductsName.Name = "lblProductsName";
            lblProductsName.Size = new Size(650, 42);
            lblProductsName.TabIndex = 19;
            lblProductsName.Text = "xxxx";
            lblProductsName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRegisted
            // 
            lblRegisted.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblRegisted.AutoSize = true;
            lblRegisted.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblRegisted.ForeColor = Color.Red;
            lblRegisted.Location = new Point(1225, 173);
            lblRegisted.Name = "lblRegisted";
            lblRegisted.Size = new Size(299, 65);
            lblRegisted.TabIndex = 22;
            lblRegisted.Text = "Bカート登録済";
            // 
            // btnDelete
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "削除";
            btnDelete.DefaultCellStyle = dataGridViewCellStyle1;
            btnDelete.HeaderText = "削除";
            btnDelete.MinimumWidth = 10;
            btnDelete.Name = "btnDelete";
            btnDelete.Visible = false;
            btnDelete.Width = 200;
            // 
            // 削除フラグ
            // 
            削除フラグ.DataPropertyName = "削除フラグ";
            削除フラグ.HeaderText = "削除フラグ";
            削除フラグ.MinimumWidth = 10;
            削除フラグ.Name = "削除フラグ";
            削除フラグ.Width = 220;
            // 
            // tnb商品管理番号DataGridViewTextBoxColumn
            // 
            tnb商品管理番号DataGridViewTextBoxColumn.DataPropertyName = "tnb商品管理番号";
            tnb商品管理番号DataGridViewTextBoxColumn.HeaderText = "商品管理番号";
            tnb商品管理番号DataGridViewTextBoxColumn.MinimumWidth = 10;
            tnb商品管理番号DataGridViewTextBoxColumn.Name = "tnb商品管理番号DataGridViewTextBoxColumn";
            tnb商品管理番号DataGridViewTextBoxColumn.Width = 220;
            // 
            // セットカスタム項目1DataGridViewTextBoxColumn
            // 
            セットカスタム項目1DataGridViewTextBoxColumn.DataPropertyName = "セット_カスタム項目1";
            セットカスタム項目1DataGridViewTextBoxColumn.HeaderText = "バーコード";
            セットカスタム項目1DataGridViewTextBoxColumn.MinimumWidth = 10;
            セットカスタム項目1DataGridViewTextBoxColumn.Name = "セットカスタム項目1DataGridViewTextBoxColumn";
            セットカスタム項目1DataGridViewTextBoxColumn.Width = 200;
            // 
            // 基本商品名DataGridViewTextBoxColumn
            // 
            基本商品名DataGridViewTextBoxColumn.DataPropertyName = "基本_商品名";
            基本商品名DataGridViewTextBoxColumn.HeaderText = "基本_商品名";
            基本商品名DataGridViewTextBoxColumn.MinimumWidth = 10;
            基本商品名DataGridViewTextBoxColumn.Name = "基本商品名DataGridViewTextBoxColumn";
            基本商品名DataGridViewTextBoxColumn.Width = 600;
            // 
            // 基本Bカート商品IDDataGridViewTextBoxColumn
            // 
            基本Bカート商品IDDataGridViewTextBoxColumn.DataPropertyName = "基本_Bカート商品ID";
            基本Bカート商品IDDataGridViewTextBoxColumn.HeaderText = "Bカート商品ID";
            基本Bカート商品IDDataGridViewTextBoxColumn.MinimumWidth = 10;
            基本Bカート商品IDDataGridViewTextBoxColumn.Name = "基本Bカート商品IDDataGridViewTextBoxColumn";
            基本Bカート商品IDDataGridViewTextBoxColumn.Width = 220;
            // 
            // セットBカートセットIDDataGridViewTextBoxColumn
            // 
            セットBカートセットIDDataGridViewTextBoxColumn.DataPropertyName = "セット_BカートセットID";
            セットBカートセットIDDataGridViewTextBoxColumn.HeaderText = "BカートセットID";
            セットBカートセットIDDataGridViewTextBoxColumn.MinimumWidth = 10;
            セットBカートセットIDDataGridViewTextBoxColumn.Name = "セットBカートセットIDDataGridViewTextBoxColumn";
            セットBカートセットIDDataGridViewTextBoxColumn.Width = 200;
            // 
            // セット上代DataGridViewTextBoxColumn
            // 
            セット上代DataGridViewTextBoxColumn.DataPropertyName = "セット_上代";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            セット上代DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            セット上代DataGridViewTextBoxColumn.HeaderText = "上代";
            セット上代DataGridViewTextBoxColumn.MinimumWidth = 10;
            セット上代DataGridViewTextBoxColumn.Name = "セット上代DataGridViewTextBoxColumn";
            セット上代DataGridViewTextBoxColumn.Width = 200;
            // 
            // セット単価DataGridViewTextBoxColumn
            // 
            セット単価DataGridViewTextBoxColumn.DataPropertyName = "セット_単価";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            セット単価DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            セット単価DataGridViewTextBoxColumn.HeaderText = "単価";
            セット単価DataGridViewTextBoxColumn.MinimumWidth = 10;
            セット単価DataGridViewTextBoxColumn.Name = "セット単価DataGridViewTextBoxColumn";
            セット単価DataGridViewTextBoxColumn.Width = 200;
            // 
            // セット在庫DataGridViewTextBoxColumn
            // 
            セット在庫DataGridViewTextBoxColumn.DataPropertyName = "セット_在庫";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            セット在庫DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            セット在庫DataGridViewTextBoxColumn.HeaderText = "在庫";
            セット在庫DataGridViewTextBoxColumn.MinimumWidth = 10;
            セット在庫DataGridViewTextBoxColumn.Name = "セット在庫DataGridViewTextBoxColumn";
            セット在庫DataGridViewTextBoxColumn.Width = 200;
            // 
            // eC移行フラグDataGridViewCheckBoxColumn
            // 
            eC移行フラグDataGridViewCheckBoxColumn.DataPropertyName = "EC移行フラグ";
            eC移行フラグDataGridViewCheckBoxColumn.HeaderText = "EC移行";
            eC移行フラグDataGridViewCheckBoxColumn.MinimumWidth = 10;
            eC移行フラグDataGridViewCheckBoxColumn.Name = "eC移行フラグDataGridViewCheckBoxColumn";
            eC移行フラグDataGridViewCheckBoxColumn.Width = 200;
            // 
            // frmProductDetail
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1536, 853);
            Controls.Add(lblRegisted);
            Controls.Add(lblProductsName);
            Controls.Add(lblNetNG);
            Controls.Add(lblOversea);
            Controls.Add(lblFloor);
            Controls.Add(lblBarcode);
            Controls.Add(lblTnbProductsNo);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnClose);
            Controls.Add(dgvMainList);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmProductDetail";
            Text = "frmProductDetail";
            FormClosing += frmProductDetail_FormClosing;
            Load += frmProductDetail_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsMainList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DataGridView dgvMainList;
        private Button btnClose;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblTnbProductsNo;
        private Label lblBarcode;
        private Label lblFloor;
        private Label lblOversea;
        private Label lblNetNG;
        private BindingSource bsMainList;
        private Label lblProductsName;
        private Label lblRegisted;
        private DataGridViewButtonColumn btnDelete;
        private DataGridViewTextBoxColumn 削除フラグ;
        private DataGridViewTextBoxColumn tnb商品管理番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セットカスタム項目1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 基本商品名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 基本Bカート商品IDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セットBカートセットIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット上代DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット単価DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット在庫DataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn eC移行フラグDataGridViewCheckBoxColumn;
    }
}