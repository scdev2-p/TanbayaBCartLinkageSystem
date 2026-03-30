namespace BCart商品登録.Forms
{
    partial class frmProductDelete
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
            label1 = new Label();
            bsMainList = new BindingSource(components);
            groupBox1 = new GroupBox();
            btnDoDelete = new Button();
            rdoDelSet = new RadioButton();
            rdoDelProducts = new RadioButton();
            groupBox2 = new GroupBox();
            txtProductSetID = new TextBox();
            label4 = new Label();
            btnSearch = new Button();
            txtBarcode = new TextBox();
            txtProductsID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            dgvMainList = new DataGridView();
            chkSelect = new DataGridViewCheckBoxColumn();
            削除フラグDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            基本Bカート商品IDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セットBカートセットIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            基本商品名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セットカスタム項目1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット上代DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット単価DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット在庫DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            lblMessage = new Label();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)bsMainList).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(11, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(1694, 64);
            label1.TabIndex = 1;
            label1.Text = "Bカート商品の削除準備";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bsMainList
            // 
            bsMainList.DataMember = "bc登録済商品";
            bsMainList.DataSource = typeof(AppData.dsTnbToBCart);
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(btnDoDelete);
            groupBox1.Controls.Add(rdoDelSet);
            groupBox1.Controls.Add(rdoDelProducts);
            groupBox1.Location = new Point(1181, 77);
            groupBox1.Margin = new Padding(4, 2, 4, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 2, 4, 2);
            groupBox1.Size = new Size(524, 175);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "削除の準備";
            // 
            // btnDoDelete
            // 
            btnDoDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDoDelete.Location = new Point(230, 119);
            btnDoDelete.Margin = new Padding(4, 2, 4, 2);
            btnDoDelete.Name = "btnDoDelete";
            btnDoDelete.Size = new Size(288, 47);
            btnDoDelete.TabIndex = 12;
            btnDoDelete.Text = "削除可能にする";
            btnDoDelete.UseVisualStyleBackColor = true;
            btnDoDelete.Click += btnDoDelete_Click;
            // 
            // rdoDelSet
            // 
            rdoDelSet.AutoSize = true;
            rdoDelSet.Location = new Point(59, 77);
            rdoDelSet.Margin = new Padding(4, 2, 4, 2);
            rdoDelSet.Name = "rdoDelSet";
            rdoDelSet.Size = new Size(342, 36);
            rdoDelSet.TabIndex = 1;
            rdoDelSet.Text = "セット情報毎に削除可能にする";
            rdoDelSet.UseVisualStyleBackColor = true;
            // 
            // rdoDelProducts
            // 
            rdoDelProducts.AutoSize = true;
            rdoDelProducts.Checked = true;
            rdoDelProducts.Location = new Point(59, 38);
            rdoDelProducts.Margin = new Padding(4, 2, 4, 2);
            rdoDelProducts.Name = "rdoDelProducts";
            rdoDelProducts.Size = new Size(264, 36);
            rdoDelProducts.TabIndex = 0;
            rdoDelProducts.TabStop = true;
            rdoDelProducts.Text = "商品を削除可能にする";
            rdoDelProducts.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(txtProductSetID);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(btnSearch);
            groupBox2.Controls.Add(txtBarcode);
            groupBox2.Controls.Add(txtProductsID);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(11, 77);
            groupBox2.Margin = new Padding(4, 2, 4, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 2, 4, 2);
            groupBox2.Size = new Size(1164, 175);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "検索条件";
            // 
            // txtProductSetID
            // 
            txtProductSetID.Location = new Point(620, 36);
            txtProductSetID.Margin = new Padding(4, 2, 4, 2);
            txtProductSetID.Name = "txtProductSetID";
            txtProductSetID.Size = new Size(247, 39);
            txtProductSetID.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(461, 41);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(154, 32);
            label4.TabIndex = 18;
            label4.Text = "BカートセットID";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(921, 34);
            btnSearch.Margin = new Padding(4, 2, 4, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 47);
            btnSearch.TabIndex = 17;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(162, 92);
            txtBarcode.Margin = new Padding(4, 2, 4, 2);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(247, 39);
            txtBarcode.TabIndex = 16;
            // 
            // txtProductsID
            // 
            txtProductsID.Location = new Point(162, 36);
            txtProductsID.Margin = new Padding(4, 2, 4, 2);
            txtProductsID.Name = "txtProductsID";
            txtProductsID.Size = new Size(247, 39);
            txtProductsID.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 94);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 32);
            label3.TabIndex = 14;
            label3.Text = "バーコード";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 43);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(149, 32);
            label2.TabIndex = 13;
            label2.Text = "Bカート商品ID";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(dgvMainList);
            panel1.Controls.Add(lblMessage);
            panel1.Location = new Point(19, 256);
            panel1.Margin = new Padding(4, 2, 4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1686, 663);
            panel1.TabIndex = 14;
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { chkSelect, 削除フラグDataGridViewTextBoxColumn, 基本Bカート商品IDDataGridViewTextBoxColumn, セットBカートセットIDDataGridViewTextBoxColumn, 基本商品名DataGridViewTextBoxColumn, セットカスタム項目1DataGridViewTextBoxColumn, セット上代DataGridViewTextBoxColumn, セット単価DataGridViewTextBoxColumn, セット在庫DataGridViewTextBoxColumn });
            dgvMainList.DataSource = bsMainList;
            dgvMainList.Location = new Point(0, 60);
            dgvMainList.Margin = new Padding(4, 2, 4, 2);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(1684, 602);
            dgvMainList.TabIndex = 13;
            // 
            // chkSelect
            // 
            chkSelect.HeaderText = "選択";
            chkSelect.MinimumWidth = 10;
            chkSelect.Name = "chkSelect";
            chkSelect.Width = 80;
            // 
            // 削除フラグDataGridViewTextBoxColumn
            // 
            削除フラグDataGridViewTextBoxColumn.DataPropertyName = "削除フラグ";
            削除フラグDataGridViewTextBoxColumn.HeaderText = "削除";
            削除フラグDataGridViewTextBoxColumn.MinimumWidth = 10;
            削除フラグDataGridViewTextBoxColumn.Name = "削除フラグDataGridViewTextBoxColumn";
            削除フラグDataGridViewTextBoxColumn.Width = 80;
            // 
            // 基本Bカート商品IDDataGridViewTextBoxColumn
            // 
            基本Bカート商品IDDataGridViewTextBoxColumn.DataPropertyName = "基本_Bカート商品ID";
            基本Bカート商品IDDataGridViewTextBoxColumn.HeaderText = "商品ID";
            基本Bカート商品IDDataGridViewTextBoxColumn.MinimumWidth = 10;
            基本Bカート商品IDDataGridViewTextBoxColumn.Name = "基本Bカート商品IDDataGridViewTextBoxColumn";
            基本Bカート商品IDDataGridViewTextBoxColumn.Width = 150;
            // 
            // セットBカートセットIDDataGridViewTextBoxColumn
            // 
            セットBカートセットIDDataGridViewTextBoxColumn.DataPropertyName = "セット_BカートセットID";
            セットBカートセットIDDataGridViewTextBoxColumn.HeaderText = "セットID";
            セットBカートセットIDDataGridViewTextBoxColumn.MinimumWidth = 10;
            セットBカートセットIDDataGridViewTextBoxColumn.Name = "セットBカートセットIDDataGridViewTextBoxColumn";
            セットBカートセットIDDataGridViewTextBoxColumn.Width = 150;
            // 
            // 基本商品名DataGridViewTextBoxColumn
            // 
            基本商品名DataGridViewTextBoxColumn.DataPropertyName = "基本_商品名";
            基本商品名DataGridViewTextBoxColumn.HeaderText = "商品名";
            基本商品名DataGridViewTextBoxColumn.MinimumWidth = 10;
            基本商品名DataGridViewTextBoxColumn.Name = "基本商品名DataGridViewTextBoxColumn";
            基本商品名DataGridViewTextBoxColumn.Width = 600;
            // 
            // セットカスタム項目1DataGridViewTextBoxColumn
            // 
            セットカスタム項目1DataGridViewTextBoxColumn.DataPropertyName = "セット_カスタム項目1";
            セットカスタム項目1DataGridViewTextBoxColumn.HeaderText = "バーコード";
            セットカスタム項目1DataGridViewTextBoxColumn.MinimumWidth = 10;
            セットカスタム項目1DataGridViewTextBoxColumn.Name = "セットカスタム項目1DataGridViewTextBoxColumn";
            セットカスタム項目1DataGridViewTextBoxColumn.Width = 200;
            // 
            // セット上代DataGridViewTextBoxColumn
            // 
            セット上代DataGridViewTextBoxColumn.DataPropertyName = "セット_上代";
            セット上代DataGridViewTextBoxColumn.HeaderText = "上代";
            セット上代DataGridViewTextBoxColumn.MinimumWidth = 10;
            セット上代DataGridViewTextBoxColumn.Name = "セット上代DataGridViewTextBoxColumn";
            セット上代DataGridViewTextBoxColumn.Width = 150;
            // 
            // セット単価DataGridViewTextBoxColumn
            // 
            セット単価DataGridViewTextBoxColumn.DataPropertyName = "セット_単価";
            セット単価DataGridViewTextBoxColumn.HeaderText = "単価";
            セット単価DataGridViewTextBoxColumn.MinimumWidth = 10;
            セット単価DataGridViewTextBoxColumn.Name = "セット単価DataGridViewTextBoxColumn";
            セット単価DataGridViewTextBoxColumn.Width = 150;
            // 
            // セット在庫DataGridViewTextBoxColumn
            // 
            セット在庫DataGridViewTextBoxColumn.DataPropertyName = "セット_在庫";
            セット在庫DataGridViewTextBoxColumn.HeaderText = "在庫";
            セット在庫DataGridViewTextBoxColumn.MinimumWidth = 10;
            セット在庫DataGridViewTextBoxColumn.Name = "セット在庫DataGridViewTextBoxColumn";
            セット在庫DataGridViewTextBoxColumn.Width = 150;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblMessage.ForeColor = Color.Red;
            lblMessage.Location = new Point(4, 0);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(691, 58);
            lblMessage.TabIndex = 12;
            lblMessage.Text = "メッセージ";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1528, 926);
            btnClose.Margin = new Padding(4, 2, 4, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(175, 47);
            btnClose.TabIndex = 14;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmProductDelete
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1718, 996);
            Controls.Add(btnClose);
            Controls.Add(panel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(4, 2, 4, 2);
            Name = "frmProductDelete";
            Text = "frmProductsDelete";
            Load += frmProductDelete_Load;
            ((System.ComponentModel.ISupportInitialize)bsMainList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rdoDelSet;
        private RadioButton rdoDelProducts;
        private BindingSource bsMainList;
        private GroupBox groupBox2;
        private TextBox txtProductSetID;
        private Label label4;
        private Button btnSearch;
        private TextBox txtBarcode;
        private TextBox txtProductsID;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private DataGridView dgvMainList;
        private DataGridViewCheckBoxColumn chkSelect;
        private DataGridViewTextBoxColumn 削除フラグDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 基本Bカート商品IDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セットBカートセットIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 基本商品名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セットカスタム項目1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット上代DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット単価DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット在庫DataGridViewTextBoxColumn;
        private Label lblMessage;
        private Button btnClose;
        private Button btnDoDelete;
    }
}