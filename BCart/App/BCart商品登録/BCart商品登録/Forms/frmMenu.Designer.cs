namespace BCart商品登録.Forms
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
            label1 = new Label();
            btnClose = new Button();
            btnNewProducts = new Button();
            lblConfig = new Label();
            lblVersion = new Label();
            btnProductSets = new Button();
            btnDelTool = new Button();
            btnDelTool2 = new Button();
            btnProductsImport = new Button();
            btnRepeatRegist = new Button();
            btnMaintenance = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Yu Gothic UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(631, 64);
            label1.TabIndex = 0;
            label1.Text = "Bカート商品管理";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom;
            btnClose.Location = new Point(253, 528);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 46);
            btnClose.TabIndex = 1;
            btnClose.Text = "終了";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnNewProducts
            // 
            btnNewProducts.Location = new Point(54, 103);
            btnNewProducts.Name = "btnNewProducts";
            btnNewProducts.Size = new Size(258, 46);
            btnNewProducts.TabIndex = 2;
            btnNewProducts.Text = "新規商品登録";
            btnNewProducts.UseVisualStyleBackColor = true;
            btnNewProducts.Click += btnNewProducts_Click;
            // 
            // lblConfig
            // 
            lblConfig.Anchor = AnchorStyles.Bottom;
            lblConfig.BorderStyle = BorderStyle.Fixed3D;
            lblConfig.Location = new Point(100, 435);
            lblConfig.Name = "lblConfig";
            lblConfig.Size = new Size(463, 45);
            lblConfig.TabIndex = 5;
            lblConfig.Text = "label2";
            lblConfig.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Bottom;
            lblVersion.BorderStyle = BorderStyle.Fixed3D;
            lblVersion.Location = new Point(100, 480);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(463, 45);
            lblVersion.TabIndex = 6;
            lblVersion.Text = "label2";
            lblVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnProductSets
            // 
            btnProductSets.Location = new Point(54, 165);
            btnProductSets.Name = "btnProductSets";
            btnProductSets.Size = new Size(258, 46);
            btnProductSets.TabIndex = 7;
            btnProductSets.Text = "セット情報登録";
            btnProductSets.UseVisualStyleBackColor = true;
            btnProductSets.Click += btnProductSets_Click;
            // 
            // btnDelTool
            // 
            btnDelTool.Location = new Point(359, 165);
            btnDelTool.Name = "btnDelTool";
            btnDelTool.Size = new Size(258, 46);
            btnDelTool.TabIndex = 8;
            btnDelTool.Text = "商品の削除ツール";
            btnDelTool.UseVisualStyleBackColor = true;
            btnDelTool.Click += btnDelTool_Click;
            // 
            // btnDelTool2
            // 
            btnDelTool2.Location = new Point(359, 227);
            btnDelTool2.Name = "btnDelTool2";
            btnDelTool2.Size = new Size(258, 46);
            btnDelTool2.TabIndex = 9;
            btnDelTool2.Text = "セットの削除ツール";
            btnDelTool2.UseVisualStyleBackColor = true;
            btnDelTool2.Click += btnDelTool2_Click;
            // 
            // btnProductsImport
            // 
            btnProductsImport.Location = new Point(54, 227);
            btnProductsImport.Name = "btnProductsImport";
            btnProductsImport.Size = new Size(258, 46);
            btnProductsImport.TabIndex = 10;
            btnProductsImport.Text = "商品再取込";
            btnProductsImport.UseVisualStyleBackColor = true;
            btnProductsImport.Click += btnProductsImport_Click;
            // 
            // btnRepeatRegist
            // 
            btnRepeatRegist.Location = new Point(359, 103);
            btnRepeatRegist.Name = "btnRepeatRegist";
            btnRepeatRegist.Size = new Size(258, 46);
            btnRepeatRegist.TabIndex = 11;
            btnRepeatRegist.Text = "新規商品の連続登録";
            btnRepeatRegist.UseVisualStyleBackColor = true;
            btnRepeatRegist.Click += btnRepeatRegist_Click;
            // 
            // btnMaintenance
            // 
            btnMaintenance.Location = new Point(359, 292);
            btnMaintenance.Name = "btnMaintenance";
            btnMaintenance.Size = new Size(258, 46);
            btnMaintenance.TabIndex = 12;
            btnMaintenance.Text = "メンテナンス";
            btnMaintenance.UseVisualStyleBackColor = true;
            btnMaintenance.Click += btnMaintenance_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 599);
            Controls.Add(btnMaintenance);
            Controls.Add(btnRepeatRegist);
            Controls.Add(btnProductsImport);
            Controls.Add(btnDelTool2);
            Controls.Add(btnDelTool);
            Controls.Add(btnProductSets);
            Controls.Add(lblVersion);
            Controls.Add(lblConfig);
            Controls.Add(btnNewProducts);
            Controls.Add(btnClose);
            Controls.Add(label1);
            Name = "frmMenu";
            Text = "メニュー";
            Load += frmMenu_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnClose;
        private Button btnNewProducts;
        private Label lblConfig;
        private Label lblVersion;
        private Button btnProductSets;
        private Button btnDelTool;
        private Button btnDelTool2;
        private Button btnProductsImport;
        private Button btnRepeatRegist;
        private Button btnMaintenance;
    }
}