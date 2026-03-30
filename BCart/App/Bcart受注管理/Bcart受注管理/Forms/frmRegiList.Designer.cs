namespace Bcart受注管理.Forms
{
    partial class frmRegiList
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
            chkRegiDate = new CheckBox();
            txtCustomerCade = new TextBox();
            label5 = new Label();
            btnRegiSearch = new Button();
            label4 = new Label();
            dtRegiTo = new DateTimePicker();
            dtRegiFrom = new DateTimePicker();
            txtCustomerExtId = new TextBox();
            txtOrderCode = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnClose = new Button();
            lblCount = new Label();
            dgvMainList = new DataGridView();
            btnDetail = new DataGridViewButtonColumn();
            伝票年月日DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            受注番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            カード番号DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            会社名DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(474, 3);
            lblDate.Margin = new Padding(2, 0, 2, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(152, 30);
            lblDate.TabIndex = 9;
            lblDate.Text = "9999年99月99日(月)";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTitle.Location = new Point(8, 3);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(307, 30);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(chkRegiDate);
            groupBox1.Controls.Add(txtCustomerCade);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnRegiSearch);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtRegiTo);
            groupBox1.Controls.Add(dtRegiFrom);
            groupBox1.Controls.Add(txtCustomerExtId);
            groupBox1.Controls.Add(txtOrderCode);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(8, 34);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(618, 80);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "検索条件";
            // 
            // chkRegiDate
            // 
            chkRegiDate.AutoSize = true;
            chkRegiDate.Checked = true;
            chkRegiDate.CheckState = CheckState.Checked;
            chkRegiDate.Location = new Point(217, 20);
            chkRegiDate.Margin = new Padding(2, 1, 2, 1);
            chkRegiDate.Name = "chkRegiDate";
            chkRegiDate.Size = new Size(86, 19);
            chkRegiDate.TabIndex = 64;
            chkRegiDate.Text = "伝票年月日";
            chkRegiDate.UseVisualStyleBackColor = true;
            // 
            // txtCustomerCade
            // 
            txtCustomerCade.Location = new Point(306, 49);
            txtCustomerCade.Margin = new Padding(2, 1, 2, 1);
            txtCustomerCade.Name = "txtCustomerCade";
            txtCustomerCade.Size = new Size(110, 23);
            txtCustomerCade.TabIndex = 63;
            txtCustomerCade.KeyDown += txtCustomerCade_KeyDown;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(246, 54);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 62;
            label5.Text = "カード番号";
            // 
            // btnRegiSearch
            // 
            btnRegiSearch.Location = new Point(468, 51);
            btnRegiSearch.Name = "btnRegiSearch";
            btnRegiSearch.Size = new Size(145, 22);
            btnRegiSearch.TabIndex = 61;
            btnRegiSearch.Text = "検索";
            btnRegiSearch.UseVisualStyleBackColor = true;
            btnRegiSearch.Click += btnRegiSearch_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(413, 19);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(19, 15);
            label4.TabIndex = 7;
            label4.Text = "～";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtRegiTo
            // 
            dtRegiTo.Format = DateTimePickerFormat.Short;
            dtRegiTo.Location = new Point(438, 17);
            dtRegiTo.Margin = new Padding(2, 1, 2, 1);
            dtRegiTo.Name = "dtRegiTo";
            dtRegiTo.Size = new Size(108, 23);
            dtRegiTo.TabIndex = 30;
            // 
            // dtRegiFrom
            // 
            dtRegiFrom.Format = DateTimePickerFormat.Short;
            dtRegiFrom.Location = new Point(304, 17);
            dtRegiFrom.Margin = new Padding(2, 1, 2, 1);
            dtRegiFrom.Name = "dtRegiFrom";
            dtRegiFrom.Size = new Size(108, 23);
            dtRegiFrom.TabIndex = 20;
            // 
            // txtCustomerExtId
            // 
            txtCustomerExtId.Location = new Point(88, 48);
            txtCustomerExtId.Margin = new Padding(2, 1, 2, 1);
            txtCustomerExtId.Name = "txtCustomerExtId";
            txtCustomerExtId.Size = new Size(110, 23);
            txtCustomerExtId.TabIndex = 40;
            // 
            // txtOrderCode
            // 
            txtOrderCode.Location = new Point(88, 20);
            txtOrderCode.Margin = new Padding(2, 1, 2, 1);
            txtOrderCode.Name = "txtOrderCode";
            txtOrderCode.Size = new Size(110, 23);
            txtOrderCode.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(5, 51);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 1;
            label2.Text = "顧客管理番号";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 25);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 0;
            label1.Text = "受注番号";
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(545, 386);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 101;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblCount
            // 
            lblCount.BorderStyle = BorderStyle.Fixed3D;
            lblCount.Location = new Point(8, 115);
            lblCount.Margin = new Padding(2, 0, 2, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(229, 20);
            lblCount.TabIndex = 102;
            lblCount.Text = "label6";
            lblCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { btnDetail, 伝票年月日DataGridViewTextBoxColumn, 受注番号DataGridViewTextBoxColumn, カード番号DataGridViewTextBoxColumn, 会社名DataGridViewTextBoxColumn });
            dgvMainList.DataSource = bindingSource1;
            dgvMainList.Location = new Point(8, 136);
            dgvMainList.Margin = new Padding(2, 1, 2, 1);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.ReadOnly = true;
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(617, 239);
            dgvMainList.TabIndex = 103;
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
            // 伝票年月日DataGridViewTextBoxColumn
            // 
            伝票年月日DataGridViewTextBoxColumn.DataPropertyName = "伝票年月日";
            伝票年月日DataGridViewTextBoxColumn.HeaderText = "伝票年月日";
            伝票年月日DataGridViewTextBoxColumn.Name = "伝票年月日DataGridViewTextBoxColumn";
            伝票年月日DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 受注番号DataGridViewTextBoxColumn
            // 
            受注番号DataGridViewTextBoxColumn.DataPropertyName = "受注番号";
            受注番号DataGridViewTextBoxColumn.HeaderText = "受注番号";
            受注番号DataGridViewTextBoxColumn.Name = "受注番号DataGridViewTextBoxColumn";
            受注番号DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // カード番号DataGridViewTextBoxColumn
            // 
            カード番号DataGridViewTextBoxColumn.DataPropertyName = "カード番号";
            カード番号DataGridViewTextBoxColumn.HeaderText = "カード番号";
            カード番号DataGridViewTextBoxColumn.Name = "カード番号DataGridViewTextBoxColumn";
            カード番号DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 会社名DataGridViewTextBoxColumn
            // 
            会社名DataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            会社名DataGridViewTextBoxColumn.DataPropertyName = "会社名";
            会社名DataGridViewTextBoxColumn.HeaderText = "会社名";
            会社名DataGridViewTextBoxColumn.Name = "会社名DataGridViewTextBoxColumn";
            会社名DataGridViewTextBoxColumn.ReadOnly = true;
            会社名DataGridViewTextBoxColumn.Width = 500;
            // 
            // bindingSource1
            // 
            bindingSource1.DataMember = "S_SearchRegi";
            bindingSource1.DataSource = typeof(AppData.Ds.dsBCartLink);
            // 
            // frmRegiList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(637, 418);
            Controls.Add(dgvMainList);
            Controls.Add(lblCount);
            Controls.Add(btnClose);
            Controls.Add(groupBox1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Name = "frmRegiList";
            Text = "レジ事前登録一覧";
            Load += frmRegiList_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblDate;
        private Label lblTitle;
        private GroupBox groupBox1;
        private Label label4;
        private DateTimePicker dtRegiTo;
        private DateTimePicker dtRegiFrom;
        private TextBox txtCustomerExtId;
        private TextBox txtOrderCode;
        private Label label2;
        private Label label1;
        private Button button1;
        private Label label5;
        private TextBox txtCustomerCade;
        private Button btnClose;
        private Label lblCount;
        private DataGridView dgvMainList;
        private BindingSource bindingSource1;
        private Button btnRegiSearch;
        private CheckBox chkRegiDate;
        private DataGridViewButtonColumn btnDetail;
        private DataGridViewTextBoxColumn 伝票年月日DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 受注番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn カード番号DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn 会社名DataGridViewTextBoxColumn;
    }
}