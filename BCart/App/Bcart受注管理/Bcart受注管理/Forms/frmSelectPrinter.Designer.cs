namespace Bcart受注管理.Forms
{
    partial class frmSelectPrinter
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
            lstPrinters = new ListBox();
            btnCancel = new Button();
            btnSelect = new Button();
            SuspendLayout();
            // 
            // lstPrinters
            // 
            lstPrinters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstPrinters.FormattingEnabled = true;
            lstPrinters.Location = new Point(12, 86);
            lstPrinters.Name = "lstPrinters";
            lstPrinters.Size = new Size(776, 292);
            lstPrinters.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(638, 392);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 46);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "キャンセル";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelect.Location = new Point(445, 392);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(150, 46);
            btnSelect.TabIndex = 2;
            btnSelect.Text = "選択";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // frmSelectPrinter
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSelect);
            Controls.Add(btnCancel);
            Controls.Add(lstPrinters);
            Name = "frmSelectPrinter";
            Text = "プリンター選択";
            Load += frmSelectPrinter_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lstPrinters;
        private Button btnCancel;
        private Button btnSelect;
    }
}