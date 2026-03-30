namespace Bcart受注管理.Forms
{
    partial class frmReservedDetail
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
            label1 = new Label();
            LblCustomerCode = new Label();
            lblpaymat = new Label();
            label2 = new Label();
            button1 = new Button();
            bsBcartLink = new BindingSource(components);
            bsBcartLink2 = new BindingSource(components);
            dataGridView1 = new DataGridView();
            orderproductsidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unitpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            orderprocountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            productsetcustoms1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            picking = new DataGridViewTextBoxColumn();
            lable3 = new Label();
            lblPikking = new Label();
            btnClose = new Button();
            lblCusname = new Label();
            label4 = new Label();
            rankGridview = new DataGridView();
            order_code = new DataGridViewTextBoxColumn();
            orderedatDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bc_rank_name = new DataGridViewTextBoxColumn();
            lblResevedStatus = new Label();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rankGridview).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            lblTitle.Size = new Size(535, 30);
            lblTitle.TabIndex = 49;
            lblTitle.Text = "取置明細";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 51);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 24);
            label1.TabIndex = 52;
            label1.Text = "顧客コード";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LblCustomerCode
            // 
            LblCustomerCode.BackColor = Color.FromArgb(224, 224, 224);
            LblCustomerCode.BorderStyle = BorderStyle.Fixed3D;
            LblCustomerCode.ForeColor = Color.Black;
            LblCustomerCode.Location = new Point(117, 51);
            LblCustomerCode.Margin = new Padding(2, 0, 2, 0);
            LblCustomerCode.Name = "LblCustomerCode";
            LblCustomerCode.Size = new Size(149, 24);
            LblCustomerCode.TabIndex = 59;
            LblCustomerCode.Text = "label8";
            LblCustomerCode.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblpaymat
            // 
            lblpaymat.BackColor = Color.FromArgb(224, 224, 224);
            lblpaymat.BorderStyle = BorderStyle.Fixed3D;
            lblpaymat.ForeColor = Color.Black;
            lblpaymat.Location = new Point(394, 85);
            lblpaymat.Margin = new Padding(2, 0, 2, 0);
            lblpaymat.Name = "lblpaymat";
            lblpaymat.Size = new Size(149, 24);
            lblpaymat.TabIndex = 61;
            lblpaymat.Text = "label9";
            lblpaymat.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(288, 85);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 60;
            label2.Text = "支払方法";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(587, 49);
            button1.Name = "button1";
            button1.Size = new Size(184, 29);
            button1.TabIndex = 64;
            button1.Text = "取置をレジに登録";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // bsBcartLink
            // 
            bsBcartLink.DataMember = "S_SearchReservedDetail";
            bsBcartLink.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // bsBcartLink2
            // 
            bsBcartLink2.DataMember = "S_SearchReservedRank";
            bsBcartLink2.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { orderproductsidDataGridViewTextBoxColumn, productnameDataGridViewTextBoxColumn, unitpriceDataGridViewTextBoxColumn, orderprocountDataGridViewTextBoxColumn, productsetcustoms1DataGridViewTextBoxColumn, price, picking });
            dataGridView1.DataSource = bsBcartLink;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(739, 140);
            dataGridView1.TabIndex = 65;
            // 
            // orderproductsidDataGridViewTextBoxColumn
            // 
            orderproductsidDataGridViewTextBoxColumn.DataPropertyName = "order_products_id";
            orderproductsidDataGridViewTextBoxColumn.HeaderText = "受注明細ID";
            orderproductsidDataGridViewTextBoxColumn.Name = "orderproductsidDataGridViewTextBoxColumn";
            orderproductsidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productnameDataGridViewTextBoxColumn
            // 
            productnameDataGridViewTextBoxColumn.DataPropertyName = "product_name";
            productnameDataGridViewTextBoxColumn.HeaderText = "商品名";
            productnameDataGridViewTextBoxColumn.Name = "productnameDataGridViewTextBoxColumn";
            productnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unitpriceDataGridViewTextBoxColumn
            // 
            unitpriceDataGridViewTextBoxColumn.DataPropertyName = "unit_price";
            unitpriceDataGridViewTextBoxColumn.HeaderText = "単価";
            unitpriceDataGridViewTextBoxColumn.Name = "unitpriceDataGridViewTextBoxColumn";
            unitpriceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // orderprocountDataGridViewTextBoxColumn
            // 
            orderprocountDataGridViewTextBoxColumn.DataPropertyName = "order_pro_count";
            orderprocountDataGridViewTextBoxColumn.HeaderText = "注文数";
            orderprocountDataGridViewTextBoxColumn.Name = "orderprocountDataGridViewTextBoxColumn";
            orderprocountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productsetcustoms1DataGridViewTextBoxColumn
            // 
            productsetcustoms1DataGridViewTextBoxColumn.DataPropertyName = "product_set_customs1";
            productsetcustoms1DataGridViewTextBoxColumn.HeaderText = "バーコード";
            productsetcustoms1DataGridViewTextBoxColumn.Name = "productsetcustoms1DataGridViewTextBoxColumn";
            productsetcustoms1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // price
            // 
            price.DataPropertyName = "price";
            price.HeaderText = "金額";
            price.Name = "price";
            price.ReadOnly = true;
            // 
            // picking
            // 
            picking.DataPropertyName = "picking";
            picking.HeaderText = "ピッキング";
            picking.Name = "picking";
            picking.ReadOnly = true;
            // 
            // lable3
            // 
            lable3.BackColor = Color.FromArgb(64, 64, 64);
            lable3.BorderStyle = BorderStyle.Fixed3D;
            lable3.ForeColor = Color.White;
            lable3.Location = new Point(11, 85);
            lable3.Margin = new Padding(2, 0, 2, 0);
            lable3.Name = "lable3";
            lable3.Size = new Size(102, 24);
            lable3.TabIndex = 66;
            lable3.Text = "ピッキング";
            lable3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPikking
            // 
            lblPikking.BackColor = Color.FromArgb(224, 224, 224);
            lblPikking.BorderStyle = BorderStyle.Fixed3D;
            lblPikking.ForeColor = Color.Black;
            lblPikking.Location = new Point(117, 85);
            lblPikking.Margin = new Padding(2, 0, 2, 0);
            lblPikking.Name = "lblPikking";
            lblPikking.Size = new Size(149, 24);
            lblPikking.TabIndex = 67;
            lblPikking.Text = "label8";
            lblPikking.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(690, 414);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 70;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblCusname
            // 
            lblCusname.BackColor = Color.FromArgb(224, 224, 224);
            lblCusname.BorderStyle = BorderStyle.Fixed3D;
            lblCusname.ForeColor = Color.Black;
            lblCusname.Location = new Point(394, 49);
            lblCusname.Margin = new Padding(2, 0, 2, 0);
            lblCusname.Name = "lblCusname";
            lblCusname.Size = new Size(149, 24);
            lblCusname.TabIndex = 72;
            lblCusname.Text = "label9";
            lblCusname.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.White;
            label4.Location = new Point(288, 49);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 24);
            label4.TabIndex = 71;
            label4.Text = "顧客名";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rankGridview
            // 
            rankGridview.AllowUserToAddRows = false;
            rankGridview.AllowUserToDeleteRows = false;
            rankGridview.AutoGenerateColumns = false;
            rankGridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rankGridview.Columns.AddRange(new DataGridViewColumn[] { order_code, orderedatDataGridViewTextBoxColumn, bc_rank_name });
            rankGridview.DataSource = bsBcartLink2;
            rankGridview.Dock = DockStyle.Fill;
            rankGridview.Location = new Point(0, 0);
            rankGridview.Name = "rankGridview";
            rankGridview.ReadOnly = true;
            rankGridview.RowHeadersVisible = false;
            rankGridview.Size = new Size(739, 141);
            rankGridview.TabIndex = 73;
            rankGridview.Visible = false;
            // 
            // order_code
            // 
            order_code.DataPropertyName = "order_code";
            order_code.HeaderText = "受注番号";
            order_code.Name = "order_code";
            order_code.ReadOnly = true;
            // 
            // orderedatDataGridViewTextBoxColumn
            // 
            orderedatDataGridViewTextBoxColumn.DataPropertyName = "ordered_at";
            orderedatDataGridViewTextBoxColumn.HeaderText = "受注日";
            orderedatDataGridViewTextBoxColumn.Name = "orderedatDataGridViewTextBoxColumn";
            orderedatDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bc_rank_name
            // 
            bc_rank_name.DataPropertyName = "bc_rank_name";
            bc_rank_name.HeaderText = "ランク";
            bc_rank_name.Name = "bc_rank_name";
            bc_rank_name.ReadOnly = true;
            // 
            // lblResevedStatus
            // 
            lblResevedStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblResevedStatus.BackColor = Color.FromArgb(224, 224, 224);
            lblResevedStatus.BorderStyle = BorderStyle.Fixed3D;
            lblResevedStatus.ForeColor = Color.Black;
            lblResevedStatus.Location = new Point(587, 85);
            lblResevedStatus.Margin = new Padding(2, 0, 2, 0);
            lblResevedStatus.Name = "lblResevedStatus";
            lblResevedStatus.Size = new Size(149, 24);
            lblResevedStatus.TabIndex = 74;
            lblResevedStatus.Text = "label9";
            lblResevedStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 125);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(rankGridview);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(739, 285);
            splitContainer1.SplitterDistance = 141;
            splitContainer1.TabIndex = 75;
            // 
            // frmReservedDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 446);
            Controls.Add(splitContainer1);
            Controls.Add(lblResevedStatus);
            Controls.Add(lblCusname);
            Controls.Add(label4);
            Controls.Add(btnClose);
            Controls.Add(lblPikking);
            Controls.Add(lable3);
            Controls.Add(button1);
            Controls.Add(lblpaymat);
            Controls.Add(label2);
            Controls.Add(LblCustomerCode);
            Controls.Add(label1);
            Controls.Add(lblTitle);
            Name = "frmReservedDetail";
            Text = "frmReservedDetail";
            Load += frmReservedDetail_Load;
            ((System.ComponentModel.ISupportInitialize)bsBcartLink).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsBcartLink2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)rankGridview).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label label1;
        private Label LblCustomerCode;
        private Label lblpaymat;
        private Label label2;
        private Button button1;
        private BindingSource bsBcartLink;
        private BindingSource bsBcartLink2;
        private DataGridView dataGridView1;
        private Label lable3;
        private Label lblPikking;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn picking;
        private Button btnClose;
        private Label lblCusname;
        private Label label4;
        private DataGridViewTextBoxColumn orderproductsidDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unitpriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn orderprocountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn productsetcustoms1DataGridViewTextBoxColumn;
        private DataGridView rankGridview;
        private DataGridViewTextBoxColumn order_code;
        private DataGridViewTextBoxColumn orderedatDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bc_rank_name;
        private Label lblResevedStatus;
        private SplitContainer splitContainer1;
    }
}