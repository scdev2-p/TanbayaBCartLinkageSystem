using BCartApi;
using BCartApi.Entity;
using BCart商品登録.Forms.SubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace BCart商品登録.Forms
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewProducts_Click(object sender, EventArgs e)
        {
            using (frmNewProducts f = new frmNewProducts())
            {
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
        }

        private void btnProductSets_Click(object sender, EventArgs e)
        {
            using (frmProductSet f = new frmProductSet())
            {
                //f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
        }

        //private void btnChangeBarcode_Click(object sender, EventArgs e)
        //{
        //    using (frmChangeBarcode f = new frmChangeBarcode())
        //    {
        //        //f.WindowState = FormWindowState.Maximized;
        //        f.ShowDialog();
        //    }
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    using (frmProductDelete f = new frmProductDelete())
        //    {
        //        //f.WindowState = FormWindowState.Maximized;
        //        f.ShowDialog();
        //    }
        //}

        private void frmMenu_Load(object sender, EventArgs e)
        {
            if (Settings.Default.BcApiRegist)
                lblConfig.Text = "Bカート連携【ON】";
            else
                lblConfig.Text = "Bカート連携【OFF】";

            if (Settings.Default.NewOnly)
            {
                //btnProductSets.Visible = false;
                btnProductsImport.Visible = false;
                btnDelTool.Visible = false;
                btnDelTool2.Visible = false;
            }


            lblVersion.Text = Settings.Default.Version;


            //GetCategory();
            //GetFiature();

        }

        private void btnDelTool_Click(object sender, EventArgs e)
        {
            using (frmProductsDeleteTool f = new frmProductsDeleteTool(true))
            {
                f.ShowDialog();
            }
        }

        private void btnDelTool2_Click(object sender, EventArgs e)
        {
            using (frmProductsDeleteTool f = new frmProductsDeleteTool(false))
            {
                f.ShowDialog();
            }
        }

        private void btnProductsImport_Click(object sender, EventArgs e)
        {
            using (frmProductsImport f = new frmProductsImport())
            {
                f.ShowDialog();
            }
        }

        private void btnRepeatRegist_Click(object sender, EventArgs e)
        {
            using (var f = new frmNewProductsDetaail(null))
            {
                f.WindowState = FormWindowState.Maximized;
                f.ShowDialog();
            }
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            using (var f = new frmMaintenance())
            {
                f.ShowDialog();
            }

        }

        private void btnChangePickingFloor_Click(object sender, EventArgs e)
        {
            using (var f = new frmChangePickingFloor())
            {
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var f = new frmImportProductsInformation())
            {
                f.ShowDialog();
            }
        }


 
    }
}
