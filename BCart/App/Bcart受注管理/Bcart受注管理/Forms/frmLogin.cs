using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bcart受注管理.AppData;
using Bcart受注管理.Forms;

namespace Bcart受注管理.Forms
{
    internal partial class frmLogin : frmBase
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 入力チェック


            // ログイン判定






            // ログインOK
            PublicData.LoginUser.UserID = "123456";
            PublicData.LoginUser.UserName = "髙木　庸一";

            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
