namespace BCart商品登録.Forms
{
    partial class frmNewProductsDetaail
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
            label1 = new Label();
            label2 = new Label();
            txtName = new TextBox();
            panel1 = new Panel();
            txtMetaKeyword = new TextBox();
            label16 = new Label();
            lstCategory1 = new ComboBox();
            chkTag_Original = new CheckBox();
            chkTag_Sale = new CheckBox();
            chkTag_Standard = new CheckBox();
            chkTag_Limited = new CheckBox();
            chkTag_Recommend = new CheckBox();
            chkTag_New = new CheckBox();
            chkTag_4F = new CheckBox();
            chkTag_3F = new CheckBox();
            chkTag_2F = new CheckBox();
            chkTag_1F = new CheckBox();
            txtCategory1 = new TextBox();
            txtBrand = new TextBox();
            label40 = new Label();
            txtSameSeries = new TextBox();
            label34 = new Label();
            txtSaleCondition = new TextBox();
            label32 = new Label();
            txtInfo = new TextBox();
            label31 = new Label();
            txtTanto = new TextBox();
            label30 = new Label();
            label33 = new Label();
            label24 = new Label();
            label27 = new Label();
            txtSubCategory = new TextBox();
            txtDescription = new TextBox();
            txtNote = new TextBox();
            txtMaker = new TextBox();
            txtCaution = new TextBox();
            txtSozai = new TextBox();
            label14 = new Label();
            txtSize = new TextBox();
            txtMadeIn = new TextBox();
            lstFeature3 = new ComboBox();
            lstFeature2 = new ComboBox();
            lstFeature1 = new ComboBox();
            txtCatchCopy = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lblSearch = new Label();
            btnRegist = new Button();
            btnCancel = new Button();
            label23 = new Label();
            label25 = new Label();
            lblJoudai = new Label();
            label26 = new Label();
            txtSetName = new TextBox();
            label28 = new Label();
            label35 = new Label();
            txtProductSetNo = new TextBox();
            label29 = new Label();
            dgvBarcodeList = new DataGridView();
            Barcode = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            btnClear = new Button();
            txtBarcode = new TextBox();
            label36 = new Label();
            label37 = new Label();
            lblStock = new Label();
            lblBarcodeRequired = new Label();
            label38 = new Label();
            txtProductNo = new TextBox();
            label41 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBarcodeList).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(13, 9);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(1348, 64);
            label1.TabIndex = 0;
            label1.Text = "Bカート新規商品登録";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.FromArgb(64, 64, 64);
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.ForeColor = Color.White;
            label2.Location = new Point(23, 85);
            label2.Name = "label2";
            label2.Size = new Size(185, 39);
            label2.TabIndex = 1;
            label2.Text = "商品名";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(255, 255, 192);
            txtName.Location = new Point(214, 85);
            txtName.Name = "txtName";
            txtName.Size = new Size(1124, 39);
            txtName.TabIndex = 0;
            txtName.Text = "●●●●●●●●●";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(txtMetaKeyword);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(lstCategory1);
            panel1.Controls.Add(chkTag_Original);
            panel1.Controls.Add(chkTag_Sale);
            panel1.Controls.Add(chkTag_Standard);
            panel1.Controls.Add(chkTag_Limited);
            panel1.Controls.Add(chkTag_Recommend);
            panel1.Controls.Add(chkTag_New);
            panel1.Controls.Add(chkTag_4F);
            panel1.Controls.Add(chkTag_3F);
            panel1.Controls.Add(chkTag_2F);
            panel1.Controls.Add(chkTag_1F);
            panel1.Controls.Add(txtCategory1);
            panel1.Controls.Add(txtBrand);
            panel1.Controls.Add(label40);
            panel1.Controls.Add(txtSameSeries);
            panel1.Controls.Add(label34);
            panel1.Controls.Add(txtSaleCondition);
            panel1.Controls.Add(label32);
            panel1.Controls.Add(txtInfo);
            panel1.Controls.Add(label31);
            panel1.Controls.Add(txtTanto);
            panel1.Controls.Add(label30);
            panel1.Controls.Add(label33);
            panel1.Controls.Add(label24);
            panel1.Controls.Add(label27);
            panel1.Controls.Add(txtSubCategory);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(txtNote);
            panel1.Controls.Add(txtMaker);
            panel1.Controls.Add(txtCaution);
            panel1.Controls.Add(txtSozai);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(txtSize);
            panel1.Controls.Add(txtMadeIn);
            panel1.Controls.Add(lstFeature3);
            panel1.Controls.Add(lstFeature2);
            panel1.Controls.Add(lstFeature1);
            panel1.Controls.Add(txtCatchCopy);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(13, 228);
            panel1.Name = "panel1";
            panel1.Size = new Size(362, 292);
            panel1.TabIndex = 5;
            // 
            // txtMetaKeyword
            // 
            txtMetaKeyword.BackColor = Color.White;
            txtMetaKeyword.Location = new Point(334, 1820);
            txtMetaKeyword.Name = "txtMetaKeyword";
            txtMetaKeyword.Size = new Size(969, 39);
            txtMetaKeyword.TabIndex = 104;
            // 
            // label16
            // 
            label16.BackColor = Color.FromArgb(64, 64, 64);
            label16.BorderStyle = BorderStyle.Fixed3D;
            label16.ForeColor = Color.White;
            label16.Location = new Point(12, 1820);
            label16.Name = "label16";
            label16.Size = new Size(316, 39);
            label16.TabIndex = 103;
            label16.Text = "META keyword";
            label16.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lstCategory1
            // 
            lstCategory1.DropDownStyle = ComboBoxStyle.DropDownList;
            lstCategory1.FormattingEnabled = true;
            lstCategory1.Location = new Point(427, 13);
            lstCategory1.Name = "lstCategory1";
            lstCategory1.Size = new Size(506, 40);
            lstCategory1.TabIndex = 102;
            lstCategory1.SelectedIndexChanged += lstCategory1_SelectedIndexChanged;
            // 
            // chkTag_Original
            // 
            chkTag_Original.AutoSize = true;
            chkTag_Original.Location = new Point(1255, 179);
            chkTag_Original.Name = "chkTag_Original";
            chkTag_Original.Size = new Size(210, 36);
            chkTag_Original.TabIndex = 93;
            chkTag_Original.Tag = "original";
            chkTag_Original.Text = "丹波屋オリジナル";
            chkTag_Original.UseVisualStyleBackColor = true;
            // 
            // chkTag_Sale
            // 
            chkTag_Sale.AutoSize = true;
            chkTag_Sale.Location = new Point(1152, 179);
            chkTag_Sale.Name = "chkTag_Sale";
            chkTag_Sale.Size = new Size(97, 36);
            chkTag_Sale.TabIndex = 92;
            chkTag_Sale.Tag = "sale";
            chkTag_Sale.Text = "SALE";
            chkTag_Sale.UseVisualStyleBackColor = true;
            // 
            // chkTag_Standard
            // 
            chkTag_Standard.AutoSize = true;
            chkTag_Standard.Location = new Point(1052, 179);
            chkTag_Standard.Name = "chkTag_Standard";
            chkTag_Standard.Size = new Size(94, 36);
            chkTag_Standard.TabIndex = 91;
            chkTag_Standard.Tag = "standard";
            chkTag_Standard.Text = "定番";
            chkTag_Standard.UseVisualStyleBackColor = true;
            // 
            // chkTag_Limited
            // 
            chkTag_Limited.AutoSize = true;
            chkTag_Limited.Location = new Point(904, 179);
            chkTag_Limited.Name = "chkTag_Limited";
            chkTag_Limited.Size = new Size(142, 36);
            chkTag_Limited.TabIndex = 90;
            chkTag_Limited.Tag = "limited";
            chkTag_Limited.Text = "限定商品";
            chkTag_Limited.UseVisualStyleBackColor = true;
            // 
            // chkTag_Recommend
            // 
            chkTag_Recommend.AutoSize = true;
            chkTag_Recommend.Location = new Point(773, 178);
            chkTag_Recommend.Name = "chkTag_Recommend";
            chkTag_Recommend.Size = new Size(125, 36);
            chkTag_Recommend.TabIndex = 89;
            chkTag_Recommend.Tag = "recommend";
            chkTag_Recommend.Text = "おすすめ";
            chkTag_Recommend.UseVisualStyleBackColor = true;
            // 
            // chkTag_New
            // 
            chkTag_New.AutoSize = true;
            chkTag_New.Checked = true;
            chkTag_New.CheckState = CheckState.Checked;
            chkTag_New.Location = new Point(673, 178);
            chkTag_New.Name = "chkTag_New";
            chkTag_New.Size = new Size(94, 36);
            chkTag_New.TabIndex = 88;
            chkTag_New.Tag = "new";
            chkTag_New.Text = "新着";
            chkTag_New.UseVisualStyleBackColor = true;
            // 
            // chkTag_4F
            // 
            chkTag_4F.AutoSize = true;
            chkTag_4F.Location = new Point(593, 178);
            chkTag_4F.Name = "chkTag_4F";
            chkTag_4F.Size = new Size(71, 36);
            chkTag_4F.TabIndex = 87;
            chkTag_4F.Tag = "4f";
            chkTag_4F.Text = "4F";
            chkTag_4F.UseVisualStyleBackColor = true;
            // 
            // chkTag_3F
            // 
            chkTag_3F.AutoSize = true;
            chkTag_3F.Location = new Point(516, 178);
            chkTag_3F.Name = "chkTag_3F";
            chkTag_3F.Size = new Size(71, 36);
            chkTag_3F.TabIndex = 86;
            chkTag_3F.Tag = "3f";
            chkTag_3F.Text = "3F";
            chkTag_3F.UseVisualStyleBackColor = true;
            // 
            // chkTag_2F
            // 
            chkTag_2F.AutoSize = true;
            chkTag_2F.Location = new Point(439, 178);
            chkTag_2F.Name = "chkTag_2F";
            chkTag_2F.Size = new Size(71, 36);
            chkTag_2F.TabIndex = 85;
            chkTag_2F.Tag = "2f";
            chkTag_2F.Text = "2F";
            chkTag_2F.UseVisualStyleBackColor = true;
            // 
            // chkTag_1F
            // 
            chkTag_1F.AutoSize = true;
            chkTag_1F.Location = new Point(362, 179);
            chkTag_1F.Name = "chkTag_1F";
            chkTag_1F.Size = new Size(71, 36);
            chkTag_1F.TabIndex = 84;
            chkTag_1F.Tag = "1f";
            chkTag_1F.Text = "1F";
            chkTag_1F.UseVisualStyleBackColor = true;
            // 
            // txtCategory1
            // 
            txtCategory1.BackColor = Color.FromArgb(255, 255, 192);
            txtCategory1.Location = new Point(334, 12);
            txtCategory1.Name = "txtCategory1";
            txtCategory1.Size = new Size(87, 39);
            txtCategory1.TabIndex = 82;
            txtCategory1.TextChanged += txtCategory1_TextChanged;
            txtCategory1.KeyDown += txtCategory1_KeyDown;
            txtCategory1.KeyPress += txtCategory1_KeyPress;
            txtCategory1.Leave += txtCategory1_Leave;
            // 
            // txtBrand
            // 
            txtBrand.BackColor = Color.White;
            txtBrand.Location = new Point(334, 1053);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(966, 39);
            txtBrand.TabIndex = 80;
            // 
            // label40
            // 
            label40.BackColor = Color.FromArgb(64, 64, 64);
            label40.BorderStyle = BorderStyle.Fixed3D;
            label40.ForeColor = Color.White;
            label40.Location = new Point(10, 1053);
            label40.Name = "label40";
            label40.Size = new Size(318, 39);
            label40.TabIndex = 81;
            label40.Text = "ブランド";
            label40.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSameSeries
            // 
            txtSameSeries.BackColor = Color.White;
            txtSameSeries.Location = new Point(332, 1445);
            txtSameSeries.Multiline = true;
            txtSameSeries.Name = "txtSameSeries";
            txtSameSeries.ScrollBars = ScrollBars.Both;
            txtSameSeries.Size = new Size(971, 120);
            txtSameSeries.TabIndex = 76;
            // 
            // label34
            // 
            label34.BackColor = Color.FromArgb(64, 64, 64);
            label34.BorderStyle = BorderStyle.Fixed3D;
            label34.ForeColor = Color.White;
            label34.Location = new Point(10, 1445);
            label34.Name = "label34";
            label34.Size = new Size(318, 39);
            label34.TabIndex = 77;
            label34.Text = "同シリーズはこちら→(HTML)";
            label34.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSaleCondition
            // 
            txtSaleCondition.BackColor = Color.White;
            txtSaleCondition.Location = new Point(332, 1307);
            txtSaleCondition.Multiline = true;
            txtSaleCondition.Name = "txtSaleCondition";
            txtSaleCondition.ScrollBars = ScrollBars.Both;
            txtSaleCondition.Size = new Size(971, 120);
            txtSaleCondition.TabIndex = 74;
            // 
            // label32
            // 
            label32.BackColor = Color.FromArgb(64, 64, 64);
            label32.BorderStyle = BorderStyle.Fixed3D;
            label32.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label32.ForeColor = Color.White;
            label32.Location = new Point(10, 1307);
            label32.Name = "label32";
            label32.Size = new Size(318, 39);
            label32.TabIndex = 75;
            label32.Text = "販売条件 (HTML)";
            label32.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtInfo
            // 
            txtInfo.BackColor = Color.White;
            txtInfo.Location = new Point(334, 1172);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ScrollBars = ScrollBars.Both;
            txtInfo.Size = new Size(969, 120);
            txtInfo.TabIndex = 72;
            // 
            // label31
            // 
            label31.BackColor = Color.FromArgb(64, 64, 64);
            label31.BorderStyle = BorderStyle.Fixed3D;
            label31.ForeColor = Color.White;
            label31.Location = new Point(10, 1172);
            label31.Name = "label31";
            label31.Size = new Size(318, 39);
            label31.TabIndex = 73;
            label31.Text = "お知らせ (HTML)";
            label31.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTanto
            // 
            txtTanto.BackColor = Color.White;
            txtTanto.Location = new Point(334, 1112);
            txtTanto.Name = "txtTanto";
            txtTanto.Size = new Size(966, 39);
            txtTanto.TabIndex = 70;
            txtTanto.KeyDown += txtTanto_KeyDown;
            // 
            // label30
            // 
            label30.BackColor = Color.FromArgb(64, 64, 64);
            label30.BorderStyle = BorderStyle.Fixed3D;
            label30.ForeColor = Color.White;
            label30.Location = new Point(10, 1112);
            label30.Name = "label30";
            label30.Size = new Size(318, 39);
            label30.TabIndex = 71;
            label30.Text = "担当者";
            label30.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label33.ForeColor = Color.Red;
            label33.Location = new Point(1306, 829);
            label33.Name = "label33";
            label33.Size = new Size(86, 32);
            label33.TabIndex = 69;
            label33.Text = "【必須】";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label24.ForeColor = Color.Red;
            label24.Location = new Point(811, 16);
            label24.Name = "label24";
            label24.Size = new Size(86, 32);
            label24.TabIndex = 63;
            label24.Text = "【必須】";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(990, 66);
            label27.Name = "label27";
            label27.Size = new Size(303, 32);
            label27.TabIndex = 62;
            label27.Text = "カンマ区切りで入力してください";
            // 
            // txtSubCategory
            // 
            txtSubCategory.Location = new Point(332, 63);
            txtSubCategory.Name = "txtSubCategory";
            txtSubCategory.Size = new Size(652, 39);
            txtSubCategory.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.BackColor = Color.White;
            txtDescription.Location = new Point(334, 1585);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Both;
            txtDescription.Size = new Size(971, 218);
            txtDescription.TabIndex = 13;
            // 
            // txtNote
            // 
            txtNote.Location = new Point(334, 882);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.ScrollBars = ScrollBars.Both;
            txtNote.Size = new Size(966, 150);
            txtNote.TabIndex = 12;
            // 
            // txtMaker
            // 
            txtMaker.BackColor = Color.FromArgb(255, 255, 192);
            txtMaker.Location = new Point(332, 826);
            txtMaker.Name = "txtMaker";
            txtMaker.Size = new Size(968, 39);
            txtMaker.TabIndex = 11;
            txtMaker.KeyDown += txtMaker_KeyDown;
            // 
            // txtCaution
            // 
            txtCaution.Location = new Point(332, 671);
            txtCaution.Multiline = true;
            txtCaution.Name = "txtCaution";
            txtCaution.ScrollBars = ScrollBars.Both;
            txtCaution.Size = new Size(968, 136);
            txtCaution.TabIndex = 10;
            // 
            // txtSozai
            // 
            txtSozai.BackColor = Color.White;
            txtSozai.Location = new Point(332, 499);
            txtSozai.Multiline = true;
            txtSozai.Name = "txtSozai";
            txtSozai.ScrollBars = ScrollBars.Both;
            txtSozai.Size = new Size(968, 150);
            txtSozai.TabIndex = 9;
            // 
            // label14
            // 
            label14.BackColor = Color.FromArgb(64, 64, 64);
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.ForeColor = Color.White;
            label14.Location = new Point(12, 1585);
            label14.Name = "label14";
            label14.Size = new Size(316, 39);
            label14.TabIndex = 26;
            label14.Text = "説明 (HTML)";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSize
            // 
            txtSize.BackColor = Color.White;
            txtSize.Location = new Point(332, 329);
            txtSize.Multiline = true;
            txtSize.Name = "txtSize";
            txtSize.ScrollBars = ScrollBars.Both;
            txtSize.Size = new Size(968, 150);
            txtSize.TabIndex = 8;
            // 
            // txtMadeIn
            // 
            txtMadeIn.BackColor = Color.White;
            txtMadeIn.Location = new Point(332, 279);
            txtMadeIn.Name = "txtMadeIn";
            txtMadeIn.Size = new Size(968, 39);
            txtMadeIn.TabIndex = 7;
            // 
            // lstFeature3
            // 
            lstFeature3.DropDownStyle = ComboBoxStyle.DropDownList;
            lstFeature3.FlatStyle = FlatStyle.Flat;
            lstFeature3.FormattingEnabled = true;
            lstFeature3.Location = new Point(990, 130);
            lstFeature3.Name = "lstFeature3";
            lstFeature3.Size = new Size(323, 40);
            lstFeature3.TabIndex = 4;
            // 
            // lstFeature2
            // 
            lstFeature2.DropDownStyle = ComboBoxStyle.DropDownList;
            lstFeature2.FlatStyle = FlatStyle.Flat;
            lstFeature2.FormattingEnabled = true;
            lstFeature2.Location = new Point(661, 131);
            lstFeature2.Name = "lstFeature2";
            lstFeature2.Size = new Size(323, 40);
            lstFeature2.TabIndex = 3;
            // 
            // lstFeature1
            // 
            lstFeature1.DropDownStyle = ComboBoxStyle.DropDownList;
            lstFeature1.FlatStyle = FlatStyle.Flat;
            lstFeature1.FormattingEnabled = true;
            lstFeature1.Location = new Point(332, 131);
            lstFeature1.Name = "lstFeature1";
            lstFeature1.Size = new Size(323, 40);
            lstFeature1.TabIndex = 2;
            // 
            // txtCatchCopy
            // 
            txtCatchCopy.Location = new Point(332, 229);
            txtCatchCopy.Name = "txtCatchCopy";
            txtCatchCopy.Size = new Size(968, 39);
            txtCatchCopy.TabIndex = 6;
            // 
            // label13
            // 
            label13.BackColor = Color.FromArgb(64, 64, 64);
            label13.BorderStyle = BorderStyle.Fixed3D;
            label13.ForeColor = Color.White;
            label13.Location = new Point(12, 882);
            label13.Name = "label13";
            label13.Size = new Size(318, 39);
            label13.TabIndex = 24;
            label13.Text = "備考";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.BackColor = Color.FromArgb(64, 64, 64);
            label12.BorderStyle = BorderStyle.Fixed3D;
            label12.ForeColor = Color.White;
            label12.Location = new Point(10, 826);
            label12.Name = "label12";
            label12.Size = new Size(318, 39);
            label12.TabIndex = 22;
            label12.Text = "メーカー";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.BackColor = Color.FromArgb(64, 64, 64);
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.ForeColor = Color.White;
            label11.Location = new Point(12, 671);
            label11.Name = "label11";
            label11.Size = new Size(316, 39);
            label11.TabIndex = 20;
            label11.Text = "注意事項 (HTML)";
            label11.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.BackColor = Color.FromArgb(64, 64, 64);
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.ForeColor = Color.White;
            label10.Location = new Point(10, 499);
            label10.Name = "label10";
            label10.Size = new Size(316, 39);
            label10.TabIndex = 18;
            label10.Text = "素材 (HTML)";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.BackColor = Color.FromArgb(64, 64, 64);
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.ForeColor = Color.White;
            label9.Location = new Point(10, 329);
            label9.Name = "label9";
            label9.Size = new Size(316, 39);
            label9.TabIndex = 16;
            label9.Text = "サイズ (HTML)";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.FromArgb(64, 64, 64);
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.ForeColor = Color.White;
            label8.Location = new Point(10, 279);
            label8.Name = "label8";
            label8.Size = new Size(316, 39);
            label8.TabIndex = 14;
            label8.Text = "生産地";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.BackColor = Color.FromArgb(64, 64, 64);
            label7.BorderStyle = BorderStyle.Fixed3D;
            label7.ForeColor = Color.White;
            label7.Location = new Point(10, 229);
            label7.Name = "label7";
            label7.Size = new Size(316, 39);
            label7.TabIndex = 12;
            label7.Text = "キャッチコピー";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.FromArgb(64, 64, 64);
            label6.BorderStyle = BorderStyle.Fixed3D;
            label6.ForeColor = Color.White;
            label6.Location = new Point(10, 179);
            label6.Name = "label6";
            label6.Size = new Size(316, 39);
            label6.TabIndex = 10;
            label6.Text = "商品特徴";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.FromArgb(64, 64, 64);
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.ForeColor = Color.White;
            label5.Location = new Point(10, 131);
            label5.Name = "label5";
            label5.Size = new Size(316, 39);
            label5.TabIndex = 6;
            label5.Text = "特集";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.FromArgb(64, 64, 64);
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.ForeColor = Color.White;
            label4.Location = new Point(10, 63);
            label4.Name = "label4";
            label4.Size = new Size(316, 39);
            label4.TabIndex = 2;
            label4.Text = "サブカテゴリ";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.FromArgb(64, 64, 64);
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.ForeColor = Color.White;
            label3.Location = new Point(10, 13);
            label3.Name = "label3";
            label3.Size = new Size(318, 39);
            label3.TabIndex = 0;
            label3.Text = "メインカテゴリ";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSearch
            // 
            lblSearch.BackColor = Color.FromArgb(255, 224, 192);
            lblSearch.BorderStyle = BorderStyle.FixedSingle;
            lblSearch.Font = new Font("Yu Gothic UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblSearch.ForeColor = Color.Red;
            lblSearch.Location = new Point(746, 195);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(262, 94);
            lblSearch.TabIndex = 76;
            lblSearch.Text = "検索中";
            lblSearch.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRegist
            // 
            btnRegist.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRegist.Location = new Point(1051, 481);
            btnRegist.Name = "btnRegist";
            btnRegist.Size = new Size(281, 53);
            btnRegist.TabIndex = 4;
            btnRegist.Text = "登録して次の商品へ";
            btnRegist.UseVisualStyleBackColor = true;
            btnRegist.Click += btnRegist_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(783, 481);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(194, 53);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "中断";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(643, 186);
            label23.Name = "label23";
            label23.Size = new Size(97, 32);
            label23.TabIndex = 5;
            label23.Text = "バーコード";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(1084, 186);
            label25.Name = "label25";
            label25.Size = new Size(62, 32);
            label25.TabIndex = 7;
            label25.Text = "上代";
            // 
            // lblJoudai
            // 
            lblJoudai.BorderStyle = BorderStyle.Fixed3D;
            lblJoudai.Location = new Point(1152, 186);
            lblJoudai.Name = "lblJoudai";
            lblJoudai.Size = new Size(146, 32);
            lblJoudai.TabIndex = 8;
            lblJoudai.Text = "12,345円";
            lblJoudai.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            label26.BackColor = Color.FromArgb(64, 64, 64);
            label26.BorderStyle = BorderStyle.Fixed3D;
            label26.ForeColor = Color.White;
            label26.Location = new Point(23, 134);
            label26.Name = "label26";
            label26.Size = new Size(185, 39);
            label26.TabIndex = 9;
            label26.Text = "セット名";
            label26.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSetName
            // 
            txtSetName.BackColor = Color.FromArgb(255, 255, 192);
            txtSetName.Location = new Point(214, 130);
            txtSetName.Name = "txtSetName";
            txtSetName.Size = new Size(1124, 39);
            txtSetName.TabIndex = 1;
            txtSetName.Text = "●●●●●●●●●";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label28.ForeColor = Color.Red;
            label28.Location = new Point(1344, 88);
            label28.Name = "label28";
            label28.Size = new Size(86, 32);
            label28.TabIndex = 64;
            label28.Text = "【必須】";
            // 
            // label35
            // 
            label35.BackColor = Color.FromArgb(64, 64, 64);
            label35.BorderStyle = BorderStyle.Fixed3D;
            label35.ForeColor = Color.White;
            label35.Location = new Point(23, 183);
            label35.Name = "label35";
            label35.Size = new Size(185, 39);
            label35.TabIndex = 66;
            label35.Text = "品番";
            label35.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProductSetNo
            // 
            txtProductSetNo.Location = new Point(214, 183);
            txtProductSetNo.Name = "txtProductSetNo";
            txtProductSetNo.Size = new Size(396, 39);
            txtProductSetNo.TabIndex = 2;
            txtProductSetNo.Text = "●●●●●●●●●";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label29.ForeColor = Color.Red;
            label29.Location = new Point(1344, 137);
            label29.Name = "label29";
            label29.Size = new Size(86, 32);
            label29.TabIndex = 68;
            label29.Text = "【必須】";
            // 
            // dgvBarcodeList
            // 
            dgvBarcodeList.AllowUserToAddRows = false;
            dgvBarcodeList.AllowUserToDeleteRows = false;
            dgvBarcodeList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            dgvBarcodeList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBarcodeList.Columns.AddRange(new DataGridViewColumn[] { Barcode, ProductName, Status });
            dgvBarcodeList.Location = new Point(499, 228);
            dgvBarcodeList.Name = "dgvBarcodeList";
            dgvBarcodeList.ReadOnly = true;
            dgvBarcodeList.RowHeadersVisible = false;
            dgvBarcodeList.RowHeadersWidth = 82;
            dgvBarcodeList.Size = new Size(831, 236);
            dgvBarcodeList.TabIndex = 72;
            dgvBarcodeList.CellContentClick += dgvBarcodeList_CellContentClick;
            // 
            // Barcode
            // 
            Barcode.DataPropertyName = "Barcode";
            Barcode.HeaderText = "バーコード";
            Barcode.MinimumWidth = 10;
            Barcode.Name = "Barcode";
            Barcode.ReadOnly = true;
            Barcode.Width = 200;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "Name";
            ProductName.HeaderText = "商品名";
            ProductName.MinimumWidth = 10;
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            ProductName.Width = 250;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "登録";
            Status.MinimumWidth = 10;
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 70;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(1167, 127);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(150, 46);
            btnClear.TabIndex = 73;
            btnClear.Text = "クリア";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // txtBarcode
            // 
            txtBarcode.BackColor = Color.FromArgb(255, 255, 192);
            txtBarcode.Location = new Point(746, 183);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(200, 39);
            txtBarcode.TabIndex = 74;
            txtBarcode.TextChanged += txtBarcode_TextChanged;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            txtBarcode.Leave += txtBarcode_Leave;
            // 
            // label36
            // 
            label36.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label36.AutoSize = true;
            label36.Location = new Point(499, 190);
            label36.Name = "label36";
            label36.Size = new Size(322, 32);
            label36.TabIndex = 75;
            label36.Text = "登録した商品リストからコピーする";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(1324, 186);
            label37.Name = "label37";
            label37.Size = new Size(62, 32);
            label37.TabIndex = 76;
            label37.Text = "在庫";
            // 
            // lblStock
            // 
            lblStock.BorderStyle = BorderStyle.Fixed3D;
            lblStock.Location = new Point(1392, 186);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(87, 36);
            lblStock.TabIndex = 77;
            lblStock.Text = "1,234";
            lblStock.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblBarcodeRequired
            // 
            lblBarcodeRequired.AutoSize = true;
            lblBarcodeRequired.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            lblBarcodeRequired.ForeColor = Color.Red;
            lblBarcodeRequired.Location = new Point(952, 186);
            lblBarcodeRequired.Name = "lblBarcodeRequired";
            lblBarcodeRequired.Size = new Size(86, 32);
            lblBarcodeRequired.TabIndex = 78;
            lblBarcodeRequired.Text = "【必須】";
            // 
            // label38
            // 
            label38.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label38.AutoSize = true;
            label38.Location = new Point(45, 565);
            label38.Name = "label38";
            label38.Size = new Size(450, 32);
            label38.TabIndex = 79;
            label38.Text = "注意）フォームサイズは 1400,700 でビルドする";
            label38.Visible = false;
            // 
            // txtProductNo
            // 
            txtProductNo.Location = new Point(1644, 88);
            txtProductNo.Name = "txtProductNo";
            txtProductNo.Size = new Size(396, 39);
            txtProductNo.TabIndex = 80;
            txtProductNo.Text = "●●●●●●●●●";
            txtProductNo.Visible = false;
            // 
            // label41
            // 
            label41.BackColor = Color.FromArgb(64, 64, 64);
            label41.BorderStyle = BorderStyle.Fixed3D;
            label41.ForeColor = Color.White;
            label41.Location = new Point(1453, 88);
            label41.Name = "label41";
            label41.Size = new Size(185, 39);
            label41.TabIndex = 81;
            label41.Text = "商品番号";
            label41.TextAlign = ContentAlignment.MiddleLeft;
            label41.Visible = false;
            // 
            // frmNewProductsDetaail
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1374, 629);
            Controls.Add(txtProductNo);
            Controls.Add(label41);
            Controls.Add(label38);
            Controls.Add(lblSearch);
            Controls.Add(lblBarcodeRequired);
            Controls.Add(lblStock);
            Controls.Add(label37);
            Controls.Add(label36);
            Controls.Add(txtBarcode);
            Controls.Add(btnClear);
            Controls.Add(dgvBarcodeList);
            Controls.Add(label29);
            Controls.Add(txtProductSetNo);
            Controls.Add(label35);
            Controls.Add(label28);
            Controls.Add(txtSetName);
            Controls.Add(label26);
            Controls.Add(lblJoudai);
            Controls.Add(label25);
            Controls.Add(label23);
            Controls.Add(btnCancel);
            Controls.Add(btnRegist);
            Controls.Add(panel1);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmNewProductsDetaail";
            Text = "frmNewProductsDetaail";
            Load += frmNewProductsDetaail_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBarcodeList).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtName;
        private Panel panel1;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private TextBox txtDescription;
        private TextBox txtNote;
        private TextBox txtMaker;
        private TextBox txtCaution;
        private TextBox txtSozai;
        private TextBox txtSize;
        private TextBox txtMadeIn;
        private ComboBox lstFeature3;
        private ComboBox lstFeature2;
        private ComboBox lstFeature1;
        private TextBox txtCatchCopy;
        private Button btnRegist;
        private Button btnCancel;
        private Label label23;
        private Label label25;
        private Label lblJoudai;
        private Label label27;
        private TextBox txtSubCategory;
        private Label label24;
        private Label label26;
        private TextBox txtSetName;
        private Label label28;
        private Label label35;
        private TextBox txtProductSetNo;
        private Label label29;
        private DataGridView dgvBarcodeList;
        private Button btnClear;
        private TextBox txtBarcode;
        private Label label36;
        private Label lblSearch;
        private Label label37;
        private Label lblStock;
        private Label lblBarcodeRequired;
        private DataGridViewTextBoxColumn Barcode;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Status;
        private Label label38;
        private Label label33;
        private TextBox txtSameSeries;
        private Label label34;
        private TextBox txtSaleCondition;
        private Label label32;
        private TextBox txtInfo;
        private Label label31;
        private TextBox txtBrand;
        private Label label40;
        private TextBox txtTanto;
        private Label label30;
        private TextBox txtProductNo;
        private Label label41;
        private TextBox txtCategory1;
        private CheckBox chkTag_Original;
        private CheckBox chkTag_Sale;
        private CheckBox chkTag_Standard;
        private CheckBox chkTag_Limited;
        private CheckBox chkTag_Recommend;
        private CheckBox chkTag_New;
        private CheckBox chkTag_4F;
        private CheckBox chkTag_3F;
        private CheckBox chkTag_2F;
        private CheckBox chkTag_1F;
        private CheckBox checkBox10;
        private CheckBox checkBox9;
        private ComboBox lstCategory1;
        private TextBox txtMetaKeyword;
        private Label label16;
    }
}