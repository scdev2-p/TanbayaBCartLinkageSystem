namespace Bcart受注管理.Forms
{
    partial class frmShippingInspection
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
            dgvMainList = new DataGridView();
            floorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            barcodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderprocountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            checkCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnReset = new DataGridViewButtonColumn();
            pickingDetailBindingSource = new BindingSource(components);
            txtPickingCD = new TextBox();
            lblOrderCD = new Label();
            label4 = new Label();
            lblSearch = new Label();
            lblCustomerName = new Label();
            lblCustomerCD = new Label();
            label1 = new Label();
            lblCheckComplete = new Label();
            label3 = new Label();
            label2 = new Label();
            btnClose = new Button();
            lblNoData = new Label();
            btnClear = new Button();
            btnClearAll = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pickingDetailBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { floorDataGridViewTextBoxColumn, barcodeDataGridViewTextBoxColumn, productnameDataGridViewTextBoxColumn, orderprocountDataGridViewTextBoxColumn, checkCountDataGridViewTextBoxColumn, statusDataGridViewTextBoxColumn, btnReset });
            dgvMainList.DataSource = pickingDetailBindingSource;
            dgvMainList.Location = new Point(31, 217);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.ReadOnly = true;
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(1114, 322);
            dgvMainList.TabIndex = 15;
            dgvMainList.CellContentClick += dgvMainList_CellContentClick;
            dgvMainList.DataBindingComplete += dgvMainList_DataBindingComplete;
            // 
            // floorDataGridViewTextBoxColumn
            // 
            floorDataGridViewTextBoxColumn.DataPropertyName = "floor";
            floorDataGridViewTextBoxColumn.HeaderText = "フロア";
            floorDataGridViewTextBoxColumn.MinimumWidth = 10;
            floorDataGridViewTextBoxColumn.Name = "floorDataGridViewTextBoxColumn";
            floorDataGridViewTextBoxColumn.ReadOnly = true;
            floorDataGridViewTextBoxColumn.Width = 80;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
            barcodeDataGridViewTextBoxColumn.HeaderText = "バーコード";
            barcodeDataGridViewTextBoxColumn.MinimumWidth = 10;
            barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            barcodeDataGridViewTextBoxColumn.Width = 140;
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            productnameDataGridViewTextBoxColumn.HeaderText = "商品名";
            productnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            productnameDataGridViewTextBoxColumn.ReadOnly = true;
            productnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // orderprocountDataGridViewTextBoxColumn
            // 
            orderprocountDataGridViewTextBoxColumn.DataPropertyName = "order_pro_count";
            orderprocountDataGridViewTextBoxColumn.HeaderText = "受注個数";
            orderprocountDataGridViewTextBoxColumn.MaxInputLength = 10;
            orderprocountDataGridViewTextBoxColumn.MinimumWidth = 10;
            orderprocountDataGridViewTextBoxColumn.Name = "orderprocountDataGridViewTextBoxColumn";
            orderprocountDataGridViewTextBoxColumn.ReadOnly = true;
            orderprocountDataGridViewTextBoxColumn.Width = 200;
            // 
            // checkCountDataGridViewTextBoxColumn
            // 
            checkCountDataGridViewTextBoxColumn.DataPropertyName = "CheckCount";
            checkCountDataGridViewTextBoxColumn.HeaderText = "カウント";
            checkCountDataGridViewTextBoxColumn.MaxInputLength = 10;
            checkCountDataGridViewTextBoxColumn.MinimumWidth = 10;
            checkCountDataGridViewTextBoxColumn.Name = "checkCountDataGridViewTextBoxColumn";
            checkCountDataGridViewTextBoxColumn.ReadOnly = true;
            checkCountDataGridViewTextBoxColumn.Width = 200;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            statusDataGridViewTextBoxColumn.HeaderText = "状態";
            statusDataGridViewTextBoxColumn.MinimumWidth = 10;
            statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            statusDataGridViewTextBoxColumn.ReadOnly = true;
            statusDataGridViewTextBoxColumn.Width = 80;
            // 
            // btnReset
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "リセット";
            btnReset.DefaultCellStyle = dataGridViewCellStyle1;
            btnReset.HeaderText = "リセット";
            btnReset.MinimumWidth = 10;
            btnReset.Name = "btnReset";
            btnReset.ReadOnly = true;
            btnReset.Text = "";
            btnReset.Width = 80;
            // 
            // pickingDetailBindingSource
            // 
            pickingDetailBindingSource.DataMember = "PickingDetail";
            pickingDetailBindingSource.DataSource = typeof(AppData.Ds.dsBCartLink2);
            // 
            // txtPickingCD
            // 
            txtPickingCD.Location = new Point(202, 75);
            txtPickingCD.Name = "txtPickingCD";
            txtPickingCD.Size = new Size(294, 39);
            txtPickingCD.TabIndex = 14;
            // 
            // lblOrderCD
            // 
            lblOrderCD.BorderStyle = BorderStyle.Fixed3D;
            lblOrderCD.Location = new Point(744, 72);
            lblOrderCD.Name = "lblOrderCD";
            lblOrderCD.Size = new Size(245, 45);
            lblOrderCD.TabIndex = 27;
            lblOrderCD.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(638, 78);
            label4.Name = "label4";
            label4.Size = new Size(110, 32);
            label4.TabIndex = 26;
            label4.Text = "受注番号";
            // 
            // lblSearch
            // 
            lblSearch.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblSearch.ForeColor = Color.Red;
            lblSearch.Location = new Point(502, 72);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(156, 50);
            lblSearch.TabIndex = 25;
            lblSearch.Text = "検索中";
            lblSearch.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCustomerName
            // 
            lblCustomerName.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerName.Location = new Point(375, 136);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(762, 45);
            lblCustomerName.TabIndex = 24;
            lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCustomerCD
            // 
            lblCustomerCD.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerCD.Location = new Point(202, 136);
            lblCustomerCD.Name = "lblCustomerCD";
            lblCustomerCD.Size = new Size(156, 45);
            lblCustomerCD.TabIndex = 23;
            lblCustomerCD.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 136);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 22;
            label1.Text = "顧客";
            // 
            // lblCheckComplete
            // 
            lblCheckComplete.BackColor = Color.FromArgb(128, 255, 128);
            lblCheckComplete.FlatStyle = FlatStyle.Popup;
            lblCheckComplete.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblCheckComplete.Location = new Point(520, 283);
            lblCheckComplete.Name = "lblCheckComplete";
            lblCheckComplete.Size = new Size(454, 150);
            lblCheckComplete.TabIndex = 21;
            lblCheckComplete.Text = "チェック完了";
            lblCheckComplete.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(11, 8);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(1148, 56);
            label3.TabIndex = 20;
            label3.Text = "出荷時検品";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 78);
            label2.Name = "label2";
            label2.Size = new Size(150, 32);
            label2.TabIndex = 19;
            label2.Text = "ピッキング番号";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(995, 556);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 46);
            btnClose.TabIndex = 18;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblNoData
            // 
            lblNoData.BackColor = Color.Yellow;
            lblNoData.FlatStyle = FlatStyle.Popup;
            lblNoData.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblNoData.Location = new Point(520, 283);
            lblNoData.Name = "lblNoData";
            lblNoData.Size = new Size(454, 105);
            lblNoData.TabIndex = 17;
            lblNoData.Text = "データがありません。";
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(995, 67);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(154, 54);
            btnClear.TabIndex = 16;
            btnClear.Text = "全リセット";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(671, 359);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(154, 54);
            btnClearAll.TabIndex = 28;
            btnClearAll.Text = "全リセット";
            btnClearAll.UseVisualStyleBackColor = true;
            btnClearAll.Click += btnClearAll_Click;
            // 
            // frmShippingInspection
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 629);
            Controls.Add(btnClearAll);
            Controls.Add(txtPickingCD);
            Controls.Add(lblOrderCD);
            Controls.Add(label4);
            Controls.Add(lblSearch);
            Controls.Add(lblCustomerName);
            Controls.Add(lblCustomerCD);
            Controls.Add(label1);
            Controls.Add(lblCheckComplete);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnClose);
            Controls.Add(lblNoData);
            Controls.Add(btnClear);
            Controls.Add(dgvMainList);
            Name = "frmShippingInspection";
            Text = "frmShippingInspection";
            Activated += Form1_Activated;
            Load += Form1_Load;
            KeyPress += Form1_KeyPress;
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)pickingDetailBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMainList;
        private TextBox txtPickingCD;
        private Label lblOrderCD;
        private Label label4;
        private Label lblSearch;
        private Label lblCustomerName;
        private Label lblCustomerCD;
        private Label label1;
        private Label lblCheckComplete;
        private Label label3;
        private Label label2;
        private Button btnClose;
        private Label lblNoData;
        private Button btnClear;
        private BindingSource pickingDetailBindingSource;
        private DataGridViewTextBoxColumn floorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderprocountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn checkCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewButtonColumn btnReset;
        private Button btnClearAll;
    }
}