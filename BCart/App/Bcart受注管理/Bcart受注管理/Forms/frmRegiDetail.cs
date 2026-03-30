using Bcart受注管理.AppData;
using Bcart受注管理.Models;
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
    internal partial class frmRegiDetail : Form
    {
        private long OrderID { get; set; }
        private Consts.FormMode Mode { get; set; }

        public frmRegiDetail(long orderID, Consts.FormMode mode)
        {
            InitializeComponent();
            this.OrderID = orderID;
            this.Mode = mode;
        }

        private void frmRegiDetail_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(this.OrderID)}={this.OrderID}");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "レジ事前登録 明細";

            var topLeftHeaderCell = dataGridView1.TopLeftHeaderCell;

            using (AppData.Ds.dsBCartLinkTableAdapters.S_SearchRegiDetailTableAdapter RegiDetailTa = new AppData.Ds.dsBCartLinkTableAdapters.S_SearchRegiDetailTableAdapter())
            using (AppData.Ds.dsBCartLink.S_SearchRegiDetailDataTable RegiDetailDt = new AppData.Ds.dsBCartLink.S_SearchRegiDetailDataTable())

            {
                RegiDetailTa.Fill(RegiDetailDt, this.OrderID);
                this.bindingSource1.DataSource = RegiDetailDt;
            }
            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            this.Close();
            Program.ScLogger.Info($"end");
        }
    }
}
