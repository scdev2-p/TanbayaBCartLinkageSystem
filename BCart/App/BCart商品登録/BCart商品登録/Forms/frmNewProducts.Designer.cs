namespace BCart商品登録.Forms
{
    partial class frmNewProducts
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            label1 = new Label();
            bsNewProductsList = new BindingSource(components);
            btnClose = new Button();
            groupBox1 = new GroupBox();
            txtFloorCD = new TextBox();
            label8 = new Label();
            lblWeit = new Label();
            txtJyodai = new TextBox();
            txtMakerCD = new TextBox();
            label7 = new Label();
            label6 = new Label();
            txtBarcode = new TextBox();
            label5 = new Label();
            label3 = new Label();
            txtLimit = new TextBox();
            label2 = new Label();
            btnSearch = new Button();
            dgvMainList = new DataGridView();
            chkSelect = new DataGridViewCheckBoxColumn();
            btnDetail = new DataGridViewButtonColumn();
            商品管理番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            バーコードDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            バーコード重複 = new DataGridViewTextBoxColumn();
            商品名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            仕入先コード = new DataGridViewTextBoxColumn();
            仕入先履歴番号 = new DataGridViewTextBoxColumn();
            フロア名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            上代単価DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格0DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            消費税区分 = new DataGridViewTextBoxColumn();
            価格1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格3DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格4DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格5DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格6DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格7DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            価格8DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            数量DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnRegistProducts = new Button();
            lblCount = new Label();
            label4 = new Label();
            chkRegDetail = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)bsNewProductsList).BeginInit();
            groupBox1.SuspendLayout();
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
            label1.Size = new Size(1221, 64);
            label1.TabIndex = 0;
            label1.Text = "Bカート新規商品登録";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // bsNewProductsList
            // 
            bsNewProductsList.DataMember = "S_新規商品差分抽出2";
            bsNewProductsList.DataSource = typeof(AppData.dsTnbToBCart);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1057, 560);
            btnClose.Margin = new Padding(4, 2, 4, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(175, 47);
            btnClose.TabIndex = 4;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(txtFloorCD);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(lblWeit);
            groupBox1.Controls.Add(txtJyodai);
            groupBox1.Controls.Add(txtMakerCD);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtBarcode);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtLimit);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Location = new Point(11, 75);
            groupBox1.Margin = new Padding(4, 2, 4, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 2, 4, 2);
            groupBox1.Size = new Size(1221, 177);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // txtFloorCD
            // 
            txtFloorCD.Location = new Point(795, 48);
            txtFloorCD.Name = "txtFloorCD";
            txtFloorCD.Size = new Size(55, 39);
            txtFloorCD.TabIndex = 31;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(663, 51);
            label8.Name = "label8";
            label8.Size = new Size(115, 32);
            label8.TabIndex = 30;
            label8.Text = "フロアコード";
            // 
            // lblWeit
            // 
            lblWeit.AutoSize = true;
            lblWeit.Font = new Font("Yu Gothic UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblWeit.ForeColor = Color.Red;
            lblWeit.Location = new Point(946, 92);
            lblWeit.Name = "lblWeit";
            lblWeit.Size = new Size(233, 65);
            lblWeit.TabIndex = 29;
            lblWeit.Text = "※ 検索中";
            // 
            // txtJyodai
            // 
            txtJyodai.Location = new Point(536, 107);
            txtJyodai.Name = "txtJyodai";
            txtJyodai.Size = new Size(110, 39);
            txtJyodai.TabIndex = 28;
            // 
            // txtMakerCD
            // 
            txtMakerCD.Location = new Point(536, 48);
            txtMakerCD.Name = "txtMakerCD";
            txtMakerCD.Size = new Size(81, 39);
            txtMakerCD.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(441, 110);
            label7.Name = "label7";
            label7.Size = new Size(62, 32);
            label7.TabIndex = 26;
            label7.Text = "上代";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(441, 50);
            label6.Name = "label6";
            label6.Size = new Size(86, 32);
            label6.TabIndex = 21;
            label6.Text = "仕入先";
            // 
            // txtBarcode
            // 
            txtBarcode.Location = new Point(175, 107);
            txtBarcode.Margin = new Padding(4, 2, 4, 2);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(201, 39);
            txtBarcode.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 109);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(97, 32);
            label5.TabIndex = 19;
            label5.Text = "バーコード";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(282, 51);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(123, 32);
            label3.TabIndex = 18;
            label3.Text = "件まで表示";
            // 
            // txtLimit
            // 
            txtLimit.Location = new Point(175, 47);
            txtLimit.Margin = new Padding(4, 2, 4, 2);
            txtLimit.Name = "txtLimit";
            txtLimit.Size = new Size(102, 39);
            txtLimit.TabIndex = 17;
            txtLimit.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 51);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(148, 32);
            label2.TabIndex = 16;
            label2.Text = "最新の商品を";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(997, 43);
            btnSearch.Margin = new Padding(4, 2, 4, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(150, 47);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "再検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { chkSelect, btnDetail, 商品管理番号DataGridViewTextBoxColumn, バーコードDataGridViewTextBoxColumn, バーコード重複, 商品名DataGridViewTextBoxColumn, 仕入先コード, 仕入先履歴番号, フロア名DataGridViewTextBoxColumn, 上代単価DataGridViewTextBoxColumn, 価格0DataGridViewTextBoxColumn, 消費税区分, 価格1DataGridViewTextBoxColumn, 価格2DataGridViewTextBoxColumn, 価格3DataGridViewTextBoxColumn, 価格4DataGridViewTextBoxColumn, 価格5DataGridViewTextBoxColumn, 価格6DataGridViewTextBoxColumn, 価格7DataGridViewTextBoxColumn, 価格8DataGridViewTextBoxColumn, 数量DataGridViewTextBoxColumn });
            dgvMainList.DataSource = bsNewProductsList;
            dgvMainList.Location = new Point(13, 340);
            dgvMainList.Margin = new Padding(4, 2, 4, 2);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(1221, 216);
            dgvMainList.TabIndex = 25;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            dgvMainList.DataBindingComplete += dgvMainList_DataBindingComplete;
            // 
            // chkSelect
            // 
            chkSelect.HeaderText = "選択";
            chkSelect.MinimumWidth = 10;
            chkSelect.Name = "chkSelect";
            chkSelect.Width = 80;
            // 
            // btnDetail
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "詳細";
            btnDetail.DefaultCellStyle = dataGridViewCellStyle1;
            btnDetail.HeaderText = "詳細";
            btnDetail.MinimumWidth = 10;
            btnDetail.Name = "btnDetail";
            btnDetail.Width = 80;
            // 
            // 商品管理番号DataGridViewTextBoxColumn
            // 
            商品管理番号DataGridViewTextBoxColumn.DataPropertyName = "商品管理番号";
            商品管理番号DataGridViewTextBoxColumn.HeaderText = "商品管理番号";
            商品管理番号DataGridViewTextBoxColumn.MinimumWidth = 10;
            商品管理番号DataGridViewTextBoxColumn.Name = "商品管理番号DataGridViewTextBoxColumn";
            商品管理番号DataGridViewTextBoxColumn.Width = 220;
            // 
            // バーコードDataGridViewTextBoxColumn
            // 
            バーコードDataGridViewTextBoxColumn.DataPropertyName = "バーコード";
            バーコードDataGridViewTextBoxColumn.HeaderText = "バーコード";
            バーコードDataGridViewTextBoxColumn.MinimumWidth = 10;
            バーコードDataGridViewTextBoxColumn.Name = "バーコードDataGridViewTextBoxColumn";
            バーコードDataGridViewTextBoxColumn.Width = 200;
            // 
            // バーコード重複
            // 
            バーコード重複.DataPropertyName = "バーコード重複";
            バーコード重複.HeaderText = "重複";
            バーコード重複.MinimumWidth = 10;
            バーコード重複.Name = "バーコード重複";
            バーコード重複.ReadOnly = true;
            バーコード重複.Width = 120;
            // 
            // 商品名DataGridViewTextBoxColumn
            // 
            商品名DataGridViewTextBoxColumn.DataPropertyName = "商品名";
            商品名DataGridViewTextBoxColumn.HeaderText = "商品名";
            商品名DataGridViewTextBoxColumn.MinimumWidth = 10;
            商品名DataGridViewTextBoxColumn.Name = "商品名DataGridViewTextBoxColumn";
            商品名DataGridViewTextBoxColumn.Width = 600;
            // 
            // 仕入先コード
            // 
            仕入先コード.DataPropertyName = "仕入先コード";
            仕入先コード.HeaderText = "仕入先コード";
            仕入先コード.MinimumWidth = 10;
            仕入先コード.Name = "仕入先コード";
            仕入先コード.Width = 200;
            // 
            // 仕入先履歴番号
            // 
            仕入先履歴番号.DataPropertyName = "仕入先履歴番号";
            仕入先履歴番号.HeaderText = "仕入先履歴番号";
            仕入先履歴番号.MinimumWidth = 10;
            仕入先履歴番号.Name = "仕入先履歴番号";
            仕入先履歴番号.Width = 200;
            // 
            // フロア名DataGridViewTextBoxColumn
            // 
            フロア名DataGridViewTextBoxColumn.DataPropertyName = "フロア名";
            フロア名DataGridViewTextBoxColumn.HeaderText = "フロア名";
            フロア名DataGridViewTextBoxColumn.MinimumWidth = 10;
            フロア名DataGridViewTextBoxColumn.Name = "フロア名DataGridViewTextBoxColumn";
            フロア名DataGridViewTextBoxColumn.Width = 200;
            // 
            // 上代単価DataGridViewTextBoxColumn
            // 
            上代単価DataGridViewTextBoxColumn.DataPropertyName = "上代単価";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            上代単価DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            上代単価DataGridViewTextBoxColumn.HeaderText = "上代";
            上代単価DataGridViewTextBoxColumn.MinimumWidth = 10;
            上代単価DataGridViewTextBoxColumn.Name = "上代単価DataGridViewTextBoxColumn";
            上代単価DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格0DataGridViewTextBoxColumn
            // 
            価格0DataGridViewTextBoxColumn.DataPropertyName = "価格0";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格0DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            価格0DataGridViewTextBoxColumn.HeaderText = "単価";
            価格0DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格0DataGridViewTextBoxColumn.Name = "価格0DataGridViewTextBoxColumn";
            価格0DataGridViewTextBoxColumn.ReadOnly = true;
            価格0DataGridViewTextBoxColumn.Width = 140;
            // 
            // 消費税区分
            // 
            消費税区分.DataPropertyName = "消費税区分";
            消費税区分.HeaderText = "税区分";
            消費税区分.MinimumWidth = 10;
            消費税区分.Name = "消費税区分";
            消費税区分.Width = 120;
            // 
            // 価格1DataGridViewTextBoxColumn
            // 
            価格1DataGridViewTextBoxColumn.DataPropertyName = "価格1";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            価格1DataGridViewTextBoxColumn.HeaderText = "価格1";
            価格1DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格1DataGridViewTextBoxColumn.Name = "価格1DataGridViewTextBoxColumn";
            価格1DataGridViewTextBoxColumn.ReadOnly = true;
            価格1DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格2DataGridViewTextBoxColumn
            // 
            価格2DataGridViewTextBoxColumn.DataPropertyName = "価格2";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            価格2DataGridViewTextBoxColumn.HeaderText = "価格2";
            価格2DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格2DataGridViewTextBoxColumn.Name = "価格2DataGridViewTextBoxColumn";
            価格2DataGridViewTextBoxColumn.ReadOnly = true;
            価格2DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格3DataGridViewTextBoxColumn
            // 
            価格3DataGridViewTextBoxColumn.DataPropertyName = "価格3";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格3DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            価格3DataGridViewTextBoxColumn.HeaderText = "価格3";
            価格3DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格3DataGridViewTextBoxColumn.Name = "価格3DataGridViewTextBoxColumn";
            価格3DataGridViewTextBoxColumn.ReadOnly = true;
            価格3DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格4DataGridViewTextBoxColumn
            // 
            価格4DataGridViewTextBoxColumn.DataPropertyName = "価格4";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格4DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            価格4DataGridViewTextBoxColumn.HeaderText = "価格4";
            価格4DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格4DataGridViewTextBoxColumn.Name = "価格4DataGridViewTextBoxColumn";
            価格4DataGridViewTextBoxColumn.ReadOnly = true;
            価格4DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格5DataGridViewTextBoxColumn
            // 
            価格5DataGridViewTextBoxColumn.DataPropertyName = "価格5";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格5DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            価格5DataGridViewTextBoxColumn.HeaderText = "価格5";
            価格5DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格5DataGridViewTextBoxColumn.Name = "価格5DataGridViewTextBoxColumn";
            価格5DataGridViewTextBoxColumn.ReadOnly = true;
            価格5DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格6DataGridViewTextBoxColumn
            // 
            価格6DataGridViewTextBoxColumn.DataPropertyName = "価格6";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格6DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            価格6DataGridViewTextBoxColumn.HeaderText = "価格6";
            価格6DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格6DataGridViewTextBoxColumn.Name = "価格6DataGridViewTextBoxColumn";
            価格6DataGridViewTextBoxColumn.ReadOnly = true;
            価格6DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格7DataGridViewTextBoxColumn
            // 
            価格7DataGridViewTextBoxColumn.DataPropertyName = "価格7";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格7DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            価格7DataGridViewTextBoxColumn.HeaderText = "価格7";
            価格7DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格7DataGridViewTextBoxColumn.Name = "価格7DataGridViewTextBoxColumn";
            価格7DataGridViewTextBoxColumn.ReadOnly = true;
            価格7DataGridViewTextBoxColumn.Width = 140;
            // 
            // 価格8DataGridViewTextBoxColumn
            // 
            価格8DataGridViewTextBoxColumn.DataPropertyName = "価格8";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleRight;
            価格8DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            価格8DataGridViewTextBoxColumn.HeaderText = "価格8";
            価格8DataGridViewTextBoxColumn.MinimumWidth = 10;
            価格8DataGridViewTextBoxColumn.Name = "価格8DataGridViewTextBoxColumn";
            価格8DataGridViewTextBoxColumn.ReadOnly = true;
            価格8DataGridViewTextBoxColumn.Width = 140;
            // 
            // 数量DataGridViewTextBoxColumn
            // 
            数量DataGridViewTextBoxColumn.DataPropertyName = "数量";
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleRight;
            数量DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            数量DataGridViewTextBoxColumn.HeaderText = "在庫";
            数量DataGridViewTextBoxColumn.MinimumWidth = 10;
            数量DataGridViewTextBoxColumn.Name = "数量DataGridViewTextBoxColumn";
            数量DataGridViewTextBoxColumn.ReadOnly = true;
            数量DataGridViewTextBoxColumn.Width = 140;
            // 
            // btnRegistProducts
            // 
            btnRegistProducts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistProducts.Location = new Point(892, 270);
            btnRegistProducts.Margin = new Padding(4, 2, 4, 2);
            btnRegistProducts.Name = "btnRegistProducts";
            btnRegistProducts.Size = new Size(325, 47);
            btnRegistProducts.TabIndex = 24;
            btnRegistProducts.Text = "Bカートに商品を登録する";
            btnRegistProducts.UseVisualStyleBackColor = true;
            btnRegistProducts.Click += btnRegistProducts_Click;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(317, 285);
            lblCount.Margin = new Padding(4, 0, 4, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(78, 32);
            lblCount.TabIndex = 23;
            lblCount.Text = "label6";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 285);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(237, 32);
            label4.TabIndex = 22;
            label4.Text = "Bカートに未登録の商品";
            // 
            // chkRegDetail
            // 
            chkRegDetail.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkRegDetail.AutoSize = true;
            chkRegDetail.Location = new Point(684, 276);
            chkRegDetail.Name = "chkRegDetail";
            chkRegDetail.Size = new Size(198, 36);
            chkRegDetail.TabIndex = 26;
            chkRegDetail.Text = "詳細を登録する";
            chkRegDetail.UseVisualStyleBackColor = true;
            // 
            // frmNewProducts
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 618);
            Controls.Add(chkRegDetail);
            Controls.Add(dgvMainList);
            Controls.Add(btnRegistProducts);
            Controls.Add(lblCount);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Margin = new Padding(4, 2, 4, 2);
            Name = "frmNewProducts";
            Text = "frmNewProducts";
            Load += frmNewProducts_Load;
            ((System.ComponentModel.ISupportInitialize)bsNewProductsList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private BindingSource bsNewProductsList;
        private Button btnClose;
        private GroupBox groupBox1;
        private TextBox txtBarcode;
        private Label label5;
        private Label label3;
        private TextBox txtLimit;
        private Label label2;
        private Button btnSearch;
        private DataGridView dgvMainList;
        private Button btnRegistProducts;
        private Label lblCount;
        private Label label4;
        private TextBox txtJyodai;
        private TextBox txtMakerCD;
        private Label label7;
        private Label label6;
        private Label lblWeit;
        private DataGridViewCheckBoxColumn chkSelect;
        private DataGridViewButtonColumn btnDetail;
        private DataGridViewTextBoxColumn 商品管理番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn バーコードDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn バーコード重複;
        private DataGridViewTextBoxColumn 商品名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 仕入先コード;
        private DataGridViewTextBoxColumn 仕入先履歴番号;
        private DataGridViewTextBoxColumn フロア名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 上代単価DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格0DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 消費税区分;
        private DataGridViewTextBoxColumn 価格1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格3DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格4DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格5DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格6DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格7DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 価格8DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 数量DataGridViewTextBoxColumn;
        private TextBox txtFloorCD;
        private Label label8;
        private CheckBox chkRegDetail;
    }
}