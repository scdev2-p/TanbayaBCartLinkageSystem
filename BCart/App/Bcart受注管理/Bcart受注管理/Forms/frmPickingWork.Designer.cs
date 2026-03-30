namespace Bcart受注管理.Forms
{
    partial class frmPickingWork
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblDate = new Label();
            lblTitle = new Label();
            groupBox1 = new GroupBox();
            chkF9 = new CheckBox();
            chkF5 = new CheckBox();
            btnSearch = new Button();
            chkRegiDate = new CheckBox();
            chkF4 = new CheckBox();
            chkF3 = new CheckBox();
            chkF2 = new CheckBox();
            chkF1 = new CheckBox();
            cmbPickingStatus = new ComboBox();
            label2 = new Label();
            cmbStatus = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            dtOrderTo = new DateTimePicker();
            dtOrderFrom = new DateTimePicker();
            chkPreview = new CheckBox();
            btnDeliverySlipPrint = new Button();
            dgvMainList = new DataGridView();
            chk = new DataGridViewCheckBoxColumn();
            copystatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnDetail = new DataGridViewButtonColumn();
            pickingcodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            floor_name = new DataGridViewTextBoxColumn();
            pickingstatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderedatDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            due_date = new DataGridViewTextBoxColumn();
            due_time = new DataGridViewTextBoxColumn();
            ordercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customer_customs3 = new DataGridViewTextBoxColumn();
            customercompnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            order_status = new DataGridViewTextBoxColumn();
            bsBcartLink = new BindingSource(components);
            lblCount = new Label();
            btnClose = new Button();
            label1 = new Label();
            txtPickingCode = new TextBox();
            btnReloadOrder = new Button();
            btnOrder = new Button();
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
            lblDate.Location = new Point(635, 4);
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
            lblTitle.Size = new Size(470, 30);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(chkF9);
            groupBox1.Controls.Add(chkF5);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(chkRegiDate);
            groupBox1.Controls.Add(chkF4);
            groupBox1.Controls.Add(chkF3);
            groupBox1.Controls.Add(chkF2);
            groupBox1.Controls.Add(chkF1);
            groupBox1.Controls.Add(cmbPickingStatus);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtOrderTo);
            groupBox1.Controls.Add(dtOrderFrom);
            groupBox1.Location = new Point(11, 69);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(781, 80);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // chkF9
            // 
            chkF9.AutoSize = true;
            chkF9.Checked = true;
            chkF9.CheckState = CheckState.Checked;
            chkF9.Location = new Point(236, 54);
            chkF9.Margin = new Padding(2, 1, 2, 1);
            chkF9.Name = "chkF9";
            chkF9.Size = new Size(74, 19);
            chkF9.TabIndex = 112;
            chkF9.Text = "営業支援";
            chkF9.UseVisualStyleBackColor = true;
            // 
            // chkF5
            // 
            chkF5.AutoSize = true;
            chkF5.Checked = true;
            chkF5.CheckState = CheckState.Checked;
            chkF5.Location = new Point(189, 54);
            chkF5.Margin = new Padding(2, 1, 2, 1);
            chkF5.Name = "chkF5";
            chkF5.Size = new Size(44, 19);
            chkF5.TabIndex = 111;
            chkF5.Text = "5課";
            chkF5.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(624, 54);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(145, 22);
            btnSearch.TabIndex = 110;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // chkRegiDate
            // 
            chkRegiDate.AutoSize = true;
            chkRegiDate.Checked = true;
            chkRegiDate.CheckState = CheckState.Checked;
            chkRegiDate.Location = new Point(236, 24);
            chkRegiDate.Margin = new Padding(2, 1, 2, 1);
            chkRegiDate.Name = "chkRegiDate";
            chkRegiDate.Size = new Size(62, 19);
            chkRegiDate.TabIndex = 30;
            chkRegiDate.Text = "受注日";
            chkRegiDate.UseVisualStyleBackColor = true;
            // 
            // chkF4
            // 
            chkF4.AutoSize = true;
            chkF4.Checked = true;
            chkF4.CheckState = CheckState.Checked;
            chkF4.Location = new Point(147, 54);
            chkF4.Margin = new Padding(2, 1, 2, 1);
            chkF4.Name = "chkF4";
            chkF4.Size = new Size(38, 19);
            chkF4.TabIndex = 100;
            chkF4.Text = "4F";
            chkF4.UseVisualStyleBackColor = true;
            // 
            // chkF3
            // 
            chkF3.AutoSize = true;
            chkF3.Checked = true;
            chkF3.CheckState = CheckState.Checked;
            chkF3.Location = new Point(103, 54);
            chkF3.Margin = new Padding(2, 1, 2, 1);
            chkF3.Name = "chkF3";
            chkF3.Size = new Size(38, 19);
            chkF3.TabIndex = 90;
            chkF3.Text = "3F";
            chkF3.UseVisualStyleBackColor = true;
            // 
            // chkF2
            // 
            chkF2.AutoSize = true;
            chkF2.Checked = true;
            chkF2.CheckState = CheckState.Checked;
            chkF2.Location = new Point(59, 54);
            chkF2.Margin = new Padding(2, 1, 2, 1);
            chkF2.Name = "chkF2";
            chkF2.Size = new Size(38, 19);
            chkF2.TabIndex = 80;
            chkF2.Text = "2F";
            chkF2.UseVisualStyleBackColor = true;
            // 
            // chkF1
            // 
            chkF1.AutoSize = true;
            chkF1.Checked = true;
            chkF1.CheckState = CheckState.Checked;
            chkF1.Location = new Point(15, 54);
            chkF1.Margin = new Padding(2, 1, 2, 1);
            chkF1.Name = "chkF1";
            chkF1.Size = new Size(38, 19);
            chkF1.TabIndex = 70;
            chkF1.Text = "1F";
            chkF1.UseVisualStyleBackColor = true;
            // 
            // cmbPickingStatus
            // 
            cmbPickingStatus.FormattingEnabled = true;
            cmbPickingStatus.Items.AddRange(new object[] { "(すべて)", "新規注文", "ピック済" });
            cmbPickingStatus.Location = new Point(655, 22);
            cmbPickingStatus.Margin = new Padding(2, 1, 2, 1);
            cmbPickingStatus.Name = "cmbPickingStatus";
            cmbPickingStatus.Size = new Size(110, 23);
            cmbPickingStatus.TabIndex = 60;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(600, 26);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 8;
            label2.Text = "ピッキング";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "(すべて)", "新規注文", "ピック済" });
            cmbStatus.Location = new Point(70, 22);
            cmbStatus.Margin = new Padding(2, 1, 2, 1);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(110, 23);
            cmbStatus.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 26);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 8;
            label5.Text = "対応状況";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(414, 26);
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
            dtOrderTo.Location = new Point(437, 22);
            dtOrderTo.Margin = new Padding(2, 1, 2, 1);
            dtOrderTo.Name = "dtOrderTo";
            dtOrderTo.Size = new Size(108, 23);
            dtOrderTo.TabIndex = 50;
            // 
            // dtOrderFrom
            // 
            dtOrderFrom.Format = DateTimePickerFormat.Short;
            dtOrderFrom.Location = new Point(302, 22);
            dtOrderFrom.Margin = new Padding(2, 1, 2, 1);
            dtOrderFrom.Name = "dtOrderFrom";
            dtOrderFrom.Size = new Size(108, 23);
            dtOrderFrom.TabIndex = 40;
            // 
            // chkPreview
            // 
            chkPreview.AutoSize = true;
            chkPreview.Enabled = false;
            chkPreview.Location = new Point(268, 153);
            chkPreview.Margin = new Padding(2, 1, 2, 1);
            chkPreview.Name = "chkPreview";
            chkPreview.Size = new Size(67, 19);
            chkPreview.TabIndex = 130;
            chkPreview.Text = "プレビュー";
            chkPreview.UseVisualStyleBackColor = true;
            chkPreview.Visible = false;
            // 
            // btnDeliverySlipPrint
            // 
            btnDeliverySlipPrint.Location = new Point(6, 151);
            btnDeliverySlipPrint.Margin = new Padding(2, 1, 2, 1);
            btnDeliverySlipPrint.Name = "btnDeliverySlipPrint";
            btnDeliverySlipPrint.Size = new Size(150, 22);
            btnDeliverySlipPrint.TabIndex = 120;
            btnDeliverySlipPrint.Text = "ピッキング一覧印刷";
            btnDeliverySlipPrint.UseVisualStyleBackColor = true;
            btnDeliverySlipPrint.Click += btnDeliverySlipPrint_Click;
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { chk, copystatusDataGridViewTextBoxColumn, btnDetail, pickingcodeDataGridViewTextBoxColumn, floor_name, pickingstatusDataGridViewTextBoxColumn, orderedatDataGridViewTextBoxColumn, due_date, due_time, ordercodeDataGridViewTextBoxColumn, customer_customs3, customercompnameDataGridViewTextBoxColumn, order_status });
            dgvMainList.DataSource = bsBcartLink;
            dgvMainList.Location = new Point(6, 175);
            dgvMainList.Margin = new Padding(2, 1, 2, 1);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(778, 224);
            dgvMainList.TabIndex = 200;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            dgvMainList.CellFormatting += dgvMainList_CellFormatting;
            // 
            // chk
            // 
            chk.Frozen = true;
            chk.HeaderText = "選択";
            chk.MinimumWidth = 10;
            chk.Name = "chk";
            chk.Width = 40;
            // 
            // copystatusDataGridViewTextBoxColumn
            // 
            copystatusDataGridViewTextBoxColumn.DataPropertyName = "copy_status";
            copystatusDataGridViewTextBoxColumn.Frozen = true;
            copystatusDataGridViewTextBoxColumn.HeaderText = "印刷";
            copystatusDataGridViewTextBoxColumn.MinimumWidth = 8;
            copystatusDataGridViewTextBoxColumn.Name = "copystatusDataGridViewTextBoxColumn";
            copystatusDataGridViewTextBoxColumn.ReadOnly = true;
            copystatusDataGridViewTextBoxColumn.Width = 50;
            // 
            // btnDetail
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.NullValue = "詳細";
            btnDetail.DefaultCellStyle = dataGridViewCellStyle3;
            btnDetail.Frozen = true;
            btnDetail.HeaderText = "詳細";
            btnDetail.MinimumWidth = 10;
            btnDetail.Name = "btnDetail";
            btnDetail.Text = "詳細";
            btnDetail.Width = 50;
            // 
            // pickingcodeDataGridViewTextBoxColumn
            // 
            pickingcodeDataGridViewTextBoxColumn.DataPropertyName = "picking_code";
            pickingcodeDataGridViewTextBoxColumn.Frozen = true;
            pickingcodeDataGridViewTextBoxColumn.HeaderText = "ピッキング番号";
            pickingcodeDataGridViewTextBoxColumn.MinimumWidth = 10;
            pickingcodeDataGridViewTextBoxColumn.Name = "pickingcodeDataGridViewTextBoxColumn";
            pickingcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // floor_name
            // 
            floor_name.DataPropertyName = "floor_name";
            floor_name.Frozen = true;
            floor_name.HeaderText = "フロア";
            floor_name.MinimumWidth = 10;
            floor_name.Name = "floor_name";
            floor_name.ReadOnly = true;
            floor_name.Width = 50;
            // 
            // pickingstatusDataGridViewTextBoxColumn
            // 
            pickingstatusDataGridViewTextBoxColumn.DataPropertyName = "picking_status";
            pickingstatusDataGridViewTextBoxColumn.HeaderText = "ピッキング";
            pickingstatusDataGridViewTextBoxColumn.MinimumWidth = 10;
            pickingstatusDataGridViewTextBoxColumn.Name = "pickingstatusDataGridViewTextBoxColumn";
            pickingstatusDataGridViewTextBoxColumn.ReadOnly = true;
            pickingstatusDataGridViewTextBoxColumn.Width = 60;
            // 
            // orderedatDataGridViewTextBoxColumn
            // 
            orderedatDataGridViewTextBoxColumn.DataPropertyName = "ordered_at";
            dataGridViewCellStyle4.NullValue = null;
            orderedatDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            orderedatDataGridViewTextBoxColumn.HeaderText = "受注日";
            orderedatDataGridViewTextBoxColumn.MinimumWidth = 10;
            orderedatDataGridViewTextBoxColumn.Name = "orderedatDataGridViewTextBoxColumn";
            orderedatDataGridViewTextBoxColumn.ReadOnly = true;
            orderedatDataGridViewTextBoxColumn.Width = 80;
            // 
            // due_date
            // 
            due_date.DataPropertyName = "due_date";
            due_date.HeaderText = "配送希望日";
            due_date.MinimumWidth = 8;
            due_date.Name = "due_date";
            due_date.ReadOnly = true;
            due_date.Width = 80;
            // 
            // due_time
            // 
            due_time.DataPropertyName = "due_time";
            due_time.HeaderText = "出荷/取り置き";
            due_time.MinimumWidth = 8;
            due_time.Name = "due_time";
            due_time.ReadOnly = true;
            due_time.Width = 120;
            // 
            // ordercodeDataGridViewTextBoxColumn
            // 
            ordercodeDataGridViewTextBoxColumn.DataPropertyName = "order_code";
            ordercodeDataGridViewTextBoxColumn.HeaderText = "受注番号";
            ordercodeDataGridViewTextBoxColumn.MinimumWidth = 10;
            ordercodeDataGridViewTextBoxColumn.Name = "ordercodeDataGridViewTextBoxColumn";
            ordercodeDataGridViewTextBoxColumn.ReadOnly = true;
            ordercodeDataGridViewTextBoxColumn.Width = 80;
            // 
            // customer_customs3
            // 
            customer_customs3.DataPropertyName = "customer_customs3";
            customer_customs3.HeaderText = "顧客コード";
            customer_customs3.MinimumWidth = 8;
            customer_customs3.Name = "customer_customs3";
            customer_customs3.ReadOnly = true;
            customer_customs3.Width = 60;
            // 
            // customercompnameDataGridViewTextBoxColumn
            // 
            customercompnameDataGridViewTextBoxColumn.DataPropertyName = "customer_comp_name";
            customercompnameDataGridViewTextBoxColumn.HeaderText = "顧客名";
            customercompnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            customercompnameDataGridViewTextBoxColumn.Name = "customercompnameDataGridViewTextBoxColumn";
            customercompnameDataGridViewTextBoxColumn.ReadOnly = true;
            customercompnameDataGridViewTextBoxColumn.Width = 400;
            // 
            // order_status
            // 
            order_status.DataPropertyName = "order_status";
            order_status.HeaderText = "対応状況";
            order_status.MinimumWidth = 8;
            order_status.Name = "order_status";
            order_status.ReadOnly = true;
            order_status.Width = 150;
            // 
            // bsBcartLink
            // 
            bsBcartLink.DataMember = "S_SearchPicking";
            bsBcartLink.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // lblCount
            // 
            lblCount.BorderStyle = BorderStyle.Fixed3D;
            lblCount.Location = new Point(160, 152);
            lblCount.Margin = new Padding(2, 0, 2, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(104, 20);
            lblCount.TabIndex = 15;
            lblCount.Text = "label6";
            lblCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(703, 408);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 320;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 45);
            label1.Name = "label1";
            label1.Size = new Size(75, 15);
            label1.TabIndex = 16;
            label1.Text = "ピッキング番号";
            // 
            // txtPickingCode
            // 
            txtPickingCode.BackColor = Color.FromArgb(255, 224, 192);
            txtPickingCode.Location = new Point(81, 42);
            txtPickingCode.Name = "txtPickingCode";
            txtPickingCode.Size = new Size(125, 23);
            txtPickingCode.TabIndex = 1;
            txtPickingCode.KeyPress += txtPickingCode_KeyPress;
            // 
            // btnReloadOrder
            // 
            btnReloadOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReloadOrder.Location = new Point(143, 408);
            btnReloadOrder.Margin = new Padding(2, 1, 2, 1);
            btnReloadOrder.Name = "btnReloadOrder";
            btnReloadOrder.Size = new Size(133, 22);
            btnReloadOrder.TabIndex = 310;
            btnReloadOrder.Text = "BCart受注再取込";
            btnReloadOrder.UseVisualStyleBackColor = true;
            btnReloadOrder.Click += btnReloadOrder_Click;
            // 
            // btnOrder
            // 
            btnOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOrder.Location = new Point(6, 408);
            btnOrder.Margin = new Padding(2, 1, 2, 1);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(133, 22);
            btnOrder.TabIndex = 300;
            btnOrder.Text = "BCart受注管理";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnReserved
            // 
            btnReserved.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReserved.Location = new Point(280, 408);
            btnReserved.Margin = new Padding(2, 1, 2, 1);
            btnReserved.Name = "btnReserved";
            btnReserved.Size = new Size(133, 22);
            btnReserved.TabIndex = 321;
            btnReserved.Text = "取置一覧";
            btnReserved.UseVisualStyleBackColor = true;
            btnReserved.Click += btnReserved_Click;
            // 
            // frmPickingWork
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 435);
            Controls.Add(btnReserved);
            Controls.Add(btnOrder);
            Controls.Add(btnReloadOrder);
            Controls.Add(chkPreview);
            Controls.Add(txtPickingCode);
            Controls.Add(label1);
            Controls.Add(btnDeliverySlipPrint);
            Controls.Add(lblCount);
            Controls.Add(btnClose);
            Controls.Add(dgvMainList);
            Controls.Add(groupBox1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmPickingWork";
            Text = "ピッキング作業";
            FormClosed += frmPickingWork_FormClosed;
            Load += frmPickingWork_Load;
            KeyPress += frmPickingWork_KeyPress;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoginName;
        private Label lblDate;
        private Label lblTitle;
        private GroupBox groupBox1;
        private ComboBox cmbStatus;
        private Label label5;
        private Label label4;
        private DateTimePicker dtOrderTo;
        private DateTimePicker dtOrderFrom;
        private DataGridView dgvMainList;
        private Label lblPrinterDevice;
        private Button btnClose;
        private CheckBox chkF4;
        private CheckBox chkF3;
        private CheckBox chkF2;
        private CheckBox chkF1;
        private Button btnDeliverySlipPrint;
        private CheckBox chkPreview;
        private BindingSource bsBcartLink;
        private CheckBox chkRegiDate;
        private Label label1;
        private TextBox txtPickingCode;
        private Button btnSearch;
        private Label lblCount;
        private ComboBox cmbPickingStatus;
        private Label label2;
        private Button btnReloadOrder;
        private Button btnOrder;
        private DataGridViewCheckBoxColumn chk;
        private DataGridViewTextBoxColumn copystatusDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn btnDetail;
        private DataGridViewTextBoxColumn pickingcodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn floor_name;
        private DataGridViewTextBoxColumn pickingstatusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderedatDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn due_date;
        private DataGridViewTextBoxColumn due_time;
        private DataGridViewTextBoxColumn ordercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customer_customs3;
        private DataGridViewTextBoxColumn customercompnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn order_status;
        private CheckBox chkF5;
        private CheckBox chkF9;
        private Button btnReserved;
    }
}