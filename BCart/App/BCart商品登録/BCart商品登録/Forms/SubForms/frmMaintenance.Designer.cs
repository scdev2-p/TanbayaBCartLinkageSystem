namespace BCart商品登録.Forms.SubForms
{
    partial class frmMaintenance
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
            btnGetCategory = new Button();
            btnGetFiature = new Button();
            btnClose = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnGetCategory
            // 
            btnGetCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGetCategory.Location = new Point(135, 40);
            btnGetCategory.Name = "btnGetCategory";
            btnGetCategory.Size = new Size(397, 46);
            btnGetCategory.TabIndex = 0;
            btnGetCategory.Text = "商品カテゴリの再取得";
            btnGetCategory.UseVisualStyleBackColor = true;
            btnGetCategory.Click += btnGetCategory_Click;
            // 
            // btnGetFiature
            // 
            btnGetFiature.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGetFiature.Location = new Point(135, 118);
            btnGetFiature.Name = "btnGetFiature";
            btnGetFiature.Size = new Size(397, 46);
            btnGetFiature.TabIndex = 1;
            btnGetFiature.Text = "商品特集の再取得";
            btnGetFiature.UseVisualStyleBackColor = true;
            btnGetFiature.Click += btnGetFiature_Click;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom;
            btnClose.Location = new Point(267, 338);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 46);
            btnClose.TabIndex = 2;
            btnClose.Text = "閉じる";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Location = new Point(12, 219);
            label1.Name = "label1";
            label1.Size = new Size(646, 100);
            label1.TabIndex = 3;
            label1.Text = "※ 特徴（1F、2F、 新着など）はBカートから取り込めません。\r\n増えた時はプログラムを修正します。";
            // 
            // frmMaintenance
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(670, 396);
            Controls.Add(label1);
            Controls.Add(btnClose);
            Controls.Add(btnGetFiature);
            Controls.Add(btnGetCategory);
            Name = "frmMaintenance";
            Text = "メンテナンス";
            Load += frmMaintenance_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetCategory;
        private Button btnGetFiature;
        private Button btnClose;
        private Label label1;
    }
}