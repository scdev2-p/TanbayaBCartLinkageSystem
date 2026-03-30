using Bcart受注管理.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bcart受注管理.Forms
{
    public partial class frmSelectPrinter : Form
    {
        public frmSelectPrinter()
        {
            InitializeComponent();
        }

        private void frmSelectPrinter_Load(object sender, EventArgs e)
        {
            foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                this.lstPrinters.Items.Add(s);
            }
            this.lstPrinters.SelectedItem = Settings.Default.PrinterDevice;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.lstPrinters.SelectedIndex < 0)
                return;

            Settings.Default.PrinterDevice = this.lstPrinters.SelectedItem.ToString();
            Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
