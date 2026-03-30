using BCart商品登録.AppData;
using BCart商品登録.Task;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCart商品登録.Forms.SubForms
{
    public partial class frmCheckBcBarcode : Form
    {
        public frmCheckBcBarcode(string barcode)
        {
            InitializeComponent();

            ExistOtherBarcode = false;
            lblBarcode.Text = barcode;

            // バーコードからBカートに登録済の商品を取得する。
            using (bcCheckBcProducts bc = new bcCheckBcProducts())
            {
                dsTnbToBCart.bc商品バーコード登録リストDataTable productsList = bc.getBcProductByBarcode(barcode);
                this.dgvBarcodeList.AutoGenerateColumns = false;
                this.dgvBarcodeList.DataSource = productsList;

                if (productsList != null && productsList.Count > 0)
                {
                    ExistOtherBarcode = true;
                }
            }
        }

        public bool ExistOtherBarcode {  get; set; }

        private void frmCheckBcBarcode_Load(object sender, EventArgs e)
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
