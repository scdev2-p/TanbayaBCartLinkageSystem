namespace Bcart受注管理.Forms
{
    partial class frmUnregCustomer
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblDate = new Label();
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            txtCustomerName = new TextBox();
            txtCustomerCode = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dgvMainList = new DataGridView();
            btnDetail = new DataGridViewButtonColumn();
            顧客管理番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            顧客コード = new DataGridViewTextBoxColumn();
            顧客名 = new DataGridViewTextBoxColumn();
            郵便番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            住所DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            電話番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bsBcartLink = new BindingSource(components);
            btnClose = new Button();
            lblCount = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(473, 4);
            lblDate.Margin = new Padding(2, 0, 2, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(152, 30);
            lblDate.TabIndex = 10;
            lblDate.Text = "9999年99月99日(月)";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTitle.Location = new Point(6, 4);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(308, 30);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtCustomerName);
            groupBox1.Controls.Add(txtCustomerCode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 36);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(619, 77);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(467, 45);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(145, 22);
            btnSearch.TabIndex = 30;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(77, 45);
            txtCustomerName.Margin = new Padding(2, 1, 2, 1);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(372, 23);
            txtCustomerName.TabIndex = 20;
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Location = new Point(77, 17);
            txtCustomerCode.Margin = new Padding(2, 1, 2, 1);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.Size = new Size(110, 23);
            txtCustomerCode.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 47);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 1;
            label2.Text = "顧客名";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 21);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "顧客コード";
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { btnDetail, 顧客管理番号DataGridViewTextBoxColumn, 顧客コード, 顧客名, 郵便番号DataGridViewTextBoxColumn, 住所DataGridViewTextBoxColumn, 電話番号DataGridViewTextBoxColumn });
            dgvMainList.DataSource = bsBcartLink;
            dgvMainList.Location = new Point(10, 136);
            dgvMainList.Margin = new Padding(2, 1, 2, 1);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.ReadOnly = true;
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(616, 265);
            dgvMainList.TabIndex = 40;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            // 
            // btnDetail
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "登録";
            btnDetail.DefaultCellStyle = dataGridViewCellStyle2;
            btnDetail.Frozen = true;
            btnDetail.HeaderText = "登録";
            btnDetail.MinimumWidth = 10;
            btnDetail.Name = "btnDetail";
            btnDetail.ReadOnly = true;
            btnDetail.Text = "";
            btnDetail.Width = 60;
            // 
            // 顧客管理番号DataGridViewTextBoxColumn
            // 
            顧客管理番号DataGridViewTextBoxColumn.DataPropertyName = "顧客管理番号";
            顧客管理番号DataGridViewTextBoxColumn.HeaderText = "顧客管理番号";
            顧客管理番号DataGridViewTextBoxColumn.MinimumWidth = 10;
            顧客管理番号DataGridViewTextBoxColumn.Name = "顧客管理番号DataGridViewTextBoxColumn";
            顧客管理番号DataGridViewTextBoxColumn.ReadOnly = true;
            顧客管理番号DataGridViewTextBoxColumn.Width = 120;
            // 
            // 顧客コード
            // 
            顧客コード.DataPropertyName = "顧客コード";
            顧客コード.HeaderText = "顧客コード";
            顧客コード.MinimumWidth = 10;
            顧客コード.Name = "顧客コード";
            顧客コード.ReadOnly = true;
            顧客コード.Width = 120;
            // 
            // 顧客名
            // 
            顧客名.DataPropertyName = "顧客名";
            顧客名.HeaderText = "顧客名";
            顧客名.MinimumWidth = 10;
            顧客名.Name = "顧客名";
            顧客名.ReadOnly = true;
            顧客名.Width = 200;
            // 
            // 郵便番号DataGridViewTextBoxColumn
            // 
            郵便番号DataGridViewTextBoxColumn.DataPropertyName = "郵便番号";
            郵便番号DataGridViewTextBoxColumn.HeaderText = "郵便番号";
            郵便番号DataGridViewTextBoxColumn.MinimumWidth = 10;
            郵便番号DataGridViewTextBoxColumn.Name = "郵便番号DataGridViewTextBoxColumn";
            郵便番号DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 住所DataGridViewTextBoxColumn
            // 
            住所DataGridViewTextBoxColumn.DataPropertyName = "住所";
            住所DataGridViewTextBoxColumn.HeaderText = "住所";
            住所DataGridViewTextBoxColumn.MinimumWidth = 10;
            住所DataGridViewTextBoxColumn.Name = "住所DataGridViewTextBoxColumn";
            住所DataGridViewTextBoxColumn.ReadOnly = true;
            住所DataGridViewTextBoxColumn.Width = 200;
            // 
            // 電話番号DataGridViewTextBoxColumn
            // 
            電話番号DataGridViewTextBoxColumn.DataPropertyName = "電話番号";
            電話番号DataGridViewTextBoxColumn.HeaderText = "電話番号";
            電話番号DataGridViewTextBoxColumn.MinimumWidth = 10;
            電話番号DataGridViewTextBoxColumn.Name = "電話番号DataGridViewTextBoxColumn";
            電話番号DataGridViewTextBoxColumn.ReadOnly = true;
            電話番号DataGridViewTextBoxColumn.Width = 200;
            // 
            // bsBcartLink
            // 
            bsBcartLink.DataMember = "S_SearchUnregCustomer";
            bsBcartLink.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(545, 408);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 50;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblCount
            // 
            lblCount.BorderStyle = BorderStyle.Fixed3D;
            lblCount.Location = new Point(10, 114);
            lblCount.Margin = new Padding(2, 0, 2, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(229, 20);
            lblCount.TabIndex = 15;
            lblCount.Text = "label6";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmUnregCustomer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 435);
            Controls.Add(lblCount);
            Controls.Add(btnClose);
            Controls.Add(dgvMainList);
            Controls.Add(groupBox1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmUnregCustomer";
            Text = "顧客登録";
            FormClosed += frmUnregCustomer_FormClosed;
            Load += frmUnregCustomer_Load;
            KeyPress += frmUnregCustomer_KeyPress;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLoginName;
        private Label lblDate;
        private Label lblTitle;
        private GroupBox groupBox1;
        private TextBox txtCustomerName;
        private TextBox txtCustomerCode;
        private Label label2;
        private Label label1;
        private DataGridView dgvMainList;
        private Button btnClose;
        private Label lblCount;
        private BindingSource bsBcartLink;
        private DataGridViewTextBoxColumn クラスDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 海外禁止DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先宛名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先郵便番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先住所DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先住所1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先住所2DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先住所3DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先電話番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 送り先FAX番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tG設定額DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tG残額DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cF設定額DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cF残額DataGridViewTextBoxColumn;
        private DataGridViewButtonColumn btnDetail;
        private DataGridViewTextBoxColumn 顧客管理番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 顧客コード;
        private DataGridViewTextBoxColumn 顧客名;
        private DataGridViewTextBoxColumn 郵便番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 住所DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 電話番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn メールアドレス;
        private Button btnSearch;
    }
}