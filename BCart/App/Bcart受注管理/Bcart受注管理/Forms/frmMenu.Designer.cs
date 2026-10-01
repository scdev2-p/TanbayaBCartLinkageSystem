namespace Bcart受注管理.Forms
{
    partial class frmMenu
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
            btnOrder = new Button();
            btnPicking = new Button();
            btnSipping = new Button();
            btnCustomer = new Button();
            label1 = new Label();
            btnClose = new Button();
            lblDate = new Label();
            lblDeliPrinter = new Label();
            btnChangePrinter = new Button();
            lblDpi = new Label();
            btnReloadOrder = new Button();
            LblRegistTnb = new Label();
            lblVersion = new Label();
            label2 = new Label();
            btnRegi = new Button();
            btnReserved = new Button();
            btnShippingInspection = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnOrder
            // 
            btnOrder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnOrder.Location = new Point(11, 177);
            btnOrder.Margin = new Padding(4, 2, 4, 2);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(587, 60);
            btnOrder.TabIndex = 10;
            btnOrder.Text = "BCart受注管理";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnPicking
            // 
            btnPicking.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPicking.Location = new Point(11, 243);
            btnPicking.Margin = new Padding(4, 2, 4, 2);
            btnPicking.Name = "btnPicking";
            btnPicking.Size = new Size(587, 60);
            btnPicking.TabIndex = 20;
            btnPicking.Text = "ピッキング作業";
            btnPicking.UseVisualStyleBackColor = true;
            btnPicking.Click += btnPicking_Click;
            // 
            // btnSipping
            // 
            btnSipping.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSipping.Location = new Point(11, 371);
            btnSipping.Margin = new Padding(4, 2, 4, 2);
            btnSipping.Name = "btnSipping";
            btnSipping.Size = new Size(587, 60);
            btnSipping.TabIndex = 40;
            btnSipping.Text = "出荷処理";
            btnSipping.UseVisualStyleBackColor = true;
            btnSipping.Click += btnSipping_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCustomer.Location = new Point(11, 450);
            btnCustomer.Margin = new Padding(4, 2, 4, 2);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(587, 60);
            btnCustomer.TabIndex = 50;
            btnCustomer.Text = "顧客登録";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(11, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(587, 60);
            label1.TabIndex = 4;
            label1.Text = "BCart受注管理";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom;
            btnClose.Location = new Point(215, 901);
            btnClose.Margin = new Padding(4, 2, 4, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(191, 66);
            btnClose.TabIndex = 60;
            btnClose.Text = "終了";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(11, 79);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(587, 51);
            lblDate.TabIndex = 6;
            lblDate.Text = "yyyy年MM月dd日(ddd)";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDeliPrinter
            // 
            lblDeliPrinter.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDeliPrinter.BorderStyle = BorderStyle.Fixed3D;
            lblDeliPrinter.Location = new Point(373, 856);
            lblDeliPrinter.Margin = new Padding(4, 0, 4, 0);
            lblDeliPrinter.Name = "lblDeliPrinter";
            lblDeliPrinter.Size = new Size(225, 43);
            lblDeliPrinter.TabIndex = 8;
            lblDeliPrinter.Text = "label3";
            lblDeliPrinter.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnChangePrinter
            // 
            btnChangePrinter.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnChangePrinter.Location = new Point(501, 911);
            btnChangePrinter.Margin = new Padding(4, 2, 4, 2);
            btnChangePrinter.Name = "btnChangePrinter";
            btnChangePrinter.Size = new Size(98, 47);
            btnChangePrinter.TabIndex = 70;
            btnChangePrinter.Text = "設定";
            btnChangePrinter.UseVisualStyleBackColor = true;
            btnChangePrinter.Visible = false;
            btnChangePrinter.Click += btnChangePrinter_Click;
            // 
            // lblDpi
            // 
            lblDpi.Location = new Point(368, 126);
            lblDpi.Margin = new Padding(6, 0, 6, 0);
            lblDpi.Name = "lblDpi";
            lblDpi.Size = new Size(186, 49);
            lblDpi.TabIndex = 10;
            lblDpi.Text = "label3";
            lblDpi.TextAlign = ContentAlignment.MiddleLeft;
            lblDpi.Visible = false;
            // 
            // btnReloadOrder
            // 
            btnReloadOrder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnReloadOrder.Location = new Point(11, 307);
            btnReloadOrder.Margin = new Padding(4, 2, 4, 2);
            btnReloadOrder.Name = "btnReloadOrder";
            btnReloadOrder.Size = new Size(587, 60);
            btnReloadOrder.TabIndex = 30;
            btnReloadOrder.Text = "BCart受注再取込";
            btnReloadOrder.UseVisualStyleBackColor = true;
            btnReloadOrder.Click += btnReloadOrder_Click;
            // 
            // LblRegistTnb
            // 
            LblRegistTnb.AutoSize = true;
            LblRegistTnb.ForeColor = Color.Red;
            LblRegistTnb.Location = new Point(11, 134);
            LblRegistTnb.Margin = new Padding(6, 0, 6, 0);
            LblRegistTnb.Name = "LblRegistTnb";
            LblRegistTnb.Size = new Size(152, 32);
            LblRegistTnb.TabIndex = 12;
            LblRegistTnb.Text = "基幹連携OFF";
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblVersion.Location = new Point(52, 933);
            lblVersion.Margin = new Padding(6, 0, 6, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(79, 32);
            lblVersion.TabIndex = 13;
            lblVersion.Text = "label2";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label2.Location = new Point(9, 933);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(50, 32);
            label2.TabIndex = 14;
            label2.Text = "Ver";
            // 
            // btnRegi
            // 
            btnRegi.AccessibleRole = AccessibleRole.None;
            btnRegi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnRegi.Location = new Point(11, 514);
            btnRegi.Margin = new Padding(4, 2, 4, 2);
            btnRegi.Name = "btnRegi";
            btnRegi.Size = new Size(587, 60);
            btnRegi.TabIndex = 71;
            btnRegi.Text = "レジ事前登録一覧";
            btnRegi.UseVisualStyleBackColor = true;
            btnRegi.Click += btnRegi_Click;
            // 
            // btnReserved
            // 
            btnReserved.Location = new Point(11, 594);
            btnReserved.Margin = new Padding(6);
            btnReserved.Name = "btnReserved";
            btnReserved.Size = new Size(587, 49);
            btnReserved.TabIndex = 72;
            btnReserved.Text = "取置一覧";
            btnReserved.UseVisualStyleBackColor = true;
            btnReserved.Click += btnReserved_Click;
            // 
            // btnShippingInspection
            // 
            btnShippingInspection.Location = new Point(9, 655);
            btnShippingInspection.Margin = new Padding(6);
            btnShippingInspection.Name = "btnShippingInspection";
            btnShippingInspection.Size = new Size(587, 49);
            btnShippingInspection.TabIndex = 73;
            btnShippingInspection.Text = "出荷検品";
            btnShippingInspection.UseVisualStyleBackColor = true;
            btnShippingInspection.Click += btnShippingInspection_Click;
            // 
            // button1
            // 
            button1.Location = new Point(9, 731);
            button1.Margin = new Padding(6);
            button1.Name = "button1";
            button1.Size = new Size(587, 49);
            button1.TabIndex = 75;
            button1.Text = "レジ事前登録の修正";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 980);
            Controls.Add(button1);
            Controls.Add(btnShippingInspection);
            Controls.Add(btnReserved);
            Controls.Add(btnRegi);
            Controls.Add(label2);
            Controls.Add(lblVersion);
            Controls.Add(LblRegistTnb);
            Controls.Add(btnReloadOrder);
            Controls.Add(lblDpi);
            Controls.Add(btnChangePrinter);
            Controls.Add(lblDeliPrinter);
            Controls.Add(lblDate);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Controls.Add(btnCustomer);
            Controls.Add(btnSipping);
            Controls.Add(btnPicking);
            Controls.Add(btnOrder);
            Margin = new Padding(4, 2, 4, 2);
            MinimumSize = new Size(433, 491);
            Name = "frmMenu";
            Text = "frmMenu";
            FormClosed += frmMenu_FormClosed;
            Load += frmMenu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOrder;
        private Button btnPicking;
        private Button btnSipping;
        private Button btnCustomer;
        private Label label1;
        private Button btnClose;
        private Label lblDate;
        private Label lblDeliPrinter;
        private Button btnChangePrinter;
        private Label lblDpi;
        private Button btnReloadOrder;
        private Label LblRegistTnb;
        private Label lblVersion;
        private Label label2;
        private Button btnRegi;
        private Button btnReserved;
        private Button btnShippingInspection;
        private Button button1;
    }
}