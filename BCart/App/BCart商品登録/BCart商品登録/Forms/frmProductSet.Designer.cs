namespace BCart商品登録.Forms
{
    partial class frmProductSet
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
            txtProductSetID = new TextBox();
            label4 = new Label();
            btnSearch = new Button();
            txtBarcode = new TextBox();
            txtProductsID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            label1 = new Label();
            btnClose = new Button();
            bsMainList = new BindingSource(components);
            dgvMainList = new DataGridView();
            btnAdd = new DataGridViewButtonColumn();
            btnChange = new DataGridViewButtonColumn();
            削除フラグ = new DataGridViewTextBoxColumn();
            基本Bカート商品IDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セットBカートセットIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            基本商品名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セットカスタム項目1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット_セット名 = new DataGridViewTextBoxColumn();
            セット上代DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット単価DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            セット在庫DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bsMainList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            SuspendLayout();
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
            label4.Location = new Point(462, 40);
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
            label3.Location = new Point(10, 93);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(97, 32);
            label3.TabIndex = 14;
            label3.Text = "バーコード";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 42);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(149, 32);
            label2.TabIndex = 13;
            label2.Text = "Bカート商品ID";
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
            groupBox2.Location = new Point(13, 75);
            groupBox2.Margin = new Padding(4, 2, 4, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 2, 4, 2);
            groupBox2.Size = new Size(1364, 147);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            groupBox2.Text = "検索条件";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(13, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(1630, 64);
            label1.TabIndex = 15;
            label1.Text = "Bカート商品のセット情報登録";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1468, 689);
            btnClose.Margin = new Padding(4, 2, 4, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(175, 47);
            btnClose.TabIndex = 17;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // bsMainList
            // 
            bsMainList.DataMember = "bc登録済商品";
            bsMainList.DataSource = typeof(AppData.dsTnbToBCart);
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { btnAdd, btnChange, 削除フラグ, 基本Bカート商品IDDataGridViewTextBoxColumn, セットBカートセットIDDataGridViewTextBoxColumn, 基本商品名DataGridViewTextBoxColumn, セットカスタム項目1DataGridViewTextBoxColumn, セット_セット名, セット上代DataGridViewTextBoxColumn, セット単価DataGridViewTextBoxColumn, セット在庫DataGridViewTextBoxColumn });
            dgvMainList.DataSource = bsMainList;
            dgvMainList.Location = new Point(13, 239);
            dgvMainList.Margin = new Padding(4, 2, 4, 2);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(1630, 446);
            dgvMainList.TabIndex = 18;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            // 
            // btnAdd
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "追加";
            btnAdd.DefaultCellStyle = dataGridViewCellStyle1;
            btnAdd.HeaderText = "追加";
            btnAdd.MinimumWidth = 10;
            btnAdd.Name = "btnAdd";
            btnAdd.Resizable = DataGridViewTriState.True;
            btnAdd.Width = 80;
            // 
            // btnChange
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "変更";
            btnChange.DefaultCellStyle = dataGridViewCellStyle2;
            btnChange.HeaderText = "変更";
            btnChange.MinimumWidth = 10;
            btnChange.Name = "btnChange";
            btnChange.Resizable = DataGridViewTriState.True;
            btnChange.SortMode = DataGridViewColumnSortMode.Automatic;
            btnChange.Width = 80;
            // 
            // 削除フラグ
            // 
            削除フラグ.DataPropertyName = "削除フラグ";
            削除フラグ.HeaderText = "削除";
            削除フラグ.MinimumWidth = 10;
            削除フラグ.Name = "削除フラグ";
            削除フラグ.Width = 80;
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
            // セット_セット名
            // 
            セット_セット名.DataPropertyName = "セット_セット名";
            セット_セット名.HeaderText = "セット名";
            セット_セット名.MinimumWidth = 10;
            セット_セット名.Name = "セット_セット名";
            セット_セット名.Width = 600;
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
            // frmProductSet
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1656, 756);
            Controls.Add(dgvMainList);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Name = "frmProductSet";
            Text = "frmProductSet";
            Load += frmProductSet_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bsMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtProductSetID;
        private Label label4;
        private Button btnSearch;
        private TextBox txtBarcode;
        private TextBox txtProductsID;
        private Label label3;
        private Label label2;
        private GroupBox groupBox2;
        private Label label1;
        private Button btnClose;
        private BindingSource bsMainList;
        private DataGridView dgvMainList;
        private DataGridViewButtonColumn btnAdd;
        private DataGridViewButtonColumn btnChange;
        private DataGridViewTextBoxColumn 削除フラグ;
        private DataGridViewTextBoxColumn 基本Bカート商品IDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セットBカートセットIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 基本商品名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セットカスタム項目1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット_セット名;
        private DataGridViewTextBoxColumn セット上代DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット単価DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn セット在庫DataGridViewTextBoxColumn;
    }
}