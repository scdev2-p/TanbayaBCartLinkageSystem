namespace Bcart受注管理.Forms
{
    partial class frmRegistCustomer
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
            label28 = new Label();
            lblCustomerName = new Label();
            lblCustomerID = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtEMail = new TextBox();
            txtZip = new TextBox();
            txtAddress1 = new TextBox();
            txtAddress2 = new TextBox();
            txtAddress3 = new TextBox();
            cmbPrefectures = new ComboBox();
            lblCustomerCode = new Label();
            label2 = new Label();
            txtTel = new TextBox();
            label1 = new Label();
            txtName_Sei = new TextBox();
            txtName_Mei = new TextBox();
            lblCustomerNameKana = new Label();
            label9 = new Label();
            txtFax = new TextBox();
            label8 = new Label();
            txtPassword = new TextBox();
            label10 = new Label();
            lblRank = new Label();
            label12 = new Label();
            lblOversea = new Label();
            label14 = new Label();
            lblTGLimit = new Label();
            label16 = new Label();
            lblClosingDate = new Label();
            label18 = new Label();
            lblPayment1 = new Label();
            label20 = new Label();
            lblPayment2 = new Label();
            lblPayment3 = new Label();
            lblPayment4 = new Label();
            lblPayment5 = new Label();
            label11 = new Label();
            label13 = new Label();
            label15 = new Label();
            label17 = new Label();
            label19 = new Label();
            lblSpecialShippingCost = new Label();
            lblOversea2 = new Label();
            lblRank2 = new Label();
            ToolTip = new ToolTip(components);
            btnRegistBCart = new Button();
            btnClose = new Button();
            SuspendLayout();
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.BorderStyle = BorderStyle.Fixed3D;
            lblDate.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lblDate.Location = new Point(877, 9);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(282, 64);
            lblDate.TabIndex = 10;
            lblDate.Text = "9999年99月99日(月)";
            lblDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblTitle.BorderStyle = BorderStyle.Fixed3D;
            lblTitle.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblTitle.Location = new Point(11, 9);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(571, 64);
            lblTitle.TabIndex = 9;
            lblTitle.Text = "label1";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            label28.BackColor = Color.FromArgb(64, 64, 64);
            label28.BorderStyle = BorderStyle.Fixed3D;
            label28.ForeColor = Color.White;
            label28.Location = new Point(11, 762);
            label28.Margin = new Padding(4, 0, 4, 0);
            label28.Name = "label28";
            label28.Size = new Size(189, 51);
            label28.TabIndex = 57;
            label28.Text = "Eメールアドレス";
            label28.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCustomerName
            // 
            lblCustomerName.BackColor = Color.FromArgb(224, 224, 224);
            lblCustomerName.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerName.ForeColor = Color.Black;
            lblCustomerName.Location = new Point(208, 196);
            lblCustomerName.Margin = new Padding(4, 0, 4, 0);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(455, 51);
            lblCustomerName.TabIndex = 50;
            lblCustomerName.Text = "label11";
            lblCustomerName.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblCustomerName, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // lblCustomerID
            // 
            lblCustomerID.BackColor = Color.FromArgb(224, 224, 224);
            lblCustomerID.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerID.ForeColor = Color.Black;
            lblCustomerID.Location = new Point(208, 94);
            lblCustomerID.Margin = new Padding(4, 0, 4, 0);
            lblCustomerID.Name = "lblCustomerID";
            lblCustomerID.Size = new Size(277, 51);
            lblCustomerID.TabIndex = 49;
            lblCustomerID.Text = "label10";
            lblCustomerID.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblCustomerID, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(64, 64, 64);
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.ForeColor = Color.White;
            label7.Location = new Point(11, 636);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(189, 51);
            label7.TabIndex = 48;
            label7.Text = "電話番号";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(64, 64, 64);
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.White;
            label6.Location = new Point(11, 425);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(189, 51);
            label6.TabIndex = 47;
            label6.Text = "住所";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.ForeColor = Color.White;
            label5.Location = new Point(11, 375);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(189, 51);
            label5.TabIndex = 46;
            label5.Text = "郵便番号";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.White;
            label4.Location = new Point(11, 196);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(189, 51);
            label4.TabIndex = 45;
            label4.Text = "会社名";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.White;
            label3.Location = new Point(11, 94);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(189, 51);
            label3.TabIndex = 44;
            label3.Text = "顧客番号";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEMail
            // 
            txtEMail.Location = new Point(208, 768);
            txtEMail.Margin = new Padding(4, 2, 4, 2);
            txtEMail.Name = "txtEMail";
            txtEMail.Size = new Size(634, 39);
            txtEMail.TabIndex = 78;
            // 
            // txtZip
            // 
            txtZip.Location = new Point(208, 380);
            txtZip.Margin = new Padding(4, 2, 4, 2);
            txtZip.Name = "txtZip";
            txtZip.Size = new Size(275, 39);
            txtZip.TabIndex = 71;
            // 
            // txtAddress1
            // 
            txtAddress1.Location = new Point(208, 478);
            txtAddress1.Margin = new Padding(4, 2, 4, 2);
            txtAddress1.Name = "txtAddress1";
            txtAddress1.Size = new Size(634, 39);
            txtAddress1.TabIndex = 73;
            // 
            // txtAddress2
            // 
            txtAddress2.Location = new Point(208, 523);
            txtAddress2.Margin = new Padding(4, 2, 4, 2);
            txtAddress2.Name = "txtAddress2";
            txtAddress2.Size = new Size(634, 39);
            txtAddress2.TabIndex = 74;
            // 
            // txtAddress3
            // 
            txtAddress3.Location = new Point(208, 570);
            txtAddress3.Margin = new Padding(4, 2, 4, 2);
            txtAddress3.Name = "txtAddress3";
            txtAddress3.Size = new Size(634, 39);
            txtAddress3.TabIndex = 75;
            // 
            // cmbPrefectures
            // 
            cmbPrefectures.DisplayMember = "都道府県コード";
            cmbPrefectures.FormattingEnabled = true;
            cmbPrefectures.Location = new Point(208, 431);
            cmbPrefectures.Margin = new Padding(4, 2, 4, 2);
            cmbPrefectures.Name = "cmbPrefectures";
            cmbPrefectures.Size = new Size(242, 40);
            cmbPrefectures.TabIndex = 72;
            cmbPrefectures.ValueMember = "都道府県コード";
            // 
            // lblCustomerCode
            // 
            lblCustomerCode.BackColor = Color.FromArgb(224, 224, 224);
            lblCustomerCode.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerCode.ForeColor = Color.Black;
            lblCustomerCode.Location = new Point(208, 145);
            lblCustomerCode.Margin = new Padding(4, 0, 4, 0);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(277, 51);
            lblCustomerCode.TabIndex = 66;
            lblCustomerCode.Text = "label10";
            lblCustomerCode.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblCustomerCode, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(11, 145);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(189, 51);
            label2.TabIndex = 65;
            label2.Text = "顧客コード";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTel
            // 
            txtTel.Location = new Point(208, 646);
            txtTel.Margin = new Padding(4, 2, 4, 2);
            txtTel.Name = "txtTel";
            txtTel.Size = new Size(634, 39);
            txtTel.TabIndex = 76;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(64, 64, 64);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 299);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(189, 51);
            label1.TabIndex = 68;
            label1.Text = "担当者名";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName_Sei
            // 
            txtName_Sei.Location = new Point(208, 305);
            txtName_Sei.Margin = new Padding(4, 2, 4, 2);
            txtName_Sei.Name = "txtName_Sei";
            txtName_Sei.Size = new Size(218, 39);
            txtName_Sei.TabIndex = 69;
            // 
            // txtName_Mei
            // 
            txtName_Mei.Location = new Point(433, 305);
            txtName_Mei.Margin = new Padding(4, 2, 4, 2);
            txtName_Mei.Name = "txtName_Mei";
            txtName_Mei.Size = new Size(218, 39);
            txtName_Mei.TabIndex = 70;
            // 
            // lblCustomerNameKana
            // 
            lblCustomerNameKana.BackColor = Color.FromArgb(224, 224, 224);
            lblCustomerNameKana.BorderStyle = BorderStyle.Fixed3D;
            lblCustomerNameKana.ForeColor = Color.Black;
            lblCustomerNameKana.Location = new Point(208, 247);
            lblCustomerNameKana.Margin = new Padding(4, 0, 4, 0);
            lblCustomerNameKana.Name = "lblCustomerNameKana";
            lblCustomerNameKana.Size = new Size(455, 51);
            lblCustomerNameKana.TabIndex = 73;
            lblCustomerNameKana.Text = "label11";
            lblCustomerNameKana.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblCustomerNameKana, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.ForeColor = Color.White;
            label9.Location = new Point(11, 247);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(189, 51);
            label9.TabIndex = 72;
            label9.Text = "会社名カナ";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtFax
            // 
            txtFax.Location = new Point(208, 693);
            txtFax.Margin = new Padding(4, 2, 4, 2);
            txtFax.Name = "txtFax";
            txtFax.Size = new Size(634, 39);
            txtFax.TabIndex = 77;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(64, 64, 64);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.ForeColor = Color.White;
            label8.Location = new Point(11, 687);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(189, 51);
            label8.TabIndex = 74;
            label8.Text = "FAX";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(208, 819);
            txtPassword.Margin = new Padding(4, 2, 4, 2);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(634, 39);
            txtPassword.TabIndex = 79;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(64, 64, 64);
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.ForeColor = Color.White;
            label10.Location = new Point(11, 813);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(189, 51);
            label10.TabIndex = 76;
            label10.Text = "パスワード";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRank
            // 
            lblRank.BackColor = Color.FromArgb(224, 224, 224);
            lblRank.BorderStyle = BorderStyle.Fixed3D;
            lblRank.ForeColor = Color.Black;
            lblRank.Location = new Point(878, 94);
            lblRank.Margin = new Padding(4, 0, 4, 0);
            lblRank.Name = "lblRank";
            lblRank.Size = new Size(277, 51);
            lblRank.TabIndex = 79;
            lblRank.Text = "label10";
            lblRank.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblRank, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(64, 64, 64);
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.ForeColor = Color.White;
            label12.Location = new Point(683, 94);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(189, 51);
            label12.TabIndex = 78;
            label12.Text = "ランク";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOversea
            // 
            lblOversea.BackColor = Color.FromArgb(224, 224, 224);
            lblOversea.BorderStyle = BorderStyle.Fixed3D;
            lblOversea.ForeColor = Color.Black;
            lblOversea.Location = new Point(878, 145);
            lblOversea.Margin = new Padding(4, 0, 4, 0);
            lblOversea.Name = "lblOversea";
            lblOversea.Size = new Size(277, 51);
            lblOversea.TabIndex = 81;
            lblOversea.Text = "label10";
            lblOversea.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblOversea, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label14
            // 
            label14.BackColor = Color.FromArgb(64, 64, 64);
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.ForeColor = Color.White;
            label14.Location = new Point(683, 145);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(189, 51);
            label14.TabIndex = 80;
            label14.Text = "海外禁止";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTGLimit
            // 
            lblTGLimit.BackColor = Color.FromArgb(224, 224, 224);
            lblTGLimit.BorderStyle = BorderStyle.Fixed3D;
            lblTGLimit.ForeColor = Color.Black;
            lblTGLimit.Location = new Point(878, 196);
            lblTGLimit.Margin = new Padding(4, 0, 4, 0);
            lblTGLimit.Name = "lblTGLimit";
            lblTGLimit.Size = new Size(277, 51);
            lblTGLimit.TabIndex = 83;
            lblTGLimit.Text = "label10";
            lblTGLimit.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblTGLimit, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label16
            // 
            label16.BackColor = Color.FromArgb(64, 64, 64);
            label16.BorderStyle = BorderStyle.Fixed3D;
            label16.ForeColor = Color.White;
            label16.Location = new Point(683, 196);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(189, 51);
            label16.TabIndex = 82;
            label16.Text = "TG設定額";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblClosingDate
            // 
            lblClosingDate.BackColor = Color.FromArgb(224, 224, 224);
            lblClosingDate.BorderStyle = BorderStyle.Fixed3D;
            lblClosingDate.ForeColor = Color.Black;
            lblClosingDate.Location = new Point(878, 247);
            lblClosingDate.Margin = new Padding(4, 0, 4, 0);
            lblClosingDate.Name = "lblClosingDate";
            lblClosingDate.Size = new Size(277, 51);
            lblClosingDate.TabIndex = 85;
            lblClosingDate.Text = "label10";
            lblClosingDate.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblClosingDate, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label18
            // 
            label18.BackColor = Color.FromArgb(64, 64, 64);
            label18.BorderStyle = BorderStyle.Fixed3D;
            label18.ForeColor = Color.White;
            label18.Location = new Point(683, 247);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(189, 51);
            label18.TabIndex = 84;
            label18.Text = "締め日";
            label18.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPayment1
            // 
            lblPayment1.BackColor = Color.FromArgb(224, 224, 224);
            lblPayment1.BorderStyle = BorderStyle.Fixed3D;
            lblPayment1.ForeColor = Color.Black;
            lblPayment1.Location = new Point(878, 348);
            lblPayment1.Margin = new Padding(4, 0, 4, 0);
            lblPayment1.Name = "lblPayment1";
            lblPayment1.Size = new Size(277, 51);
            lblPayment1.TabIndex = 87;
            lblPayment1.Text = "label10";
            lblPayment1.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblPayment1, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label20
            // 
            label20.BackColor = Color.FromArgb(64, 64, 64);
            label20.BorderStyle = BorderStyle.Fixed3D;
            label20.ForeColor = Color.White;
            label20.Location = new Point(683, 348);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(189, 51);
            label20.TabIndex = 86;
            label20.Text = "決済方法";
            label20.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPayment2
            // 
            lblPayment2.BackColor = Color.FromArgb(224, 224, 224);
            lblPayment2.BorderStyle = BorderStyle.Fixed3D;
            lblPayment2.ForeColor = Color.Black;
            lblPayment2.Location = new Point(878, 399);
            lblPayment2.Margin = new Padding(4, 0, 4, 0);
            lblPayment2.Name = "lblPayment2";
            lblPayment2.Size = new Size(277, 51);
            lblPayment2.TabIndex = 88;
            lblPayment2.Text = "label10";
            lblPayment2.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblPayment2, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // lblPayment3
            // 
            lblPayment3.BackColor = Color.FromArgb(224, 224, 224);
            lblPayment3.BorderStyle = BorderStyle.Fixed3D;
            lblPayment3.ForeColor = Color.Black;
            lblPayment3.Location = new Point(878, 448);
            lblPayment3.Margin = new Padding(4, 0, 4, 0);
            lblPayment3.Name = "lblPayment3";
            lblPayment3.Size = new Size(277, 51);
            lblPayment3.TabIndex = 89;
            lblPayment3.Text = "label10";
            lblPayment3.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblPayment3, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // lblPayment4
            // 
            lblPayment4.BackColor = Color.FromArgb(224, 224, 224);
            lblPayment4.BorderStyle = BorderStyle.Fixed3D;
            lblPayment4.ForeColor = Color.Black;
            lblPayment4.Location = new Point(878, 497);
            lblPayment4.Margin = new Padding(4, 0, 4, 0);
            lblPayment4.Name = "lblPayment4";
            lblPayment4.Size = new Size(277, 51);
            lblPayment4.TabIndex = 90;
            lblPayment4.Text = "label10";
            lblPayment4.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblPayment4, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // lblPayment5
            // 
            lblPayment5.BackColor = Color.FromArgb(224, 224, 224);
            lblPayment5.BorderStyle = BorderStyle.Fixed3D;
            lblPayment5.ForeColor = Color.Black;
            lblPayment5.Location = new Point(878, 548);
            lblPayment5.Margin = new Padding(4, 0, 4, 0);
            lblPayment5.Name = "lblPayment5";
            lblPayment5.Size = new Size(277, 51);
            lblPayment5.TabIndex = 91;
            lblPayment5.Text = "label10";
            lblPayment5.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblPayment5, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(852, 655);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(150, 32);
            label11.TabIndex = 92;
            label11.Text = "※ハイフン付き";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(490, 384);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(150, 32);
            label13.TabIndex = 93;
            label13.Text = "※ハイフン付き";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(852, 702);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(150, 32);
            label15.TabIndex = 94;
            label15.Text = "※ハイフン付き";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(208, 879);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(761, 32);
            label17.TabIndex = 95;
            label17.Text = "※「英字（大文字）」「英字（小文字）」「数字」を1文字以上含む（半角）";
            // 
            // label19
            // 
            label19.BackColor = Color.FromArgb(64, 64, 64);
            label19.BorderStyle = BorderStyle.Fixed3D;
            label19.ForeColor = Color.White;
            label19.Location = new Point(683, 299);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(189, 51);
            label19.TabIndex = 96;
            label19.Text = "特別送料";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSpecialShippingCost
            // 
            lblSpecialShippingCost.BackColor = Color.FromArgb(224, 224, 224);
            lblSpecialShippingCost.BorderStyle = BorderStyle.Fixed3D;
            lblSpecialShippingCost.ForeColor = Color.Black;
            lblSpecialShippingCost.Location = new Point(878, 299);
            lblSpecialShippingCost.Margin = new Padding(4, 0, 4, 0);
            lblSpecialShippingCost.Name = "lblSpecialShippingCost";
            lblSpecialShippingCost.Size = new Size(277, 51);
            lblSpecialShippingCost.TabIndex = 97;
            lblSpecialShippingCost.Text = "label10";
            lblSpecialShippingCost.TextAlign = ContentAlignment.MiddleLeft;
            ToolTip.SetToolTip(lblSpecialShippingCost, "ラベルをダブルクリックするとテキストがコピーできます");
            // 
            // lblOversea2
            // 
            lblOversea2.AutoSize = true;
            lblOversea2.Location = new Point(6, 879);
            lblOversea2.Margin = new Padding(6, 0, 6, 0);
            lblOversea2.Name = "lblOversea2";
            lblOversea2.Size = new Size(96, 32);
            lblOversea2.TabIndex = 100;
            lblOversea2.Text = "oversea";
            lblOversea2.Visible = false;
            // 
            // lblRank2
            // 
            lblRank2.AutoSize = true;
            lblRank2.Location = new Point(98, 879);
            lblRank2.Margin = new Padding(6, 0, 6, 0);
            lblRank2.Name = "lblRank2";
            lblRank2.Size = new Size(60, 32);
            lblRank2.TabIndex = 101;
            lblRank2.Text = "rank";
            lblRank2.Visible = false;
            // 
            // ToolTip
            // 
            ToolTip.ToolTipIcon = ToolTipIcon.Info;
            ToolTip.ToolTipTitle = "コピーできます";
            // 
            // btnRegistBCart
            // 
            btnRegistBCart.Location = new Point(586, 934);
            btnRegistBCart.Margin = new Padding(4, 2, 4, 2);
            btnRegistBCart.Name = "btnRegistBCart";
            btnRegistBCart.Size = new Size(316, 47);
            btnRegistBCart.TabIndex = 102;
            btnRegistBCart.Text = "BCartに登録する";
            btnRegistBCart.UseVisualStyleBackColor = true;
            btnRegistBCart.Click += btnRegistBCart_Click;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(955, 934);
            btnClose.Margin = new Padding(4, 2, 4, 2);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 47);
            btnClose.TabIndex = 103;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // frmRegistCustomer
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1173, 1005);
            Controls.Add(btnClose);
            Controls.Add(btnRegistBCart);
            Controls.Add(lblRank2);
            Controls.Add(lblOversea2);
            Controls.Add(lblSpecialShippingCost);
            Controls.Add(label19);
            Controls.Add(label17);
            Controls.Add(label15);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(lblPayment5);
            Controls.Add(lblPayment4);
            Controls.Add(lblPayment3);
            Controls.Add(lblPayment2);
            Controls.Add(lblPayment1);
            Controls.Add(label20);
            Controls.Add(lblClosingDate);
            Controls.Add(label18);
            Controls.Add(lblTGLimit);
            Controls.Add(label16);
            Controls.Add(lblOversea);
            Controls.Add(label14);
            Controls.Add(lblRank);
            Controls.Add(label12);
            Controls.Add(txtPassword);
            Controls.Add(label10);
            Controls.Add(txtFax);
            Controls.Add(label8);
            Controls.Add(lblCustomerNameKana);
            Controls.Add(label9);
            Controls.Add(txtName_Mei);
            Controls.Add(txtName_Sei);
            Controls.Add(label1);
            Controls.Add(txtTel);
            Controls.Add(lblCustomerCode);
            Controls.Add(label2);
            Controls.Add(cmbPrefectures);
            Controls.Add(txtAddress3);
            Controls.Add(txtAddress2);
            Controls.Add(txtAddress1);
            Controls.Add(txtZip);
            Controls.Add(txtEMail);
            Controls.Add(label28);
            Controls.Add(lblCustomerName);
            Controls.Add(lblCustomerID);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblDate);
            Controls.Add(lblTitle);
            Margin = new Padding(4, 2, 4, 2);
            Name = "frmRegistCustomer";
            Text = "顧客登録";
            FormClosed += frmRegistCustomer_FormClosed;
            Load += frmRegistCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLoginName;
        private Label lblDate;
        private Label lblTitle;
        private Label label28;
        private Label lblCustomerName;
        private Label lblCustomerID;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtEMail;
        private TextBox txtZip;
        private TextBox txtAddress1;
        private TextBox txtAddress2;
        private TextBox txtAddress3;
        private ComboBox cmbPrefectures;
        private Label lblCustomerCode;
        private Label label2;
        private TextBox txtTel;
        private Label label1;
        private TextBox txtName_Sei;
        private TextBox txtName_Mei;
        private Label lblCustomerNameKana;
        private Label label9;
        private TextBox txtFax;
        private Label label8;
        private TextBox txtPassword;
        private Label label10;
        private Label lblRank;
        private Label label12;
        private Label lblOversea;
        private Label label14;
        private Label lblTGLimit;
        private Label label16;
        private Label lblClosingDate;
        private Label label18;
        private Label lblPayment1;
        private Label label20;
        private Label lblPayment2;
        private Label lblPayment3;
        private Label lblPayment4;
        private Label lblPayment5;
        private Label label11;
        private Label label13;
        private Label label15;
        private Label label17;
        private Label label19;
        private Label lblSpecialShippingCost;
        private Label lblExtId;
        private Label label22;
        private Label lblOversea2;
        private Label lblTGLimit2;
        private Label label24;
        private Label label25;
        private Label lblRank2;
        private ToolTip ToolTip;
        private Button btnRegistBCart;
        private Button btnClose;
    }
}