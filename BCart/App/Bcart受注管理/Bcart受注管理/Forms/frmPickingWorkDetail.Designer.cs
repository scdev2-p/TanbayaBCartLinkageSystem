namespace Bcart受注管理.Forms
{
    partial class frmPickingWorkDetail
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
            lblDate = new Label();
            lblTitle = new Label();
            label11 = new Label();
            bsBcartLink = new BindingSource(components);
            label10 = new Label();
            label9 = new Label();
            LblOrderCode = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            bcOrderBindingSource = new BindingSource(components);
            label12 = new Label();
            dgvDetailList = new DataGridView();
            productsetcustoms1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderprocountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            picking_dtatus_disp = new DataGridViewTextBoxColumn();
            cCheck = new DataGridViewCheckBoxColumn();
            bcPickingDetailBindingSource = new BindingSource(components);
            btnClose = new Button();
            label13 = new Label();
            label14 = new Label();
            btnDoPicked = new Button();
            label15 = new Label();
            label16 = new Label();
            label8 = new Label();
            ToolTip = new ToolTip(components);
            label19 = new Label();
            label20 = new Label();
            label18 = new Label();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bcOrderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetailList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bcPickingDetailBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(835, 4);
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
            lblTitle.Size = new Size(670, 30);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(224, 224, 224);
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.DataBindings.Add(new Binding("Text", bsBcartLink, "customer_comp_name", true));
            label11.ForeColor = Color.Black;
            label11.Location = new Point(378, 112);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(245, 24);
            label11.TabIndex = 30;
            label11.Text = "label11";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label11, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // bsBcartLink
            // 
            bsBcartLink.DataMember = "S_SearchPicking";
            bsBcartLink.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(224, 224, 224);
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.DataBindings.Add(new Binding("Text", bsBcartLink, "customer_ext_id", true));
            label10.ForeColor = Color.Black;
            label10.Location = new Point(112, 112);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(149, 24);
            label10.TabIndex = 29;
            label10.Text = "label10";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label10, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(224, 224, 224);
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.DataBindings.Add(new Binding("Text", bsBcartLink, "ordered_at", true, DataSourceUpdateMode.OnValidation, null, "d"));
            label9.ForeColor = Color.Black;
            label9.Location = new Point(112, 64);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(149, 24);
            label9.TabIndex = 28;
            label9.Text = "label9";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label9, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // LblOrderCode
            // 
            LblOrderCode.BackColor = Color.FromArgb(224, 224, 224);
            LblOrderCode.BorderStyle = BorderStyle.Fixed3D;
            LblOrderCode.DataBindings.Add(new Binding("Text", bsBcartLink, "order_code", true));
            LblOrderCode.DataBindings.Add(new Binding("Tag", bsBcartLink, "order_id", true));
            LblOrderCode.ForeColor = Color.Black;
            LblOrderCode.Location = new Point(643, 40);
            LblOrderCode.Margin = new Padding(2, 0, 2, 0);
            LblOrderCode.Name = "LblOrderCode";
            LblOrderCode.Size = new Size(149, 24);
            LblOrderCode.TabIndex = 27;
            LblOrderCode.Text = "label8";
            LblOrderCode.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(LblOrderCode, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.White;
            label4.Location = new Point(272, 112);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 24);
            label4.TabIndex = 26;
            label4.Text = "顧客名";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.White;
            label3.Location = new Point(6, 112);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 24);
            label3.TabIndex = 25;
            label3.Text = "顧客管理番号";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 64);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 24;
            label2.Text = "受注日時";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.White;
            label1.Location = new Point(537, 40);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 24);
            label1.TabIndex = 23;
            label1.Text = "受注番号";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(224, 224, 224);
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.DataBindings.Add(new Binding("Text", bsBcartLink, "picking_code", true));
            label5.ForeColor = Color.Black;
            label5.Location = new Point(112, 40);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(149, 24);
            label5.TabIndex = 32;
            label5.Text = "label5";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label5, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(64, 64, 64);
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.White;
            label6.Location = new Point(6, 40);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(102, 24);
            label6.TabIndex = 31;
            label6.Text = "ピッキング番号";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(224, 224, 224);
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.DataBindings.Add(new Binding("Text", bsBcartLink, "customer_customs3", true));
            label7.ForeColor = Color.Black;
            label7.Location = new Point(112, 136);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(149, 24);
            label7.TabIndex = 34;
            label7.Text = "label7";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label7, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // bcOrderBindingSource
            // 
            bcOrderBindingSource.DataMember = "bc_Order";
            bcOrderBindingSource.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(64, 64, 64);
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.ForeColor = Color.White;
            label12.Location = new Point(6, 136);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(102, 24);
            label12.TabIndex = 33;
            label12.Text = "顧客コード";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvDetailList
            // 
            dgvDetailList.AllowUserToAddRows = false;
            dgvDetailList.AllowUserToDeleteRows = false;
            dgvDetailList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetailList.AutoGenerateColumns = false;
            dgvDetailList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailList.Columns.AddRange(new DataGridViewColumn[] { productsetcustoms1DataGridViewTextBoxColumn, productnameDataGridViewTextBoxColumn, unitpriceDataGridViewTextBoxColumn, orderprocountDataGridViewTextBoxColumn, picking_dtatus_disp, cCheck });
            dgvDetailList.DataSource = bcPickingDetailBindingSource;
            dgvDetailList.Location = new Point(6, 193);
            dgvDetailList.Margin = new Padding(2, 1, 2, 1);
            dgvDetailList.Name = "dgvDetailList";
            dgvDetailList.RowHeadersVisible = false;
            dgvDetailList.RowHeadersWidth = 82;
            dgvDetailList.Size = new Size(981, 202);
            dgvDetailList.TabIndex = 20;
            // 
            // productsetcustoms1DataGridViewTextBoxColumn
            // 
            productsetcustoms1DataGridViewTextBoxColumn.DataPropertyName = "product_set_customs1";
            productsetcustoms1DataGridViewTextBoxColumn.HeaderText = "バーコード";
            productsetcustoms1DataGridViewTextBoxColumn.MinimumWidth = 8;
            productsetcustoms1DataGridViewTextBoxColumn.Name = "productsetcustoms1DataGridViewTextBoxColumn";
            productsetcustoms1DataGridViewTextBoxColumn.ReadOnly = true;
            productsetcustoms1DataGridViewTextBoxColumn.Width = 150;
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            productnameDataGridViewTextBoxColumn.HeaderText = "商品名";
            productnameDataGridViewTextBoxColumn.MinimumWidth = 8;
            productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            productnameDataGridViewTextBoxColumn.ReadOnly = true;
            productnameDataGridViewTextBoxColumn.Width = 300;
            // 
            // unitpriceDataGridViewTextBoxColumn
            // 
            unitpriceDataGridViewTextBoxColumn.DataPropertyName = "unit_price";
            unitpriceDataGridViewTextBoxColumn.HeaderText = "単価";
            unitpriceDataGridViewTextBoxColumn.MinimumWidth = 8;
            unitpriceDataGridViewTextBoxColumn.Name = "unitpriceDataGridViewTextBoxColumn";
            unitpriceDataGridViewTextBoxColumn.ReadOnly = true;
            unitpriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // orderprocountDataGridViewTextBoxColumn
            // 
            orderprocountDataGridViewTextBoxColumn.DataPropertyName = "order_pro_count";
            orderprocountDataGridViewTextBoxColumn.HeaderText = "個数";
            orderprocountDataGridViewTextBoxColumn.MinimumWidth = 8;
            orderprocountDataGridViewTextBoxColumn.Name = "orderprocountDataGridViewTextBoxColumn";
            orderprocountDataGridViewTextBoxColumn.ReadOnly = true;
            orderprocountDataGridViewTextBoxColumn.Width = 150;
            // 
            // picking_dtatus_disp
            // 
            picking_dtatus_disp.DataPropertyName = "picking_dtatus_disp";
            picking_dtatus_disp.HeaderText = "ピッキング状態";
            picking_dtatus_disp.MinimumWidth = 8;
            picking_dtatus_disp.Name = "picking_dtatus_disp";
            picking_dtatus_disp.ReadOnly = true;
            picking_dtatus_disp.Width = 150;
            // 
            // cCheck
            // 
            cCheck.HeaderText = "欠品";
            cCheck.MinimumWidth = 8;
            cCheck.Name = "cCheck";
            cCheck.Width = 60;
            // 
            // bcPickingDetailBindingSource
            // 
            bcPickingDetailBindingSource.DataMember = "bc_PickingWorkDetail";
            bcPickingDetailBindingSource.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(907, 408);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 30;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label13
            // 
            label13.BackColor = Color.FromArgb(224, 224, 224);
            label13.BorderStyle = BorderStyle.Fixed3D;
            label13.DataBindings.Add(new Binding("Text", bsBcartLink, "floor_name", true));
            label13.ForeColor = Color.Black;
            label13.Location = new Point(378, 40);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(149, 24);
            label13.TabIndex = 43;
            label13.Text = "label13";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label13, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label14
            // 
            label14.BackColor = Color.FromArgb(64, 64, 64);
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.ForeColor = Color.White;
            label14.Location = new Point(272, 40);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(102, 24);
            label14.TabIndex = 42;
            label14.Text = "フロア";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnDoPicked
            // 
            btnDoPicked.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDoPicked.Location = new Point(822, 41);
            btnDoPicked.Name = "btnDoPicked";
            btnDoPicked.Size = new Size(166, 23);
            btnDoPicked.TabIndex = 10;
            btnDoPicked.Text = "ピッキング済にする";
            btnDoPicked.UseVisualStyleBackColor = true;
            btnDoPicked.Click += btnDoPicked_Click;
            // 
            // label15
            // 
            label15.BackColor = Color.FromArgb(224, 224, 224);
            label15.BorderStyle = BorderStyle.Fixed3D;
            label15.DataBindings.Add(new Binding("Text", bsBcartLink, "copy_status", true));
            label15.ForeColor = Color.Black;
            label15.Location = new Point(378, 136);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(149, 24);
            label15.TabIndex = 46;
            label15.Text = "label15";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label15, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label16
            // 
            label16.BackColor = Color.FromArgb(64, 64, 64);
            label16.BorderStyle = BorderStyle.Fixed3D;
            label16.ForeColor = Color.White;
            label16.Location = new Point(272, 136);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(102, 24);
            label16.TabIndex = 47;
            label16.Text = "印刷状況";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(64, 64, 64);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.ForeColor = Color.White;
            label8.Location = new Point(272, 64);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(102, 24);
            label8.TabIndex = 24;
            label8.Text = "配送希望日";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ToolTip
            // 
            ToolTip.ToolTipIcon = ToolTipIcon.Info;
            ToolTip.ToolTipTitle = "コピーできます";
            // 
            // label19
            // 
            label19.BackColor = Color.FromArgb(224, 224, 224);
            label19.BorderStyle = BorderStyle.Fixed3D;
            label19.DataBindings.Add(new Binding("Text", bsBcartLink, "due_date", true));
            label19.ForeColor = Color.Black;
            label19.Location = new Point(378, 64);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(149, 24);
            label19.TabIndex = 50;
            label19.Text = "label19";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label19, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label20
            // 
            label20.BackColor = Color.FromArgb(224, 224, 224);
            label20.BorderStyle = BorderStyle.Fixed3D;
            label20.DataBindings.Add(new Binding("Text", bsBcartLink, "due_time", true));
            label20.ForeColor = Color.Black;
            label20.Location = new Point(643, 64);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(149, 24);
            label20.TabIndex = 51;
            label20.Text = "label20";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label20, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label18
            // 
            label18.BackColor = Color.FromArgb(64, 64, 64);
            label18.BorderStyle = BorderStyle.Fixed3D;
            label18.ForeColor = Color.White;
            label18.Location = new Point(537, 64);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(102, 24);
            label18.TabIndex = 49;
            label18.Text = "出荷/取り置き";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmPickingWorkDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 435);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(btnDoPicked);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(btnClose);
            Controls.Add(dgvDetailList);
            Controls.Add(label7);
            Controls.Add(label12);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(LblOrderCode);
            Controls.Add(label4);
            Controls.Add(label8);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmPickingWorkDetail";
            Text = "frmPickingWorkDetail";
            FormClosed += frmPickingWorkDetail_FormClosed;
            Load += frmPickingWorkDetail_Load;
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).EndInit();
            ((System.ComponentModel.ISupportInitialize)bcOrderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetailList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bcPickingDetailBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLoginName;
        private Label lblDate;
        private Label lblTitle;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label LblOrderCode;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label12;
        private DataGridView dgvDetailList;
        private Button btnClose;
        private BindingSource bsBcartLink;
        private BindingSource bcPickingDetailBindingSource;
        private Label label13;
        private Label label14;
        private Button btnDoPicked;
        private Label label15;
        private Label label16;
        private BindingSource bcOrderBindingSource;
        private Label label8;
        private Label label17;
        private DataGridViewTextBoxColumn productsetcustoms1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderprocountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn picking_dtatus_disp;
        private DataGridViewCheckBoxColumn cCheck;
        private ToolTip ToolTip;
        private Label label18;
        private Label label19;
        private Label label20;
    }
}