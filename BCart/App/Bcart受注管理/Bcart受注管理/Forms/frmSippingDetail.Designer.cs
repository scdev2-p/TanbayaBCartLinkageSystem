namespace Bcart受注管理.Forms
{
    partial class frmSippingDetail
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
            bcOrderProductsBindingSource = new BindingSource(components);
            label27 = new Label();
            bcOrderBindingSource = new BindingSource(components);
            label26 = new Label();
            label25 = new Label();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            lblReserve = new Label();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            label16 = new Label();
            btnClose = new Button();
            label21 = new Label();
            label20 = new Label();
            label17 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            LblOrderCode = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            lblDate = new Label();
            lblTitle = new Label();
            dgvDetailList = new DataGridView();
            logistics_id = new DataGridViewTextBoxColumn();
            shipmentcodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            shipment_date = new DataGridViewTextBoxColumn();
            due_date = new DataGridViewTextBoxColumn();
            due_time = new DataGridViewTextBoxColumn();
            product_name = new DataGridViewTextBoxColumn();
            product_customs1 = new DataGridViewTextBoxColumn();
            unit_price = new DataGridViewTextBoxColumn();
            order_pro_count = new DataGridViewTextBoxColumn();
            tax_rate = new DataGridViewTextBoxColumn();
            label31 = new Label();
            txtSippingNo = new TextBox();
            label32 = new Label();
            dtSippingDate = new DateTimePicker();
            btnRegistSipping = new Button();
            label18 = new Label();
            panel1 = new Panel();
            ToolTip = new ToolTip(components);
            label8 = new Label();
            label19 = new Label();
            ((System.ComponentModel.ISupportInitialize)bcOrderProductsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bcOrderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetailList).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // bcOrderProductsBindingSource
            // 
            bcOrderProductsBindingSource.DataMember = "bc_OrderProducts";
            bcOrderProductsBindingSource.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // label27
            // 
            label27.BackColor = Color.FromArgb(224, 224, 224);
            label27.BorderStyle = BorderStyle.Fixed3D;
            label27.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "status", true));
            label27.ForeColor = Color.Black;
            label27.Location = new Point(646, 117);
            label27.Margin = new Padding(2, 0, 2, 0);
            label27.Name = "label27";
            label27.Size = new Size(149, 24);
            label27.TabIndex = 74;
            label27.Text = "label27";
            label27.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label27, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // bcOrderBindingSource
            // 
            bcOrderBindingSource.DataMember = "bc_Order";
            bcOrderBindingSource.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // label26
            // 
            label26.BackColor = Color.FromArgb(224, 224, 224);
            label26.BorderStyle = BorderStyle.Fixed3D;
            label26.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "final_price", true));
            label26.ForeColor = Color.Black;
            label26.Location = new Point(646, 93);
            label26.Margin = new Padding(2, 0, 2, 0);
            label26.Name = "label26";
            label26.Size = new Size(149, 24);
            label26.TabIndex = 73;
            label26.Text = "label26";
            label26.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label26, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label25
            // 
            label25.BackColor = Color.FromArgb(224, 224, 224);
            label25.BorderStyle = BorderStyle.Fixed3D;
            label25.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "shipping_cost", true));
            label25.ForeColor = Color.Black;
            label25.Location = new Point(646, 69);
            label25.Margin = new Padding(2, 0, 2, 0);
            label25.Name = "label25";
            label25.Size = new Size(149, 24);
            label25.TabIndex = 72;
            label25.Text = "label25";
            label25.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label25, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label24
            // 
            label24.BackColor = Color.FromArgb(224, 224, 224);
            label24.BorderStyle = BorderStyle.Fixed3D;
            label24.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "total_price", true));
            label24.ForeColor = Color.Black;
            label24.Location = new Point(646, 45);
            label24.Margin = new Padding(2, 0, 2, 0);
            label24.Name = "label24";
            label24.Size = new Size(149, 24);
            label24.TabIndex = 71;
            label24.Text = "label24";
            label24.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label24, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label23
            // 
            label23.BackColor = Color.FromArgb(64, 64, 64);
            label23.BorderStyle = BorderStyle.Fixed3D;
            label23.ForeColor = Color.White;
            label23.Location = new Point(541, 117);
            label23.Margin = new Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new Size(102, 24);
            label23.TabIndex = 70;
            label23.Text = "ステータス";
            label23.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            label22.BackColor = Color.FromArgb(64, 64, 64);
            label22.BorderStyle = BorderStyle.Fixed3D;
            label22.ForeColor = Color.White;
            label22.Location = new Point(541, 93);
            label22.Margin = new Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new Size(102, 24);
            label22.TabIndex = 69;
            label22.Text = "総額";
            label22.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblReserve
            // 
            lblReserve.ForeColor = Color.Red;
            lblReserve.Location = new Point(264, 93);
            lblReserve.Margin = new Padding(2, 0, 2, 0);
            lblReserve.Name = "lblReserve";
            lblReserve.Size = new Size(80, 24);
            lblReserve.TabIndex = 81;
            lblReserve.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            label30.ForeColor = Color.Red;
            label30.Location = new Point(264, 165);
            label30.Margin = new Padding(2, 0, 2, 0);
            label30.Name = "label30";
            label30.Size = new Size(102, 24);
            label30.TabIndex = 80;
            label30.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            label29.BackColor = Color.FromArgb(224, 224, 224);
            label29.BorderStyle = BorderStyle.Fixed3D;
            label29.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_email", true));
            label29.ForeColor = Color.Black;
            label29.Location = new Point(112, 285);
            label29.Margin = new Padding(2, 0, 2, 0);
            label29.Name = "label29";
            label29.Size = new Size(358, 24);
            label29.TabIndex = 79;
            label29.Text = "label29";
            label29.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label29, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label28
            // 
            label28.BackColor = Color.FromArgb(64, 64, 64);
            label28.BorderStyle = BorderStyle.Fixed3D;
            label28.ForeColor = Color.White;
            label28.Location = new Point(6, 285);
            label28.Margin = new Padding(2, 0, 2, 0);
            label28.Name = "label28";
            label28.Size = new Size(102, 24);
            label28.TabIndex = 78;
            label28.Text = "Eメール";
            label28.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.BackColor = Color.FromArgb(224, 224, 224);
            label16.BorderStyle = BorderStyle.Fixed3D;
            label16.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_address3", true));
            label16.ForeColor = Color.Black;
            label16.Location = new Point(112, 237);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(358, 24);
            label16.TabIndex = 77;
            label16.Text = "label16";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label16, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(731, 466);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 22);
            btnClose.TabIndex = 50;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label21
            // 
            label21.BackColor = Color.FromArgb(64, 64, 64);
            label21.BorderStyle = BorderStyle.Fixed3D;
            label21.ForeColor = Color.White;
            label21.Location = new Point(541, 69);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(102, 24);
            label21.TabIndex = 68;
            label21.Text = "送料";
            label21.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            label20.BackColor = Color.FromArgb(64, 64, 64);
            label20.BorderStyle = BorderStyle.Fixed3D;
            label20.ForeColor = Color.White;
            label20.Location = new Point(541, 45);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(102, 24);
            label20.TabIndex = 67;
            label20.Text = "合計金額";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(224, 224, 224);
            label17.BorderStyle = BorderStyle.Fixed3D;
            label17.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_tel", true));
            label17.ForeColor = Color.Black;
            label17.Location = new Point(112, 261);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(149, 24);
            label17.TabIndex = 66;
            label17.Text = "label17";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label17, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label15
            // 
            label15.BackColor = Color.FromArgb(224, 224, 224);
            label15.BorderStyle = BorderStyle.Fixed3D;
            label15.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_address2", true));
            label15.ForeColor = Color.Black;
            label15.Location = new Point(112, 213);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(358, 24);
            label15.TabIndex = 65;
            label15.Text = "label15";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label15, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label14
            // 
            label14.BackColor = Color.FromArgb(224, 224, 224);
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_address1", true));
            label14.ForeColor = Color.Black;
            label14.Location = new Point(112, 189);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(358, 24);
            label14.TabIndex = 64;
            label14.Text = "label14";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label14, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label13
            // 
            label13.BackColor = Color.FromArgb(224, 224, 224);
            label13.BorderStyle = BorderStyle.Fixed3D;
            label13.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_pref", true));
            label13.ForeColor = Color.Black;
            label13.Location = new Point(112, 165);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(149, 24);
            label13.TabIndex = 63;
            label13.Text = "label13";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label13, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(224, 224, 224);
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_zip", true));
            label12.ForeColor = Color.Black;
            label12.Location = new Point(112, 141);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(149, 24);
            label12.TabIndex = 62;
            label12.Text = "label12";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label12, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(224, 224, 224);
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_comp_name", true));
            label11.ForeColor = Color.Black;
            label11.Location = new Point(112, 117);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(245, 24);
            label11.TabIndex = 61;
            label11.Text = "label11";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label11, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(224, 224, 224);
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_ext_id", true));
            label10.ForeColor = Color.Black;
            label10.Location = new Point(112, 69);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(149, 24);
            label10.TabIndex = 60;
            label10.Text = "label10";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label10, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(224, 224, 224);
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "ordered_at", true, DataSourceUpdateMode.OnValidation, null, "G"));
            label9.ForeColor = Color.Black;
            label9.Location = new Point(380, 45);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(149, 24);
            label9.TabIndex = 59;
            label9.Text = "label9";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label9, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // LblOrderCode
            // 
            LblOrderCode.BackColor = Color.FromArgb(224, 224, 224);
            LblOrderCode.BorderStyle = BorderStyle.Fixed3D;
            LblOrderCode.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "order_code", true));
            LblOrderCode.ForeColor = Color.Black;
            LblOrderCode.Location = new Point(112, 45);
            LblOrderCode.Margin = new Padding(2, 0, 2, 0);
            LblOrderCode.Name = "LblOrderCode";
            LblOrderCode.Size = new Size(149, 24);
            LblOrderCode.TabIndex = 58;
            LblOrderCode.Text = "label8";
            LblOrderCode.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(LblOrderCode, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(64, 64, 64);
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.ForeColor = Color.White;
            label7.Location = new Point(6, 261);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(102, 24);
            label7.TabIndex = 57;
            label7.Text = "電話番号";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(64, 64, 64);
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.White;
            label6.Location = new Point(6, 165);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(102, 24);
            label6.TabIndex = 56;
            label6.Text = "住所";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.ForeColor = Color.White;
            label5.Location = new Point(6, 141);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(102, 24);
            label5.TabIndex = 55;
            label5.Text = "郵便番号";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.White;
            label4.Location = new Point(6, 117);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 24);
            label4.TabIndex = 54;
            label4.Text = "顧客名";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.White;
            label3.Location = new Point(6, 69);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 24);
            label3.TabIndex = 53;
            label3.Text = "顧客管理番号";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(274, 45);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 52;
            label2.Text = "受注日時";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 45);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 24);
            label1.TabIndex = 51;
            label1.Text = "受注番号";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(689, 5);
            lblDate.Margin = new Padding(2, 0, 2, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(152, 30);
            lblDate.TabIndex = 49;
            lblDate.Text = "9999年99月99日(月)";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTitle.Location = new Point(6, 5);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(523, 30);
            lblTitle.TabIndex = 48;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvDetailList
            // 
            dgvDetailList.AllowUserToAddRows = false;
            dgvDetailList.AllowUserToDeleteRows = false;
            dgvDetailList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetailList.AutoGenerateColumns = false;
            dgvDetailList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailList.Columns.AddRange(new DataGridViewColumn[] { logistics_id, shipmentcodeDataGridViewTextBoxColumn, status, shipment_date, due_date, due_time, product_name, product_customs1, unit_price, order_pro_count, tax_rate });
            dgvDetailList.DataSource = bcOrderProductsBindingSource;
            dgvDetailList.Location = new Point(6, 320);
            dgvDetailList.Margin = new Padding(2, 1, 2, 1);
            dgvDetailList.Name = "dgvDetailList";
            dgvDetailList.ReadOnly = true;
            dgvDetailList.RowHeadersVisible = false;
            dgvDetailList.RowHeadersWidth = 82;
            dgvDetailList.Size = new Size(831, 144);
            dgvDetailList.TabIndex = 40;
            // 
            // logistics_id
            // 
            logistics_id.DataPropertyName = "logistics_id";
            logistics_id.HeaderText = "Bカート発送ID";
            logistics_id.MinimumWidth = 8;
            logistics_id.Name = "logistics_id";
            logistics_id.ReadOnly = true;
            logistics_id.Width = 150;
            // 
            // shipmentcodeDataGridViewTextBoxColumn
            // 
            shipmentcodeDataGridViewTextBoxColumn.DataPropertyName = "shipment_code";
            shipmentcodeDataGridViewTextBoxColumn.HeaderText = "送り状番号";
            shipmentcodeDataGridViewTextBoxColumn.Name = "shipmentcodeDataGridViewTextBoxColumn";
            shipmentcodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // status
            // 
            status.DataPropertyName = "status";
            status.HeaderText = "配送状況";
            status.MinimumWidth = 8;
            status.Name = "status";
            status.ReadOnly = true;
            status.Width = 150;
            // 
            // shipment_date
            // 
            shipment_date.DataPropertyName = "shipment_date";
            shipment_date.HeaderText = "発送日";
            shipment_date.MinimumWidth = 8;
            shipment_date.Name = "shipment_date";
            shipment_date.ReadOnly = true;
            // 
            // due_date
            // 
            due_date.DataPropertyName = "due_date";
            due_date.HeaderText = "配送希望日";
            due_date.MinimumWidth = 8;
            due_date.Name = "due_date";
            due_date.ReadOnly = true;
            // 
            // due_time
            // 
            due_time.DataPropertyName = "due_time";
            due_time.HeaderText = "配送希望時間";
            due_time.MinimumWidth = 8;
            due_time.Name = "due_time";
            due_time.ReadOnly = true;
            due_time.Width = 110;
            // 
            // product_name
            // 
            product_name.DataPropertyName = "product_name";
            product_name.HeaderText = "商品名";
            product_name.MinimumWidth = 8;
            product_name.Name = "product_name";
            product_name.ReadOnly = true;
            product_name.Width = 300;
            // 
            // product_customs1
            // 
            product_customs1.DataPropertyName = "product_set_customs1";
            product_customs1.HeaderText = "JAN";
            product_customs1.MinimumWidth = 8;
            product_customs1.Name = "product_customs1";
            product_customs1.ReadOnly = true;
            product_customs1.Width = 150;
            // 
            // unit_price
            // 
            unit_price.DataPropertyName = "unit_price";
            unit_price.HeaderText = "単価";
            unit_price.MinimumWidth = 8;
            unit_price.Name = "unit_price";
            unit_price.ReadOnly = true;
            unit_price.Width = 150;
            // 
            // order_pro_count
            // 
            order_pro_count.DataPropertyName = "order_pro_count";
            order_pro_count.HeaderText = "注文数";
            order_pro_count.MinimumWidth = 8;
            order_pro_count.Name = "order_pro_count";
            order_pro_count.ReadOnly = true;
            order_pro_count.Width = 150;
            // 
            // tax_rate
            // 
            tax_rate.DataPropertyName = "tax_rate";
            tax_rate.HeaderText = "税率";
            tax_rate.MinimumWidth = 8;
            tax_rate.Name = "tax_rate";
            tax_rate.ReadOnly = true;
            tax_rate.Width = 150;
            // 
            // label31
            // 
            label31.Location = new Point(7, 3);
            label31.Margin = new Padding(2, 0, 2, 0);
            label31.Name = "label31";
            label31.Size = new Size(72, 23);
            label31.TabIndex = 0;
            label31.Text = "送り状番号";
            label31.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSippingNo
            // 
            txtSippingNo.Location = new Point(85, 6);
            txtSippingNo.Margin = new Padding(2, 1, 2, 1);
            txtSippingNo.MaxLength = 255;
            txtSippingNo.Name = "txtSippingNo";
            txtSippingNo.Size = new Size(134, 23);
            txtSippingNo.TabIndex = 10;
            // 
            // label32
            // 
            label32.Location = new Point(7, 26);
            label32.Margin = new Padding(2, 0, 2, 0);
            label32.Name = "label32";
            label32.Size = new Size(72, 23);
            label32.TabIndex = 2;
            label32.Text = "発送日";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtSippingDate
            // 
            dtSippingDate.Location = new Point(85, 31);
            dtSippingDate.Margin = new Padding(2, 1, 2, 1);
            dtSippingDate.Name = "dtSippingDate";
            dtSippingDate.Size = new Size(134, 23);
            dtSippingDate.TabIndex = 20;
            // 
            // btnRegistSipping
            // 
            btnRegistSipping.Location = new Point(90, 101);
            btnRegistSipping.Margin = new Padding(2, 1, 2, 1);
            btnRegistSipping.Name = "btnRegistSipping";
            btnRegistSipping.Size = new Size(129, 24);
            btnRegistSipping.TabIndex = 30;
            btnRegistSipping.Text = "出荷登録実行";
            btnRegistSipping.UseVisualStyleBackColor = true;
            btnRegistSipping.Click += btnRegistSipping_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.ImageAlign = ContentAlignment.MiddleRight;
            label18.Location = new Point(85, 70);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(0, 15);
            label18.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 255, 192);
            panel1.Controls.Add(label18);
            panel1.Controls.Add(btnRegistSipping);
            panel1.Controls.Add(dtSippingDate);
            panel1.Controls.Add(label32);
            panel1.Controls.Add(txtSippingNo);
            panel1.Controls.Add(label31);
            panel1.Location = new Point(541, 172);
            panel1.Margin = new Padding(2, 1, 2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 137);
            panel1.TabIndex = 84;
            // 
            // ToolTip
            // 
            ToolTip.ToolTipIcon = ToolTipIcon.Info;
            ToolTip.ToolTipTitle = "コピーできます";
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(64, 64, 64);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.ForeColor = Color.White;
            label8.Location = new Point(6, 93);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(102, 24);
            label8.TabIndex = 53;
            label8.Text = "顧客コード";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            label19.BackColor = Color.FromArgb(224, 224, 224);
            label19.BorderStyle = BorderStyle.Fixed3D;
            label19.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_customs3", true));
            label19.ForeColor = Color.Black;
            label19.Location = new Point(112, 93);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(149, 24);
            label19.TabIndex = 60;
            label19.Text = "label10";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // frmSippingDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 497);
            Controls.Add(panel1);
            Controls.Add(dgvDetailList);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(btnClose);
            Controls.Add(label25);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(label22);
            Controls.Add(lblReserve);
            Controls.Add(label30);
            Controls.Add(label29);
            Controls.Add(label28);
            Controls.Add(label16);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label17);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label19);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(LblOrderCode);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label8);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmSippingDetail";
            Text = "frmSippingDetail";
            FormClosed += frmSippingDetail_FormClosed;
            Load += frmSippingDetail_Load;
            ((System.ComponentModel.ISupportInitialize)bcOrderProductsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bcOrderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetailList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource bcOrderProductsBindingSource;
        private Label label27;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label lblReserve;
        private Label label30;
        private Label label29;
        private BindingSource bcOrderBindingSource;
        private Label label28;
        private Label label16;
        private Button btnClose;
        private Label label21;
        private Label label20;
        private Label label17;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label LblOrderCode;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblDate;
        private Label lblTitle;
        private Label lblLoginName;
        private Panel panel1;
        private Label label31;
        private Button btnRegistSipping;
        private DateTimePicker dtSippingDate;
        private Label label32;
        private TextBox txtSippingNo;
        private DataGridViewTextBoxColumn 税率;
        private Label label18;
        private DataGridView dgvDetailList;
        private ToolTip ToolTip;
        private DataGridViewTextBoxColumn logistics_id;
        private DataGridViewTextBoxColumn shipmentcodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn status;
        private DataGridViewTextBoxColumn shipment_date;
        private DataGridViewTextBoxColumn due_date;
        private DataGridViewTextBoxColumn due_time;
        private DataGridViewTextBoxColumn product_name;
        private DataGridViewTextBoxColumn product_customs1;
        private DataGridViewTextBoxColumn unit_price;
        private DataGridViewTextBoxColumn order_pro_count;
        private DataGridViewTextBoxColumn tax_rate;
        private Label label8;
        private Label label19;
    }
}