namespace Bcart受注管理.Forms
{
    partial class frmReloadOrder
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
            btnReload = new Button();
            label1 = new Label();
            dgvMainList = new DataGridView();
            chkSelect = new DataGridViewCheckBoxColumn();
            orderedatDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ordercodeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customs3DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customercompnameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            paymentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalpriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bsOrderList = new BindingSource(components);
            groupBox2 = new GroupBox();
            label3 = new Label();
            textOrderCode = new TextBox();
            button2 = new Button();
            label2 = new Label();
            btnOrder = new Button();
            btnPicking = new Button();
            btnClose = new Button();
            btnReserved = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMainList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderList).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(580, 4);
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
            lblTitle.Location = new Point(7, 4);
            lblTitle.Margin = new Padding(2, 0, 2, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(414, 30);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(btnReload);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(7, 41);
            groupBox1.Margin = new Padding(2, 1, 2, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 1, 2, 1);
            groupBox1.Size = new Size(725, 52);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // btnReload
            // 
            btnReload.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnReload.Location = new Point(534, 16);
            btnReload.Margin = new Padding(2, 1, 2, 1);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(186, 26);
            btnReload.TabIndex = 1;
            btnReload.Text = "受注を再取込する";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(3, 15);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(411, 29);
            label1.TabIndex = 0;
            label1.Text = "以下の受注はBカートで修正して再取込してください。";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvMainList
            // 
            dgvMainList.AllowUserToAddRows = false;
            dgvMainList.AllowUserToDeleteRows = false;
            dgvMainList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMainList.AutoGenerateColumns = false;
            dgvMainList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMainList.Columns.AddRange(new DataGridViewColumn[] { chkSelect, orderedatDataGridViewTextBoxColumn, ordercodeDataGridViewTextBoxColumn, customs3DataGridViewTextBoxColumn, customercompnameDataGridViewTextBoxColumn, paymentDataGridViewTextBoxColumn, totalpriceDataGridViewTextBoxColumn });
            dgvMainList.DataSource = bsOrderList;
            dgvMainList.Location = new Point(7, 95);
            dgvMainList.Margin = new Padding(2, 1, 2, 1);
            dgvMainList.Name = "dgvMainList";
            dgvMainList.RowHeadersVisible = false;
            dgvMainList.RowHeadersWidth = 82;
            dgvMainList.Size = new Size(725, 237);
            dgvMainList.TabIndex = 20;
            // 
            // chkSelect
            // 
            chkSelect.HeaderText = "選択";
            chkSelect.MinimumWidth = 10;
            chkSelect.Name = "chkSelect";
            chkSelect.Width = 80;
            // 
            // orderedatDataGridViewTextBoxColumn
            // 
            orderedatDataGridViewTextBoxColumn.DataPropertyName = "ordered_at";
            dataGridViewCellStyle1.NullValue = null;
            orderedatDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            orderedatDataGridViewTextBoxColumn.HeaderText = "受注日";
            orderedatDataGridViewTextBoxColumn.MinimumWidth = 10;
            orderedatDataGridViewTextBoxColumn.Name = "orderedatDataGridViewTextBoxColumn";
            orderedatDataGridViewTextBoxColumn.ReadOnly = true;
            orderedatDataGridViewTextBoxColumn.Width = 110;
            // 
            // ordercodeDataGridViewTextBoxColumn
            // 
            ordercodeDataGridViewTextBoxColumn.DataPropertyName = "order_code";
            ordercodeDataGridViewTextBoxColumn.HeaderText = "受注番号";
            ordercodeDataGridViewTextBoxColumn.MinimumWidth = 10;
            ordercodeDataGridViewTextBoxColumn.Name = "ordercodeDataGridViewTextBoxColumn";
            ordercodeDataGridViewTextBoxColumn.ReadOnly = true;
            ordercodeDataGridViewTextBoxColumn.Width = 200;
            // 
            // customs3DataGridViewTextBoxColumn
            // 
            customs3DataGridViewTextBoxColumn.DataPropertyName = "customer_customs3";
            customs3DataGridViewTextBoxColumn.HeaderText = "顧客コード";
            customs3DataGridViewTextBoxColumn.MinimumWidth = 10;
            customs3DataGridViewTextBoxColumn.Name = "customs3DataGridViewTextBoxColumn";
            customs3DataGridViewTextBoxColumn.ReadOnly = true;
            customs3DataGridViewTextBoxColumn.Width = 200;
            // 
            // customercompnameDataGridViewTextBoxColumn
            // 
            customercompnameDataGridViewTextBoxColumn.DataPropertyName = "customer_comp_name";
            customercompnameDataGridViewTextBoxColumn.HeaderText = "顧客名";
            customercompnameDataGridViewTextBoxColumn.MinimumWidth = 10;
            customercompnameDataGridViewTextBoxColumn.Name = "customercompnameDataGridViewTextBoxColumn";
            customercompnameDataGridViewTextBoxColumn.ReadOnly = true;
            customercompnameDataGridViewTextBoxColumn.Width = 200;
            // 
            // paymentDataGridViewTextBoxColumn
            // 
            paymentDataGridViewTextBoxColumn.DataPropertyName = "payment";
            paymentDataGridViewTextBoxColumn.HeaderText = "支払方法";
            paymentDataGridViewTextBoxColumn.MinimumWidth = 10;
            paymentDataGridViewTextBoxColumn.Name = "paymentDataGridViewTextBoxColumn";
            paymentDataGridViewTextBoxColumn.ReadOnly = true;
            paymentDataGridViewTextBoxColumn.Width = 200;
            // 
            // totalpriceDataGridViewTextBoxColumn
            // 
            totalpriceDataGridViewTextBoxColumn.DataPropertyName = "total_price";
            totalpriceDataGridViewTextBoxColumn.HeaderText = "総合計";
            totalpriceDataGridViewTextBoxColumn.MinimumWidth = 10;
            totalpriceDataGridViewTextBoxColumn.Name = "totalpriceDataGridViewTextBoxColumn";
            totalpriceDataGridViewTextBoxColumn.ReadOnly = true;
            totalpriceDataGridViewTextBoxColumn.Width = 200;
            // 
            // bsOrderList
            // 
            bsOrderList.DataMember = "S_SearchReloadOrder";
            bsOrderList.DataSource = typeof(AppData.Ds.dsBCartLink2);
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(textOrderCode);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(7, 334);
            groupBox2.Margin = new Padding(2, 1, 2, 1);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 1, 2, 1);
            groupBox2.Size = new Size(725, 52);
            groupBox2.TabIndex = 14;
            groupBox2.TabStop = false;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(477, 22);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "受注番号";
            // 
            // textOrderCode
            // 
            textOrderCode.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            textOrderCode.Location = new Point(534, 18);
            textOrderCode.Name = "textOrderCode";
            textOrderCode.Size = new Size(110, 23);
            textOrderCode.TabIndex = 30;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.Location = new Point(644, 16);
            button2.Margin = new Padding(2, 1, 2, 1);
            button2.Name = "button2";
            button2.Size = new Size(76, 26);
            button2.TabIndex = 40;
            button2.Text = "個別再取込";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnReloadByOrderCode_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(3, 15);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(451, 29);
            label2.TabIndex = 0;
            label2.Text = "処理エラー後の再実行やBカートで修正して再取込したい受注番号が一覧に表示されていない場合は、こちらのテキストボックスに受注番号を入力して、個別再取込ボタンをクリックしてください。\r\n";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOrder
            // 
            btnOrder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnOrder.Location = new Point(7, 388);
            btnOrder.Margin = new Padding(2, 1, 2, 1);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(133, 22);
            btnOrder.TabIndex = 50;
            btnOrder.Text = "BCart受注管理";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnPicking
            // 
            btnPicking.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPicking.Location = new Point(144, 388);
            btnPicking.Margin = new Padding(2, 1, 2, 1);
            btnPicking.Name = "btnPicking";
            btnPicking.Size = new Size(133, 22);
            btnPicking.TabIndex = 60;
            btnPicking.Text = "ピッキング作業";
            btnPicking.UseVisualStyleBackColor = true;
            btnPicking.Click += btnPicking_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(651, 386);
            btnClose.Margin = new Padding(2, 1, 2, 1);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(81, 22);
            btnClose.TabIndex = 70;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnReserved
            // 
            btnReserved.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnReserved.Location = new Point(281, 388);
            btnReserved.Margin = new Padding(2, 1, 2, 1);
            btnReserved.Name = "btnReserved";
            btnReserved.Size = new Size(133, 22);
            btnReserved.TabIndex = 323;
            btnReserved.Text = "取置一覧";
            btnReserved.UseVisualStyleBackColor = true;
            btnReserved.Click += btnReserved_Click;
            // 
            // frmReloadOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 417);
            Controls.Add(btnReserved);
            Controls.Add(btnOrder);
            Controls.Add(btnPicking);
            Controls.Add(btnClose);
            Controls.Add(groupBox2);
            Controls.Add(dgvMainList);
            Controls.Add(groupBox1);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Margin = new Padding(2, 1, 2, 1);
            Name = "frmReloadOrder";
            Text = "BCart受注再取得";
            FormClosed += frmReloadOrder_FormClosed;
            Load += frmReloadOrder_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMainList).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsOrderList).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblDate;
        private Label lblTitle;
        private GroupBox groupBox1;
        private Button btnReload;
        private Label label1;
        private DataGridView dgvMainList;
        private BindingSource bsOrderList;
        private GroupBox groupBox2;
        private TextBox textOrderCode;
        private Button button2;
        private Label label2;
        private Label label3;
        private Button btnReloadOrder;
        private Button btnPicking;
        private Button btnClose;
        private Button btnOrder;
        private DataGridViewCheckBoxColumn chkSelect;
        private DataGridViewTextBoxColumn orderedatDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ordercodeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customs3DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customercompnameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn paymentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalpriceDataGridViewTextBoxColumn;
        private Button btnReserved;
    }
}