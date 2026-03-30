namespace Bcart受注管理.Forms
{
    partial class frmOrderDetail
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblDate = new Label();
            lblTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            bcOrderBindingSource = new BindingSource(components);
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label17 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            label25 = new Label();
            label26 = new Label();
            label27 = new Label();
            dgvDetailList = new DataGridView();
            productnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productsetcustoms1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderprocountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            taxrateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bcOrderProductsBindingSource = new BindingSource(components);
            btnClose = new Button();
            label16 = new Label();
            label28 = new Label();
            label29 = new Label();
            label30 = new Label();
            lblReserve = new Label();
            label31 = new Label();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            label35 = new Label();
            label36 = new Label();
            bsTnbLink = new BindingSource(components);
            label18 = new Label();
            txtOrderCode = new TextBox();
            ToolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)bcOrderBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetailList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bcOrderProductsBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsTnbLink).BeginInit();
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
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.White;
            label1.Location = new Point(6, 45);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 24);
            label1.TabIndex = 12;
            label1.Text = "受注番号";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(6, 69);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 13;
            label2.Text = "受注日時";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.White;
            label3.Location = new Point(6, 117);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(102, 24);
            label3.TabIndex = 14;
            label3.Text = "顧客コード";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.White;
            label4.Location = new Point(6, 141);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 24);
            label4.TabIndex = 15;
            label4.Text = "顧客名";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.ForeColor = Color.White;
            label5.Location = new Point(6, 170);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(102, 24);
            label5.TabIndex = 16;
            label5.Text = "郵便番号";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(64, 64, 64);
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.White;
            label6.Location = new Point(6, 194);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(102, 24);
            label6.TabIndex = 17;
            label6.Text = "住所";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(64, 64, 64);
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.ForeColor = Color.White;
            label7.Location = new Point(6, 290);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(102, 24);
            label7.TabIndex = 18;
            label7.Text = "電話番号";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(224, 224, 224);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "order_code", true));
            label8.ForeColor = Color.Black;
            label8.Location = new Point(112, 45);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(149, 24);
            label8.TabIndex = 19;
            label8.Text = "label8";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label8, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // bcOrderBindingSource
            // 
            bcOrderBindingSource.DataMember = "bc_Order";
            bcOrderBindingSource.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(224, 224, 224);
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "ordered_at", true, DataSourceUpdateMode.OnValidation, null, "G"));
            label9.ForeColor = Color.Black;
            label9.Location = new Point(112, 69);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(149, 24);
            label9.TabIndex = 20;
            label9.Text = "label9";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label9, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(224, 224, 224);
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_customs3", true));
            label10.ForeColor = Color.Black;
            label10.Location = new Point(112, 118);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(149, 24);
            label10.TabIndex = 21;
            label10.Text = "label10";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label10, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(224, 224, 224);
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_comp_name", true));
            label11.ForeColor = Color.Black;
            label11.Location = new Point(112, 141);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(245, 24);
            label11.TabIndex = 22;
            label11.Text = "label11";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label11, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(224, 224, 224);
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_zip", true));
            label12.ForeColor = Color.Black;
            label12.Location = new Point(112, 170);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(149, 24);
            label12.TabIndex = 23;
            label12.Text = "label12";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label12, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label13
            // 
            label13.BackColor = Color.FromArgb(224, 224, 224);
            label13.BorderStyle = BorderStyle.Fixed3D;
            label13.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_pref", true));
            label13.ForeColor = Color.Black;
            label13.Location = new Point(112, 194);
            label13.Margin = new Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new Size(149, 24);
            label13.TabIndex = 24;
            label13.Text = "label13";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label13, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label14
            // 
            label14.BackColor = Color.FromArgb(224, 224, 224);
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_address1", true));
            label14.ForeColor = Color.Black;
            label14.Location = new Point(112, 218);
            label14.Margin = new Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new Size(509, 24);
            label14.TabIndex = 25;
            label14.Text = "label14";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label14, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label15
            // 
            label15.BackColor = Color.FromArgb(224, 224, 224);
            label15.BorderStyle = BorderStyle.Fixed3D;
            label15.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_address2", true));
            label15.ForeColor = Color.Black;
            label15.Location = new Point(112, 242);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(509, 24);
            label15.TabIndex = 26;
            label15.Text = "label15";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label15, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label17
            // 
            label17.BackColor = Color.FromArgb(224, 224, 224);
            label17.BorderStyle = BorderStyle.Fixed3D;
            label17.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_tel", true));
            label17.ForeColor = Color.Black;
            label17.Location = new Point(112, 290);
            label17.Margin = new Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new Size(149, 24);
            label17.TabIndex = 28;
            label17.Text = "label17";
            label17.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label17, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label20
            // 
            label20.BackColor = Color.FromArgb(64, 64, 64);
            label20.BorderStyle = BorderStyle.Fixed3D;
            label20.ForeColor = Color.White;
            label20.Location = new Point(370, 93);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(109, 24);
            label20.TabIndex = 31;
            label20.Text = "消費税";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            label21.BackColor = Color.FromArgb(64, 64, 64);
            label21.BorderStyle = BorderStyle.Fixed3D;
            label21.ForeColor = Color.White;
            label21.Location = new Point(370, 117);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(109, 24);
            label21.TabIndex = 32;
            label21.Text = "送料";
            label21.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            label22.BackColor = Color.FromArgb(64, 64, 64);
            label22.BorderStyle = BorderStyle.Fixed3D;
            label22.ForeColor = Color.White;
            label22.Location = new Point(370, 141);
            label22.Margin = new Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new Size(109, 24);
            label22.TabIndex = 33;
            label22.Text = "受注総額";
            label22.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            label23.BackColor = Color.FromArgb(64, 64, 64);
            label23.BorderStyle = BorderStyle.Fixed3D;
            label23.ForeColor = Color.White;
            label23.Location = new Point(370, 165);
            label23.Margin = new Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new Size(109, 24);
            label23.TabIndex = 34;
            label23.Text = "対応状況";
            label23.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            label24.BackColor = Color.FromArgb(224, 224, 224);
            label24.BorderStyle = BorderStyle.Fixed3D;
            label24.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "tax", true, DataSourceUpdateMode.OnValidation, null, "C0"));
            label24.ForeColor = Color.Black;
            label24.Location = new Point(483, 93);
            label24.Margin = new Padding(2, 0, 2, 0);
            label24.Name = "label24";
            label24.Size = new Size(141, 24);
            label24.TabIndex = 35;
            label24.Text = "label24";
            label24.TextAlign = ContentAlignment.MiddleRight;
            ToolTip.SetToolTip(label24, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label25
            // 
            label25.BackColor = Color.FromArgb(224, 224, 224);
            label25.BorderStyle = BorderStyle.Fixed3D;
            label25.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "shipping_cost", true, DataSourceUpdateMode.OnValidation, null, "C0"));
            label25.ForeColor = Color.Black;
            label25.Location = new Point(483, 117);
            label25.Margin = new Padding(2, 0, 2, 0);
            label25.Name = "label25";
            label25.Size = new Size(141, 24);
            label25.TabIndex = 36;
            label25.Text = "label25";
            label25.TextAlign = ContentAlignment.MiddleRight;
            ToolTip.SetToolTip(label25, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label26
            // 
            label26.BackColor = Color.FromArgb(224, 224, 224);
            label26.BorderStyle = BorderStyle.Fixed3D;
            label26.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "final_price", true, DataSourceUpdateMode.OnValidation, null, "C0"));
            label26.ForeColor = Color.Black;
            label26.Location = new Point(483, 141);
            label26.Margin = new Padding(2, 0, 2, 0);
            label26.Name = "label26";
            label26.Size = new Size(141, 24);
            label26.TabIndex = 37;
            label26.Text = "label26";
            label26.TextAlign = ContentAlignment.MiddleRight;
            ToolTip.SetToolTip(label26, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label27
            // 
            label27.BackColor = Color.FromArgb(224, 224, 224);
            label27.BorderStyle = BorderStyle.Fixed3D;
            label27.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "status", true));
            label27.ForeColor = Color.Black;
            label27.Location = new Point(483, 165);
            label27.Margin = new Padding(2, 0, 2, 0);
            label27.Name = "label27";
            label27.Size = new Size(141, 24);
            label27.TabIndex = 38;
            label27.Text = "label27";
            label27.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label27, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // dgvDetailList
            // 
            dgvDetailList.AllowUserToAddRows = false;
            dgvDetailList.AllowUserToDeleteRows = false;
            dgvDetailList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvDetailList.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDetailList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDetailList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetailList.Columns.AddRange(new DataGridViewColumn[] { productnameDataGridViewTextBoxColumn, productsetcustoms1DataGridViewTextBoxColumn, unitpriceDataGridViewTextBoxColumn, orderprocountDataGridViewTextBoxColumn, taxrateDataGridViewTextBoxColumn });
            dgvDetailList.DataSource = bcOrderProductsBindingSource;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvDetailList.DefaultCellStyle = dataGridViewCellStyle5;
            dgvDetailList.Location = new Point(6, 459);
            dgvDetailList.Margin = new Padding(2, 1, 2, 1);
            dgvDetailList.Name = "dgvDetailList";
            dgvDetailList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvDetailList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvDetailList.RowHeadersVisible = false;
            dgvDetailList.RowHeadersWidth = 82;
            dgvDetailList.Size = new Size(619, 75);
            dgvDetailList.TabIndex = 39;
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            productnameDataGridViewTextBoxColumn.HeaderText = "商品名";
            productnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            productnameDataGridViewTextBoxColumn.ReadOnly = true;
            productnameDataGridViewTextBoxColumn.Width = 600;
            // 
            // productsetcustoms1DataGridViewTextBoxColumn
            // 
            productsetcustoms1DataGridViewTextBoxColumn.DataPropertyName = "product_set_customs1";
            productsetcustoms1DataGridViewTextBoxColumn.HeaderText = "JAN";
            productsetcustoms1DataGridViewTextBoxColumn.MinimumWidth = 10;
            productsetcustoms1DataGridViewTextBoxColumn.Name = "productsetcustoms1DataGridViewTextBoxColumn";
            productsetcustoms1DataGridViewTextBoxColumn.ReadOnly = true;
            productsetcustoms1DataGridViewTextBoxColumn.Width = 160;
            // 
            // unitpriceDataGridViewTextBoxColumn
            // 
            unitpriceDataGridViewTextBoxColumn.DataPropertyName = "unit_price";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C0";
            dataGridViewCellStyle2.NullValue = null;
            unitpriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            unitpriceDataGridViewTextBoxColumn.HeaderText = "単価";
            unitpriceDataGridViewTextBoxColumn.MinimumWidth = 10;
            unitpriceDataGridViewTextBoxColumn.Name = "unitpriceDataGridViewTextBoxColumn";
            unitpriceDataGridViewTextBoxColumn.ReadOnly = true;
            unitpriceDataGridViewTextBoxColumn.Width = 150;
            // 
            // orderprocountDataGridViewTextBoxColumn
            // 
            orderprocountDataGridViewTextBoxColumn.DataPropertyName = "order_pro_count";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            orderprocountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            orderprocountDataGridViewTextBoxColumn.HeaderText = "注文数";
            orderprocountDataGridViewTextBoxColumn.MinimumWidth = 10;
            orderprocountDataGridViewTextBoxColumn.Name = "orderprocountDataGridViewTextBoxColumn";
            orderprocountDataGridViewTextBoxColumn.ReadOnly = true;
            orderprocountDataGridViewTextBoxColumn.Width = 150;
            // 
            // taxrateDataGridViewTextBoxColumn
            // 
            taxrateDataGridViewTextBoxColumn.DataPropertyName = "tax_rate";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            taxrateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            taxrateDataGridViewTextBoxColumn.HeaderText = "税率";
            taxrateDataGridViewTextBoxColumn.MinimumWidth = 10;
            taxrateDataGridViewTextBoxColumn.Name = "taxrateDataGridViewTextBoxColumn";
            taxrateDataGridViewTextBoxColumn.ReadOnly = true;
            taxrateDataGridViewTextBoxColumn.Width = 150;
            // 
            // bcOrderProductsBindingSource
            // 
            bcOrderProductsBindingSource.DataMember = "bc_OrderProducts";
            bcOrderProductsBindingSource.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(545, 544);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 40;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label16
            // 
            label16.BackColor = Color.FromArgb(224, 224, 224);
            label16.BorderStyle = BorderStyle.Fixed3D;
            label16.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_address3", true));
            label16.ForeColor = Color.Black;
            label16.Location = new Point(112, 266);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(509, 24);
            label16.TabIndex = 41;
            label16.Text = "label16";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label16, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label28
            // 
            label28.BackColor = Color.FromArgb(64, 64, 64);
            label28.BorderStyle = BorderStyle.Fixed3D;
            label28.ForeColor = Color.White;
            label28.Location = new Point(6, 314);
            label28.Margin = new Padding(2, 0, 2, 0);
            label28.Name = "label28";
            label28.Size = new Size(102, 24);
            label28.TabIndex = 42;
            label28.Text = "Eメール";
            label28.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            label29.BackColor = Color.FromArgb(224, 224, 224);
            label29.BorderStyle = BorderStyle.Fixed3D;
            label29.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_email", true));
            label29.ForeColor = Color.Black;
            label29.Location = new Point(112, 314);
            label29.Margin = new Padding(2, 0, 2, 0);
            label29.Name = "label29";
            label29.Size = new Size(509, 24);
            label29.TabIndex = 43;
            label29.Text = "label29";
            label29.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label29, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label30
            // 
            label30.ForeColor = Color.Red;
            label30.Location = new Point(264, 194);
            label30.Margin = new Padding(2, 0, 2, 0);
            label30.Name = "label30";
            label30.Size = new Size(102, 24);
            label30.TabIndex = 44;
            label30.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblReserve
            // 
            lblReserve.ForeColor = Color.Red;
            lblReserve.Location = new Point(264, 117);
            lblReserve.Margin = new Padding(2, 0, 2, 0);
            lblReserve.Name = "lblReserve";
            lblReserve.Size = new Size(80, 24);
            lblReserve.TabIndex = 45;
            lblReserve.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            label31.BackColor = Color.FromArgb(224, 224, 224);
            label31.BorderStyle = BorderStyle.Fixed3D;
            label31.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_ext_id", true));
            label31.ForeColor = Color.Black;
            label31.Location = new Point(112, 93);
            label31.Margin = new Padding(2, 0, 2, 0);
            label31.Name = "label31";
            label31.Size = new Size(149, 24);
            label31.TabIndex = 49;
            label31.Text = "label31";
            label31.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label31, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label32
            // 
            label32.BackColor = Color.FromArgb(64, 64, 64);
            label32.BorderStyle = BorderStyle.Fixed3D;
            label32.ForeColor = Color.White;
            label32.Location = new Point(6, 93);
            label32.Margin = new Padding(2, 0, 2, 0);
            label32.Name = "label32";
            label32.Size = new Size(102, 24);
            label32.TabIndex = 48;
            label32.Text = "顧客管理番号";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            label33.BackColor = Color.FromArgb(224, 224, 224);
            label33.BorderStyle = BorderStyle.Fixed3D;
            label33.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "payment", true));
            label33.ForeColor = Color.Black;
            label33.Location = new Point(483, 45);
            label33.Margin = new Padding(2, 0, 2, 0);
            label33.Name = "label33";
            label33.Size = new Size(141, 24);
            label33.TabIndex = 51;
            label33.Text = "label33";
            label33.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(label33, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label34
            // 
            label34.BackColor = Color.FromArgb(64, 64, 64);
            label34.BorderStyle = BorderStyle.Fixed3D;
            label34.ForeColor = Color.White;
            label34.Location = new Point(370, 45);
            label34.Margin = new Padding(2, 0, 2, 0);
            label34.Name = "label34";
            label34.Size = new Size(109, 24);
            label34.TabIndex = 50;
            label34.Text = "支払方法";
            label34.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            label35.BackColor = Color.FromArgb(224, 224, 224);
            label35.BorderStyle = BorderStyle.Fixed3D;
            label35.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "total_price", true, DataSourceUpdateMode.OnValidation, null, "C0"));
            label35.ForeColor = Color.Black;
            label35.Location = new Point(483, 69);
            label35.Margin = new Padding(2, 0, 2, 0);
            label35.Name = "label35";
            label35.Size = new Size(141, 24);
            label35.TabIndex = 53;
            label35.Text = "label35";
            label35.TextAlign = ContentAlignment.MiddleRight;
            ToolTip.SetToolTip(label35, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label36
            // 
            label36.BackColor = Color.FromArgb(64, 64, 64);
            label36.BorderStyle = BorderStyle.Fixed3D;
            label36.ForeColor = Color.White;
            label36.Location = new Point(370, 69);
            label36.Margin = new Padding(2, 0, 2, 0);
            label36.Name = "label36";
            label36.Size = new Size(109, 24);
            label36.TabIndex = 52;
            label36.Text = "合計金額（税込）";
            label36.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bsTnbLink
            // 
            bsTnbLink.DataMember = "T_取置";
            bsTnbLink.DataSource = typeof(AppData.Ds.dsTnb);
            // 
            // label18
            // 
            label18.BackColor = Color.FromArgb(64, 64, 64);
            label18.BorderStyle = BorderStyle.Fixed3D;
            label18.ForeColor = Color.White;
            label18.Location = new Point(6, 342);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(102, 24);
            label18.TabIndex = 54;
            label18.Text = "お客様からの連絡";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtOrderCode
            // 
            txtOrderCode.DataBindings.Add(new Binding("Text", bcOrderBindingSource, "customer_message", true));
            txtOrderCode.Location = new Point(112, 342);
            txtOrderCode.Margin = new Padding(2, 1, 2, 1);
            txtOrderCode.Multiline = true;
            txtOrderCode.Name = "txtOrderCode";
            txtOrderCode.ReadOnly = true;
            txtOrderCode.ScrollBars = ScrollBars.Vertical;
            txtOrderCode.Size = new Size(509, 96);
            txtOrderCode.TabIndex = 56;
            txtOrderCode.TabStop = false;
            // 
            // ToolTip
            // 
            ToolTip.ToolTipIcon = ToolTipIcon.Info;
            ToolTip.ToolTipTitle = "コピーできます";
            // 
            // frmOrderDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 539);
            Controls.Add(label18);
            Controls.Add(label35);
            Controls.Add(label36);
            Controls.Add(label33);
            Controls.Add(label34);
            Controls.Add(label31);
            Controls.Add(label32);
            Controls.Add(lblReserve);
            Controls.Add(label30);
            Controls.Add(label29);
            Controls.Add(label28);
            Controls.Add(label16);
            Controls.Add(btnClose);
            Controls.Add(dgvDetailList);
            Controls.Add(label27);
            Controls.Add(label26);
            Controls.Add(label25);
            Controls.Add(label24);
            Controls.Add(label23);
            Controls.Add(label22);
            Controls.Add(label21);
            Controls.Add(label20);
            Controls.Add(label17);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Controls.Add(txtOrderCode);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmOrderDetail";
            Text = "BCart受注詳細";
            FormClosed += frmOrderDetail_FormClosed;
            Load += frmOrderDetail_Load;
            ((System.ComponentModel.ISupportInitialize)bcOrderBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetailList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bcOrderProductsBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsTnbLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoginName;
        private Label lblDate;
        private Label lblTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label17;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private DataGridView dgvDetailList;
        private Button btnClose;
        private BindingSource bcOrderBindingSource;
        private BindingSource bcOrderProductsBindingSource;
        private Label label16;
        private Label label28;
        private Label label29;
        private Label label30;
        private Label lblReserve;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productsetcustoms1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderprocountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn taxrateDataGridViewTextBoxColumn;
        private BindingSource bsTnbLink;
        private Label label18;
        private TextBox txtOrderCode;
        private ToolTip ToolTip;
    }
}