namespace Bcart受注管理.Forms
{
    partial class frmSippingList
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
            lblDate = new Label();
            lblTitle = new Label();
            txtOrderCode = new TextBox();
            label1 = new Label();
            bsBcartLink = new BindingSource(components);
            dgvMainList = new DataGridView();
            btnClose = new Button();
            lblCount = new Label();
            groupBox1 = new GroupBox();
            btnSearch = new Button();
            chkOrderDate = new CheckBox();
            cmbStatus = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            dtOrderTo = new DateTimePicker();
            dtOrderFrom = new DateTimePicker();
            btnDetail = new DataGridViewButtonColumn();
            ordercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ordered_at = new DataGridViewTextBoxColumn();
            customerextidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customer_comp_name = new DataGridViewTextBoxColumn();
            paymentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            reserved = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(643, 4);
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
            lblTitle.Size = new Size(478, 30);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOrderCode
            // 
            txtOrderCode.BackColor = Color.FromArgb(255, 224, 192);
            txtOrderCode.Location = new Point(89, 40);
            txtOrderCode.Margin = new Padding(2, 1, 2, 1);
            txtOrderCode.Name = "txtOrderCode";
            txtOrderCode.Size = new Size(164, 23);
            txtOrderCode.TabIndex = 10;
            txtOrderCode.KeyPress += txtOrderCode_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 43);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "受注番号";
            // 
            // bsBcartLink
            // 
            bsBcartLink.DataMember = "S_SearchSipping";
            bsBcartLink.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { btnDetail, ordercodeDataGridViewTextBoxColumn, ordered_at, customerextidDataGridViewTextBoxColumn, customer_comp_name, paymentDataGridViewTextBoxColumn, totalpriceDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, reserved });
            dgvMainList.DataSource = bsBcartLink;
            dgvMainList.Location = new Point(8, 135);
            dgvMainList.Margin = new Padding(2, 1, 2, 1);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.ReadOnly = true;
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(786, 264);
            dgvMainList.TabIndex = 70;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(713, 408);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 80;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblCount
            // 
            lblCount.BorderStyle = BorderStyle.Fixed3D;
            lblCount.Location = new Point(8, 114);
            lblCount.Margin = new Padding(2, 0, 2, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(104, 20);
            lblCount.TabIndex = 14;
            lblCount.Text = "label6";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(chkOrderDate);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtOrderTo);
            groupBox1.Controls.Add(dtOrderFrom);
            groupBox1.Location = new Point(9, 65);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(786, 48);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(623, 17);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(145, 22);
            btnSearch.TabIndex = 60;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chkOrderDate
            // 
            chkOrderDate.AutoSize = true;
            chkOrderDate.Checked = true;
            chkOrderDate.CheckState = CheckState.Checked;
            chkOrderDate.Location = new Point(244, 19);
            chkOrderDate.Margin = new Padding(2, 1, 2, 1);
            chkOrderDate.Name = "chkOrderDate";
            chkOrderDate.Size = new Size(62, 19);
            chkOrderDate.TabIndex = 30;
            chkOrderDate.Text = "受注日";
            chkOrderDate.UseVisualStyleBackColor = true;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "(すべて)", "新規注文", "ピック済", "出荷完了以外" });
            cmbStatus.Location = new Point(80, 17);
            cmbStatus.Margin = new Padding(2, 1, 2, 1);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(110, 23);
            cmbStatus.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 21);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 8;
            label5.Text = "対応状況";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(414, 21);
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
            dtOrderTo.Location = new Point(433, 17);
            dtOrderTo.Margin = new Padding(2, 1, 2, 1);
            dtOrderTo.Name = "dtOrderTo";
            dtOrderTo.Size = new Size(108, 23);
            dtOrderTo.TabIndex = 50;
            // 
            // dtOrderFrom
            // 
            dtOrderFrom.Format = DateTimePickerFormat.Short;
            dtOrderFrom.Location = new Point(306, 17);
            dtOrderFrom.Margin = new Padding(2, 1, 2, 1);
            dtOrderFrom.Name = "dtOrderFrom";
            dtOrderFrom.Size = new Size(108, 23);
            dtOrderFrom.TabIndex = 40;
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
            dataGridViewCellStyle2.NullValue = "詳細";
            ordercodeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            ordercodeDataGridViewTextBoxColumn.Frozen = true;
            ordercodeDataGridViewTextBoxColumn.HeaderText = "受注番号";
            ordercodeDataGridViewTextBoxColumn.MinimumWidth = 10;
            ordercodeDataGridViewTextBoxColumn.Name = "ordercodeDataGridViewTextBoxColumn";
            ordercodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ordered_at
            // 
            ordered_at.DataPropertyName = "ordered_at";
            ordered_at.Frozen = true;
            ordered_at.HeaderText = "受注日";
            ordered_at.MinimumWidth = 10;
            ordered_at.Name = "ordered_at";
            ordered_at.ReadOnly = true;
            ordered_at.Width = 110;
            // 
            // customerextidDataGridViewTextBoxColumn
            // 
            customerextidDataGridViewTextBoxColumn.DataPropertyName = "customer_customs3";
            customerextidDataGridViewTextBoxColumn.Frozen = true;
            customerextidDataGridViewTextBoxColumn.HeaderText = "顧客コード";
            customerextidDataGridViewTextBoxColumn.MinimumWidth = 10;
            customerextidDataGridViewTextBoxColumn.Name = "customerextidDataGridViewTextBoxColumn";
            customerextidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // customer_comp_name
            // 
            customer_comp_name.DataPropertyName = "customer_comp_name";
            customer_comp_name.Frozen = true;
            customer_comp_name.HeaderText = "顧客名";
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
            paymentDataGridViewTextBoxColumn.Width = 80;
            // 
            // totalpriceDataGridViewTextBoxColumn
            // 
            totalpriceDataGridViewTextBoxColumn.DataPropertyName = "total_price";
            totalpriceDataGridViewTextBoxColumn.Frozen = true;
            totalpriceDataGridViewTextBoxColumn.HeaderText = "合計金額";
            totalpriceDataGridViewTextBoxColumn.MinimumWidth = 10;
            totalpriceDataGridViewTextBoxColumn.Name = "totalpriceDataGridViewTextBoxColumn";
            totalpriceDataGridViewTextBoxColumn.ReadOnly = true;
            totalpriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "status";
            statusDataGridViewTextBoxColumn.Frozen = true;
            statusDataGridViewTextBoxColumn.HeaderText = "対応状況";
            statusDataGridViewTextBoxColumn.MinimumWidth = 10;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            statusDataGridViewTextBoxColumn.Width = 80;
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
            // frmSippingList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 435);
            Controls.Add(groupBox1);
            Controls.Add(lblCount);
            Controls.Add(btnClose);
            Controls.Add(dgvMainList);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Controls.Add(txtOrderCode);
            Controls.Add(label1);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmSippingList";
            FormClosed += frmSippingList_FormClosed;
            Load += frmSipping_Load;
            KeyPress += frmSipping_KeyPress;
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoginName;
        private Label lblDate;
        private Label lblTitle;
        private TextBox txtOrderCode;
        private Label label1;
        private BindingSource bsBcartLink;
        private DataGridView dgvMainList;
        private DataGridViewTextBoxColumn ordered_at_txt;
        private Button btnClose;
        private Label lblCount;
        private GroupBox groupBox1;
        private Button btnSearch;
        private CheckBox chkOrderDate;
        private ComboBox cmbStatus;
        private Label label5;
        private Label label4;
        private DateTimePicker dtOrderTo;
        private DateTimePicker dtOrderFrom;
        private DataGridViewButtonColumn btnDetail;
        private DataGridViewTextBoxColumn ordercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ordered_at;
        private DataGridViewTextBoxColumn customerextidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customer_comp_name;
        private DataGridViewTextBoxColumn paymentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn reserved;
    }
}