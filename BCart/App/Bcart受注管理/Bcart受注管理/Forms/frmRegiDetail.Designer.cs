namespace Bcart受注管理.Forms
{
    partial class frmRegiDetail
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
            label36 = new Label();
            bindingSource1 = new BindingSource(components);
            label33 = new Label();
            label34 = new Label();
            label31 = new Label();
            label32 = new Label();
            label9 = new Label();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            dataGridView1 = new DataGridView();
            明細番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            商品管理番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            バーコードDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            上代単価DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            下代単価DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            数量DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            商品名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            btnClose = new Button();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(728, 9);
            lblDate.Margin = new Padding(2, 0, 2, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(152, 30);
            lblDate.TabIndex = 12;
            lblDate.Text = "9999年99月99日(月)";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTitle.Location = new Point(2, 9);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(641, 30);
            lblTitle.TabIndex = 11;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            label36.BackColor = Color.FromArgb(64, 64, 64);
            label36.BorderStyle = BorderStyle.Fixed3D;
            label36.DataBindings.Add(new Binding("DataContext", bindingSource1, "会社名", true));
            label36.ForeColor = Color.White;
            label36.Location = new Point(375, 83);
            label36.Margin = new Padding(2, 0, 2, 0);
            label36.Name = "label36";
            label36.Size = new Size(109, 24);
            label36.TabIndex = 62;
            label36.Text = "会社名";
            label36.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bindingSource1
            // 
            bindingSource1.DataMember = "S_SearchRegiDetail";
            bindingSource1.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // label33
            // 
            label33.BackColor = Color.FromArgb(224, 224, 224);
            label33.BorderStyle = BorderStyle.Fixed3D;
            label33.DataBindings.Add(new Binding("Text", bindingSource1, "顧客管理番号", true));
            label33.ForeColor = Color.Black;
            label33.Location = new Point(488, 59);
            label33.Margin = new Padding(2, 0, 2, 0);
            label33.Name = "label33";
            label33.Size = new Size(141, 24);
            label33.TabIndex = 61;
            label33.Text = "label33";
            label33.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            label34.BackColor = Color.FromArgb(64, 64, 64);
            label34.BorderStyle = BorderStyle.Fixed3D;
            label34.ForeColor = Color.White;
            label34.Location = new Point(375, 59);
            label34.Margin = new Padding(2, 0, 2, 0);
            label34.Name = "label34";
            label34.Size = new Size(109, 24);
            label34.TabIndex = 60;
            label34.Text = "顧客管理番号";
            label34.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label31
            // 
            label31.BackColor = Color.FromArgb(224, 224, 224);
            label31.BorderStyle = BorderStyle.Fixed3D;
            label31.DataBindings.Add(new Binding("Text", bindingSource1, "カード番号", true));
            label31.ForeColor = Color.Black;
            label31.Location = new Point(108, 107);
            label31.Margin = new Padding(2, 0, 2, 0);
            label31.Name = "label31";
            label31.Size = new Size(149, 24);
            label31.TabIndex = 59;
            label31.Text = "label31";
            label31.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            label32.BackColor = Color.FromArgb(64, 64, 64);
            label32.BorderStyle = BorderStyle.Fixed3D;
            label32.ForeColor = Color.White;
            label32.Location = new Point(2, 107);
            label32.Margin = new Padding(2, 0, 2, 0);
            label32.Name = "label32";
            label32.Size = new Size(102, 24);
            label32.TabIndex = 58;
            label32.Text = "カード番号";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(224, 224, 224);
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.DataBindings.Add(new Binding("Text", bindingSource1, "伝票年月日", true));
            label9.ForeColor = Color.Black;
            label9.Location = new Point(108, 83);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(149, 24);
            label9.TabIndex = 57;
            label9.Text = "label9";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(224, 224, 224);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.DataBindings.Add(new Binding("Text", bindingSource1, "受注番号", true));
            label8.ForeColor = Color.Black;
            label8.Location = new Point(108, 59);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(149, 24);
            label8.TabIndex = 56;
            label8.Text = "label8";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(2, 83);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(102, 24);
            label2.TabIndex = 55;
            label2.Text = "伝票年月日";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.White;
            label1.Location = new Point(2, 59);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(102, 24);
            label1.TabIndex = 54;
            label1.Text = "受注番号";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(224, 224, 224);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.DataBindings.Add(new Binding("Text", bindingSource1, "会社名", true));
            label3.ForeColor = Color.Black;
            label3.Location = new Point(488, 83);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(358, 24);
            label3.TabIndex = 63;
            label3.Text = "label3";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { 明細番号DataGridViewTextBoxColumn, 商品管理番号DataGridViewTextBoxColumn, バーコードDataGridViewTextBoxColumn, 上代単価DataGridViewTextBoxColumn, 下代単価DataGridViewTextBoxColumn, 数量DataGridViewTextBoxColumn, 商品名DataGridViewTextBoxColumn });
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Location = new Point(2, 184);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(878, 396);
            dataGridView1.TabIndex = 64;
            // 
            // 明細番号DataGridViewTextBoxColumn
            // 
            明細番号DataGridViewTextBoxColumn.DataPropertyName = "明細番号";
            明細番号DataGridViewTextBoxColumn.HeaderText = "明細番号";
            明細番号DataGridViewTextBoxColumn.Name = "明細番号DataGridViewTextBoxColumn";
            // 
            // 商品管理番号DataGridViewTextBoxColumn
            // 
            商品管理番号DataGridViewTextBoxColumn.DataPropertyName = "商品管理番号";
            商品管理番号DataGridViewTextBoxColumn.HeaderText = "商品管理番号";
            商品管理番号DataGridViewTextBoxColumn.Name = "商品管理番号DataGridViewTextBoxColumn";
            // 
            // バーコードDataGridViewTextBoxColumn
            // 
            バーコードDataGridViewTextBoxColumn.DataPropertyName = "バーコード";
            バーコードDataGridViewTextBoxColumn.HeaderText = "バーコード";
            バーコードDataGridViewTextBoxColumn.Name = "バーコードDataGridViewTextBoxColumn";
            // 
            // 上代単価DataGridViewTextBoxColumn
            // 
            上代単価DataGridViewTextBoxColumn.DataPropertyName = "上代単価";
            上代単価DataGridViewTextBoxColumn.HeaderText = "上代単価";
            上代単価DataGridViewTextBoxColumn.Name = "上代単価DataGridViewTextBoxColumn";
            // 
            // 下代単価DataGridViewTextBoxColumn
            // 
            下代単価DataGridViewTextBoxColumn.DataPropertyName = "下代単価";
            下代単価DataGridViewTextBoxColumn.HeaderText = "下代単価";
            下代単価DataGridViewTextBoxColumn.Name = "下代単価DataGridViewTextBoxColumn";
            // 
            // 数量DataGridViewTextBoxColumn
            // 
            数量DataGridViewTextBoxColumn.DataPropertyName = "数量";
            数量DataGridViewTextBoxColumn.FillWeight = 50F;
            数量DataGridViewTextBoxColumn.HeaderText = "数量";
            数量DataGridViewTextBoxColumn.Name = "数量DataGridViewTextBoxColumn";
            数量DataGridViewTextBoxColumn.Width = 50;
            // 
            // 商品名DataGridViewTextBoxColumn
            // 
            商品名DataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            商品名DataGridViewTextBoxColumn.DataPropertyName = "商品名";
            商品名DataGridViewTextBoxColumn.FillWeight = 350F;
            商品名DataGridViewTextBoxColumn.HeaderText = "商品名";
            商品名DataGridViewTextBoxColumn.Name = "商品名DataGridViewTextBoxColumn";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(799, 584);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 102;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmRegiDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 616);
            Controls.Add(btnClose);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(label36);
            Controls.Add(label33);
            Controls.Add(label34);
            Controls.Add(label31);
            Controls.Add(label32);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Name = "frmRegiDetail";
            Text = "レジ事前登録詳細";
            Load += frmRegiDetail_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblDate;
        private Label lblTitle;
        private Label label36;
        private Label label33;
        private Label label34;
        private Label label31;
        private Label label32;
        private Label label9;
        private Label label8;
        private Label label2;
        private Label label1;
        private Label label3;
        private BindingSource bindingSource1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn 明細番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 商品管理番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn バーコードDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 上代単価DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 下代単価DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 数量DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 商品名DataGridViewTextBoxColumn;
        private Button btnClose;
    }
}