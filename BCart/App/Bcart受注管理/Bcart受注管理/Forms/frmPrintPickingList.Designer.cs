namespace Bcart受注管理.Forms
{
    partial class frmPrintPickingList
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
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 255, 192);
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(12, 38);
            label1.Name = "label1";
            label1.Size = new Size(776, 64);
            label1.TabIndex = 0;
            label1.Text = "印刷中";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmPrintPikkingList
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 281);
            Controls.Add(label1);
            Name = "frmPrintPikkingList";
            Text = "ピッキング一覧印刷";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
    }
}