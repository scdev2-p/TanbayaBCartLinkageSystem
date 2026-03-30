namespace Bcart受注管理.Forms
{
    partial class frmOderList
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
            lblDate = new Label();
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            cmbStatus = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            dtOrderTo = new DateTimePicker();
            dtOrderFrom = new DateTimePicker();
            label3 = new Label();
            txtCustomerCode = new TextBox();
            txtOrderCode = new TextBox();
            label2 = new Label();
            label1 = new Label();
            dgvMainList = new DataGridView();
            btnDetail = new DataGridViewButtonColumn();
            ordercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ordered_at_txt = new DataGridViewTextBoxColumn();
            customerextidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customer_comp_name = new DataGridViewTextBoxColumn();
            paymentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            reserved = new DataGridViewTextBoxColumn();
            customer_message = new DataGridViewTextBoxColumn();
            bsBcartLink = new BindingSource(components);
            btnClose = new Button();
            lblCount = new Label();
            btnPicking = new Button();
            btnReloadOrder = new Button();
            btnReserved = new Button();
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
            lblDate.Location = new Point(579, 4);
            lblDate.Margin = new Padding(2, 0, 2, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(152, 30);
            lblDate.TabIndex = 7;
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
            lblTitle.Size = new Size(414, 30);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtOrderTo);
            groupBox1.Controls.Add(dtOrderFrom);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtCustomerCode);
            groupBox1.Controls.Add(txtOrderCode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(6, 36);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(725, 80);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(572, 49);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(145, 22);
            btnSearch.TabIndex = 60;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "(すべて)", "新規注文", "ピック済", "出荷完了" });
            cmbStatus.Location = new Point(261, 49);
            cmbStatus.Margin = new Padding(2, 1, 2, 1);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(110, 23);
            cmbStatus.TabIndex = 50;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(200, 53);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 8;
            label5.Text = "対応状況";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(371, 24);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 7;
            label4.Text = "～";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtOrderTo
            // 
            dtOrderTo.Format = DateTimePickerFormat.Short;
            dtOrderTo.Location = new Point(395, 20);
            dtOrderTo.Margin = new Padding(2, 1, 2, 1);
            dtOrderTo.Name = "dtOrderTo";
            dtOrderTo.Size = new Size(108, 23);
            dtOrderTo.TabIndex = 30;
            // 
            // dtOrderFrom
            // 
            dtOrderFrom.Format = DateTimePickerFormat.Short;
            dtOrderFrom.Location = new Point(261, 20);
            dtOrderFrom.Margin = new Padding(2, 1, 2, 1);
            dtOrderFrom.Name = "dtOrderFrom";
            dtOrderFrom.Size = new Size(108, 23);
            dtOrderFrom.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 24);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 4;
            label3.Text = "受注日";
            // 
            // txtCustomerCode
            // 
            txtCustomerCode.Location = new Point(70, 49);
            txtCustomerCode.Margin = new Padding(2, 1, 2, 1);
            txtCustomerCode.Name = "txtCustomerCode";
            txtCustomerCode.Size = new Size(110, 23);
            txtCustomerCode.TabIndex = 40;
            // 
            // txtOrderCode
            // 
            txtOrderCode.Location = new Point(70, 20);
            txtOrderCode.Margin = new Padding(2, 1, 2, 1);
            txtOrderCode.Name = "txtOrderCode";
            txtOrderCode.Size = new Size(110, 23);
            txtOrderCode.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 53);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 1;
            label2.Text = "顧客コード";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 24);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "受注番号";
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { btnDetail, ordercodeDataGridViewTextBoxColumn, ordered_at_txt, customerextidDataGridViewTextBoxColumn, customer_comp_name, paymentDataGridViewTextBoxColumn, totalpriceDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, reserved, customer_message });
            dgvMainList.DataSource = bsBcartLink;
            dgvMainList.Location = new Point(6, 146);
            dgvMainList.Margin = new Padding(2, 1, 2, 1);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.ReadOnly = true;
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(722, 239);
            dgvMainList.TabIndex = 70;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            // 
            // btnDetail
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "詳細";
            btnDetail.DefaultCellStyle = dataGridViewCellStyle1;
            btnDetail.Frozen = true;
            btnDetail.HeaderText = "詳細";
            btnDetail.MinimumWidth = 10;
            btnDetail.Name = "btnDetail";
            btnDetail.ReadOnly = true;
            btnDetail.Text = "詳細";
            btnDetail.Width = 60;
            // 
            // ordercodeDataGridViewTextBoxColumn
            // 
            ordercodeDataGridViewTextBoxColumn.DataPropertyName = "order_code";
            ordercodeDataGridViewTextBoxColumn.Frozen = true;
            ordercodeDataGridViewTextBoxColumn.HeaderText = "受注番号";
            ordercodeDataGridViewTextBoxColumn.MinimumWidth = 10;
            ordercodeDataGridViewTextBoxColumn.Name = "ordercodeDataGridViewTextBoxColumn";
            ordercodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordered_at_txt
            // 
            ordered_at_txt.DataPropertyName = "ordered_at";
            ordered_at_txt.Frozen = true;
            ordered_at_txt.HeaderText = "受注日";
            ordered_at_txt.MinimumWidth = 10;
            ordered_at_txt.Name = "ordered_at_txt";
            ordered_at_txt.ReadOnly = true;
            ordered_at_txt.Width = 110;
            // 
            // customerextidDataGridViewTextBoxColumn
            // 
            customerextidDataGridViewTextBoxColumn.DataPropertyName = "customer_customs3";
            customerextidDataGridViewTextBoxColumn.Frozen = true;
            customerextidDataGridViewTextBoxColumn.HeaderText = "顧客コード";
            customerextidDataGridViewTextBoxColumn.MinimumWidth = 10;
            customerextidDataGridViewTextBoxColumn.Name = "customerextidDataGridViewTextBoxColumn";
            customerextidDataGridViewTextBoxColumn.ReadOnly = true;
            customerextidDataGridViewTextBoxColumn.Width = 80;
            // 
            // customer_comp_name
            // 
            customer_comp_name.DataPropertyName = "customer_comp_name";
            customer_comp_name.Frozen = true;
            customer_comp_name.HeaderText = "顧客名";
            customer_comp_name.MinimumWidth = 8;
            customer_comp_name.Name = "customer_comp_name";
            customer_comp_name.ReadOnly = true;
            customer_comp_name.Width = 350;
            // 
            // paymentDataGridViewTextBoxColumn
            // 
            paymentDataGridViewTextBoxColumn.DataPropertyName = "payment";
            paymentDataGridViewTextBoxColumn.Frozen = true;
            paymentDataGridViewTextBoxColumn.HeaderText = "決済方法";
            paymentDataGridViewTextBoxColumn.MinimumWidth = 10;
            paymentDataGridViewTextBoxColumn.Name = "paymentDataGridViewTextBoxColumn";
            paymentDataGridViewTextBoxColumn.ReadOnly = true;
            paymentDataGridViewTextBoxColumn.Width = 120;
            // 
            // totalpriceDataGridViewTextBoxColumn
            // 
            totalpriceDataGridViewTextBoxColumn.DataPropertyName = "total_price";
            totalpriceDataGridViewTextBoxColumn.Frozen = true;
            totalpriceDataGridViewTextBoxColumn.HeaderText = "合計金額";
            totalpriceDataGridViewTextBoxColumn.MinimumWidth = 10;
            totalpriceDataGridViewTextBoxColumn.Name = "totalpriceDataGridViewTextBoxColumn";
            totalpriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            statusDataGridViewTextBoxColumn.Frozen = true;
            statusDataGridViewTextBoxColumn.HeaderText = "対応状況";
            statusDataGridViewTextBoxColumn.MinimumWidth = 10;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // reserved
            // 
            reserved.DataPropertyName = "reserved";
            reserved.Frozen = true;
            reserved.HeaderText = "取置";
            reserved.MinimumWidth = 10;
            reserved.Name = "reserved";
            reserved.ReadOnly = true;
            reserved.Width = 60;
            // 
            // customer_message
            // 
            customer_message.DataPropertyName = "customer_message";
            customer_message.HeaderText = "お客様からの連絡事項";
            customer_message.Name = "customer_message";
            customer_message.ReadOnly = true;
            customer_message.Width = 500;
            // 
            // bsBcartLink
            // 
            bsBcartLink.DataMember = "S_SearchOrder";
            bsBcartLink.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(647, 387);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 100;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblCount
            // 
            lblCount.BorderStyle = BorderStyle.Fixed3D;
            lblCount.Location = new Point(6, 122);
            lblCount.Margin = new Padding(2, 0, 2, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(229, 20);
            lblCount.TabIndex = 13;
            lblCount.Text = "label6";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPicking
            // 
            btnPicking.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPicking.Location = new Point(6, 387);
            btnPicking.Margin = new Padding(2, 1, 2, 1);
            btnPicking.Name = "btnPicking";
            btnPicking.Size = new Size(133, 22);
            btnPicking.TabIndex = 80;
            btnPicking.Text = "ピッキング作業";
            btnPicking.UseVisualStyleBackColor = true;
            btnPicking.Click += btnPicking_Click;
            // 
            // btnReloadOrder
            // 
            btnReloadOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReloadOrder.Location = new Point(143, 387);
            btnReloadOrder.Margin = new Padding(2, 1, 2, 1);
            btnReloadOrder.Name = "btnReloadOrder";
            btnReloadOrder.Size = new Size(133, 22);
            btnReloadOrder.TabIndex = 90;
            btnReloadOrder.Text = "BCart受注再取込";
            btnReloadOrder.UseVisualStyleBackColor = true;
            btnReloadOrder.Click += btnReloadOrder_Click;
            // 
            // btnReserved
            // 
            btnReserved.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReserved.Location = new Point(280, 387);
            btnReserved.Margin = new Padding(2, 1, 2, 1);
            btnReserved.Name = "btnReserved";
            btnReserved.Size = new Size(133, 22);
            btnReserved.TabIndex = 322;
            btnReserved.Text = "取置一覧";
            btnReserved.UseVisualStyleBackColor = true;
            btnReserved.Click += btnReserved_Click;
            // 
            // frmOderList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 417);
            Controls.Add(btnReserved);
            Controls.Add(btnReloadOrder);
            Controls.Add(btnPicking);
            Controls.Add(lblCount);
            Controls.Add(btnClose);
            Controls.Add(dgvMainList);
            Controls.Add(groupBox1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmOderList";
            Text = "BCart受注一覧";
            FormClosed += frmOderList_FormClosed;
            Load += frmOderList_Load;
            KeyPress += frmOderList_KeyPress;
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
        private DateTimePicker dtOrderFrom;
        private Label label3;
        private TextBox txtCustomerCode;
        private TextBox txtOrderCode;
        private Label label2;
        private Label label1;
        private ComboBox cmbStatus;
        private Label label5;
        private Label label4;
        private DateTimePicker dtOrderTo;
        private DataGridView dgvMainList;
        private Button btnClose;
        private BindingSource bsBcartLink;
        private Label lblCount;
        private Button btnSearch;
        private Button btnPicking;
        private Button btnReloadOrder;
        private DataGridViewButtonColumn btnDetail;
        private DataGridViewTextBoxColumn ordercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ordered_at_txt;
        private DataGridViewTextBoxColumn customerextidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customer_comp_name;
        private DataGridViewTextBoxColumn paymentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn reserved;
        private DataGridViewTextBoxColumn customer_message;
        private Button btnReserved;
    }
}