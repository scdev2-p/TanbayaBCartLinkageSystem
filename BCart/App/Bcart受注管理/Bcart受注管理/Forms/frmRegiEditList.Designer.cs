namespace Bcart受注管理.Forms
{
    partial class frmRegiEditList
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
            label32 = new Label();
            txtCustomerNo = new TextBox();
            btnSearch = new Button();
            btnClose = new Button();
            dgvMain = new DataGridView();
            wレジ伝票明細BindingSource = new BindingSource(components);
            panel1 = new Panel();
            txtChangeDate = new TextBox();
            label2 = new Label();
            btnChangeDate = new Button();
            panel2 = new Panel();
            label1 = new Label();
            btnDelFare = new Button();
            選択 = new DataGridViewCheckBoxColumn();
            カード番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            伝票年月日DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            明細番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            バーコードDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            商品名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            下代単価DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            数量DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wレジ伝票明細BindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(1272, 18);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(282, 64);
            lblDate.TabIndex = 14;
            lblDate.Text = "9999年99月99日(月)";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTitle.Location = new Point(13, 18);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1108, 64);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            label32.BackColor = Color.FromArgb(64, 64, 64);
            label32.BorderStyle = BorderStyle.Fixed3D;
            label32.ForeColor = Color.White;
            label32.Location = new Point(13, 116);
            label32.Margin = new Padding(4, 0, 4, 0);
            label32.Name = "label32";
            label32.Size = new Size(189, 51);
            label32.TabIndex = 60;
            label32.Text = "カード番号";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCustomerNo
            // 
            txtCustomerNo.Location = new Point(209, 122);
            txtCustomerNo.Name = "txtCustomerNo";
            txtCustomerNo.Size = new Size(206, 39);
            txtCustomerNo.TabIndex = 61;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(457, 111);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(214, 60);
            btnSearch.TabIndex = 62;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(1354, 883);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(194, 60);
            btnClose.TabIndex = 64;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // dgvMain
            // 
            dgvMain.AllowUserToAddRows = false;
            dgvMain.AllowUserToDeleteRows = false;
            dgvMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMain.AutoGenerateColumns = false;
            dgvMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMain.Columns.AddRange(new DataGridViewColumn[] { 選択, カード番号DataGridViewTextBoxColumn, 伝票年月日DataGridViewTextBoxColumn, 明細番号DataGridViewTextBoxColumn, バーコードDataGridViewTextBoxColumn, 商品名DataGridViewTextBoxColumn, 下代単価DataGridViewTextBoxColumn, 数量DataGridViewTextBoxColumn });
            dgvMain.DataSource = wレジ伝票明細BindingSource;
            dgvMain.Location = new Point(13, 311);
            dgvMain.Name = "dgvMain";
            dgvMain.RowHeadersVisible = false;
            dgvMain.RowHeadersWidth = 82;
            dgvMain.Size = new Size(1535, 566);
            dgvMain.TabIndex = 66;
            dgvMain.DataBindingComplete += dgvMain_DataBindingComplete;
            // 
            // wレジ伝票明細BindingSource
            // 
            wレジ伝票明細BindingSource.DataMember = "W_レジ伝票明細";
            wレジ伝票明細BindingSource.DataSource = typeof(AppData.Ds.dsBCartLink2);
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(txtChangeDate);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnChangeDate);
            panel1.Location = new Point(866, 94);
            panel1.Name = "panel1";
            panel1.Size = new Size(682, 92);
            panel1.TabIndex = 70;
            // 
            // txtChangeDate
            // 
            txtChangeDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtChangeDate.Location = new Point(248, 27);
            txtChangeDate.Name = "txtChangeDate";
            txtChangeDate.Size = new Size(185, 39);
            txtChangeDate.TabIndex = 72;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.BackColor = Color.Silver;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(52, 21);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(189, 51);
            label2.TabIndex = 71;
            label2.Text = "変更後の日付";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnChangeDate
            // 
            btnChangeDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnChangeDate.Location = new Point(447, 12);
            btnChangeDate.Name = "btnChangeDate";
            btnChangeDate.Size = new Size(214, 60);
            btnChangeDate.TabIndex = 70;
            btnChangeDate.Text = "日付を変更する";
            btnChangeDate.UseVisualStyleBackColor = true;
            btnChangeDate.Click += btnChangeDate_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnDelFare);
            panel2.Location = new Point(866, 192);
            panel2.Name = "panel2";
            panel2.Size = new Size(682, 89);
            panel2.TabIndex = 71;
            panel2.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(121, 28);
            label1.Name = "label1";
            label1.Size = new Size(300, 32);
            label1.TabIndex = 69;
            label1.Text = "チェックした運賃を削除します。";
            label1.Visible = false;
            // 
            // btnDelFare
            // 
            btnDelFare.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelFare.Location = new Point(449, 14);
            btnDelFare.Name = "btnDelFare";
            btnDelFare.Size = new Size(214, 60);
            btnDelFare.TabIndex = 68;
            btnDelFare.Text = "運賃を削除する";
            btnDelFare.UseVisualStyleBackColor = true;
            btnDelFare.Visible = false;
            btnDelFare.Click += btnDelFare_Click;
            // 
            // 選択
            // 
            選択.HeaderText = "選択";
            選択.MinimumWidth = 10;
            選択.Name = "選択";
            選択.Visible = false;
            選択.Width = 80;
            // 
            // カード番号DataGridViewTextBoxColumn
            // 
            カード番号DataGridViewTextBoxColumn.DataPropertyName = "カード番号";
            カード番号DataGridViewTextBoxColumn.HeaderText = "カード番号";
            カード番号DataGridViewTextBoxColumn.MinimumWidth = 10;
            カード番号DataGridViewTextBoxColumn.Name = "カード番号DataGridViewTextBoxColumn";
            カード番号DataGridViewTextBoxColumn.ReadOnly = true;
            カード番号DataGridViewTextBoxColumn.Width = 200;
            // 
            // 伝票年月日DataGridViewTextBoxColumn
            // 
            伝票年月日DataGridViewTextBoxColumn.DataPropertyName = "伝票年月日";
            伝票年月日DataGridViewTextBoxColumn.HeaderText = "伝票年月日";
            伝票年月日DataGridViewTextBoxColumn.MinimumWidth = 10;
            伝票年月日DataGridViewTextBoxColumn.Name = "伝票年月日DataGridViewTextBoxColumn";
            伝票年月日DataGridViewTextBoxColumn.ReadOnly = true;
            伝票年月日DataGridViewTextBoxColumn.Width = 200;
            // 
            // 明細番号DataGridViewTextBoxColumn
            // 
            明細番号DataGridViewTextBoxColumn.DataPropertyName = "明細番号";
            明細番号DataGridViewTextBoxColumn.HeaderText = "明細番号";
            明細番号DataGridViewTextBoxColumn.MinimumWidth = 10;
            明細番号DataGridViewTextBoxColumn.Name = "明細番号DataGridViewTextBoxColumn";
            明細番号DataGridViewTextBoxColumn.ReadOnly = true;
            明細番号DataGridViewTextBoxColumn.Width = 200;
            // 
            // バーコードDataGridViewTextBoxColumn
            // 
            バーコードDataGridViewTextBoxColumn.DataPropertyName = "バーコード";
            バーコードDataGridViewTextBoxColumn.HeaderText = "バーコード";
            バーコードDataGridViewTextBoxColumn.MinimumWidth = 10;
            バーコードDataGridViewTextBoxColumn.Name = "バーコードDataGridViewTextBoxColumn";
            バーコードDataGridViewTextBoxColumn.ReadOnly = true;
            バーコードDataGridViewTextBoxColumn.Width = 200;
            // 
            // 商品名DataGridViewTextBoxColumn
            // 
            商品名DataGridViewTextBoxColumn.DataPropertyName = "商品名";
            商品名DataGridViewTextBoxColumn.HeaderText = "商品名";
            商品名DataGridViewTextBoxColumn.MinimumWidth = 10;
            商品名DataGridViewTextBoxColumn.Name = "商品名DataGridViewTextBoxColumn";
            商品名DataGridViewTextBoxColumn.ReadOnly = true;
            商品名DataGridViewTextBoxColumn.Width = 200;
            // 
            // 下代単価DataGridViewTextBoxColumn
            // 
            下代単価DataGridViewTextBoxColumn.DataPropertyName = "下代単価";
            下代単価DataGridViewTextBoxColumn.HeaderText = "下代単価";
            下代単価DataGridViewTextBoxColumn.MinimumWidth = 10;
            下代単価DataGridViewTextBoxColumn.Name = "下代単価DataGridViewTextBoxColumn";
            下代単価DataGridViewTextBoxColumn.ReadOnly = true;
            下代単価DataGridViewTextBoxColumn.Width = 200;
            // 
            // 数量DataGridViewTextBoxColumn
            // 
            数量DataGridViewTextBoxColumn.DataPropertyName = "数量";
            数量DataGridViewTextBoxColumn.HeaderText = "数量";
            数量DataGridViewTextBoxColumn.MinimumWidth = 10;
            数量DataGridViewTextBoxColumn.Name = "数量DataGridViewTextBoxColumn";
            数量DataGridViewTextBoxColumn.ReadOnly = true;
            数量DataGridViewTextBoxColumn.Width = 200;
            // 
            // frmRegiEditList
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1560, 955);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvMain);
            Controls.Add(btnClose);
            Controls.Add(btnSearch);
            Controls.Add(txtCustomerNo);
            Controls.Add(label32);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Name = "frmRegiEditList";
            Text = "frmRegiEditList";
            Load += frmRegiEditList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)wレジ伝票明細BindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDate;
        private Label lblTitle;
        private Label label32;
        private TextBox txtCustomerNo;
        private Button btnSearch;
        private Button btnClose;
        private DataGridView dgvMain;
        private BindingSource wレジ伝票明細BindingSource;
        private Panel panel1;
        private TextBox txtChangeDate;
        private Label label2;
        private Button btnChangeDate;
        private Panel panel2;
        private Label label1;
        private Button btnDelFare;
        private DataGridViewCheckBoxColumn 選択;
        private DataGridViewTextBoxColumn カード番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 伝票年月日DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 明細番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn バーコードDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 商品名DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 下代単価DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 数量DataGridViewTextBoxColumn;
    }
}