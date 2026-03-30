namespace Bcart受注管理.Forms
{
    partial class frmReserving
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
            lblTitle = new Label();
            lblCustomer = new Label();
            txtCustomer = new TextBox();
            btnSearch = new Button();
            dgvMainList = new DataGridView();
            btnReservedDeital = new DataGridViewButtonColumn();
            customercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            顧客名 = new DataGridViewTextBoxColumn();
            paymentdispDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderdatefromDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderdatetoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            picking = new DataGridViewTextBoxColumn();
            reserve_status = new DataGridViewTextBoxColumn();
            bsBcartLink = new BindingSource(components);
            btnClose = new Button();
            btnReloadOrder = new Button();
            btnPicking = new Button();
            btnOrder = new Button();
            label2 = new Label();
            textBarcode = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTitle.Location = new Point(11, 9);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(860, 30);
            lblTitle.TabIndex = 10;
            lblTitle.Text = "取置一覧";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(12, 57);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(55, 15);
            lblCustomer.TabIndex = 11;
            lblCustomer.Text = "顧客コード";
            // 
            // txtCustomer
            // 
            txtCustomer.Location = new Point(73, 54);
            txtCustomer.Name = "txtCustomer";
            txtCustomer.Size = new Size(114, 23);
            txtCustomer.TabIndex = 12;
            txtCustomer.KeyDown += txtCustomer_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(392, 48);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(78, 33);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "検索";
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
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { btnReservedDeital, customercodeDataGridViewTextBoxColumn, 顧客名, paymentdispDataGridViewTextBoxColumn, orderdatefromDataGridViewTextBoxColumn, orderdatetoDataGridViewTextBoxColumn, picking, reserve_status });
            dgvMainList.DataSource = bsBcartLink;
            dgvMainList.Location = new Point(10, 115);
            dgvMainList.Margin = new Padding(2, 1, 2, 1);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(861, 248);
            dgvMainList.TabIndex = 41;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            // 
            // btnReservedDeital
            // 
            btnReservedDeital.HeaderText = "明細";
            btnReservedDeital.Name = "btnReservedDeital";
            btnReservedDeital.Text = "明細";
            btnReservedDeital.UseColumnTextForButtonValue = true;
            btnReservedDeital.Width = 50;
            // 
            // customercodeDataGridViewTextBoxColumn
            // 
            customercodeDataGridViewTextBoxColumn.DataPropertyName = "customer_code";
            customercodeDataGridViewTextBoxColumn.HeaderText = "顧客コード";
            customercodeDataGridViewTextBoxColumn.Name = "customercodeDataGridViewTextBoxColumn";
            // 
            // 顧客名
            // 
            顧客名.DataPropertyName = "顧客名";
            顧客名.HeaderText = "顧客名";
            顧客名.Name = "顧客名";
            // 
            // paymentdispDataGridViewTextBoxColumn
            // 
            paymentdispDataGridViewTextBoxColumn.DataPropertyName = "payment_disp";
            paymentdispDataGridViewTextBoxColumn.HeaderText = "支払方法";
            paymentdispDataGridViewTextBoxColumn.Name = "paymentdispDataGridViewTextBoxColumn";
            paymentdispDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderdatefromDataGridViewTextBoxColumn
            // 
            orderdatefromDataGridViewTextBoxColumn.DataPropertyName = "order_date_from";
            orderdatefromDataGridViewTextBoxColumn.HeaderText = "受注日From";
            orderdatefromDataGridViewTextBoxColumn.Name = "orderdatefromDataGridViewTextBoxColumn";
            orderdatefromDataGridViewTextBoxColumn.ReadOnly = true;
            orderdatefromDataGridViewTextBoxColumn.Width = 150;
            // 
            // orderdatetoDataGridViewTextBoxColumn
            // 
            orderdatetoDataGridViewTextBoxColumn.DataPropertyName = "order_date_to";
            orderdatetoDataGridViewTextBoxColumn.HeaderText = "受注日To";
            orderdatetoDataGridViewTextBoxColumn.Name = "orderdatetoDataGridViewTextBoxColumn";
            orderdatetoDataGridViewTextBoxColumn.ReadOnly = true;
            orderdatetoDataGridViewTextBoxColumn.Width = 150;
            // 
            // picking
            // 
            picking.DataPropertyName = "picking";
            picking.HeaderText = "ピッキング";
            picking.Name = "picking";
            picking.ReadOnly = true;
            // 
            // reserve_status
            // 
            reserve_status.DataPropertyName = "reserve_status";
            reserve_status.HeaderText = "取置ステータス";
            reserve_status.Name = "reserve_status";
            reserve_status.ReadOnly = true;
            // 
            // bsBcartLink
            // 
            bsBcartLink.DataMember = "S_SearchReserved";
            bsBcartLink.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(772, 367);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(98, 24);
            btnClose.TabIndex = 42;
            btnClose.Text = "閉じる";
            btnClose.TextAlign = ContentAlignment.BottomCenter;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnReloadOrder
            // 
            btnReloadOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReloadOrder.Location = new Point(284, 369);
            btnReloadOrder.Margin = new Padding(2, 1, 2, 1);
            btnReloadOrder.Name = "btnReloadOrder";
            btnReloadOrder.Size = new Size(133, 22);
            btnReloadOrder.TabIndex = 324;
            btnReloadOrder.Text = "BCart受注再取込";
            btnReloadOrder.UseVisualStyleBackColor = true;
            btnReloadOrder.Click += btnReloadOrder_Click;
            // 
            // btnPicking
            // 
            btnPicking.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPicking.Location = new Point(147, 369);
            btnPicking.Margin = new Padding(2, 1, 2, 1);
            btnPicking.Name = "btnPicking";
            btnPicking.Size = new Size(133, 22);
            btnPicking.TabIndex = 323;
            btnPicking.Text = "ピッキング作業";
            btnPicking.UseVisualStyleBackColor = true;
            btnPicking.Click += btnPicking_Click;
            // 
            // btnOrder
            // 
            btnOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOrder.Location = new Point(10, 369);
            btnOrder.Margin = new Padding(2, 1, 2, 1);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(133, 22);
            btnOrder.TabIndex = 326;
            btnOrder.Text = "BCart受注管理";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(193, 57);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 328;
            label2.Text = "バーコード";
            // 
            // textBarcode
            // 
            textBarcode.Location = new Point(248, 54);
            textBarcode.Name = "textBarcode";
            textBarcode.Size = new Size(114, 23);
            textBarcode.TabIndex = 329;
            // 
            // frmReserving
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 400);
            Controls.Add(textBarcode);
            Controls.Add(label2);
            Controls.Add(btnOrder);
            Controls.Add(btnReloadOrder);
            Controls.Add(btnPicking);
            Controls.Add(btnClose);
            Controls.Add(dgvMainList);
            Controls.Add(btnSearch);
            Controls.Add(txtCustomer);
            Controls.Add(lblCustomer);
            Controls.Add(lblTitle);
            Name = "frmReserving";
            Text = "frmReserving";
            Load += frmReserving_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCustomer;
        private TextBox txtCustomer;
        private Button btnSearch;
        private DataGridView dgvMainList;
        private BindingSource bsBcartLink;
        private Button btnClose;
        private DataGridViewButtonColumn btnReservedDeital;
        private DataGridViewTextBoxColumn customercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 顧客名;
        private DataGridViewTextBoxColumn paymentdispDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderdatefromDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderdatetoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn picking;
        private DataGridViewTextBoxColumn reserve_status;
        private Button btnReloadOrder;
        private Button btnPicking;
        private Button btnOrder;
        private Label label2;
        private TextBox textBarcode;
    }
}