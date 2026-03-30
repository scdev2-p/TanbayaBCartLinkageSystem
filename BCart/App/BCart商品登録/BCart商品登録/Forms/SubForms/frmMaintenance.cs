using BCartApi;
using BCartApi.Entity;
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

namespace BCart商品登録.Forms.SubForms
{
    public partial class frmMaintenance : Form
    {
        public frmMaintenance()
        {
            InitializeComponent();
        }

        private void frmMaintenance_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetCategory_Click(object sender, EventArgs e)
        {

            List< cCategoryGet > categories = new List< cCategoryGet >();


            using (BCartApi.HttpApiCommon api = new BCartApi.HttpApiCommon())
            {
                int offset = 0;


                while (true)
                {

                    ApiCommandParam[] prm = { new ApiCommandParam("limit", "100"), new ApiCommandParam("offset", offset.ToString()) };

                    var retPrd = api.GetListCommand<cCategories>("categories", prm);

                    if (retPrd == null || retPrd.categories == null || retPrd.categories.Count == 0)
                    {
                        break;
                    }

                    foreach (var row in retPrd.categories)
                    {
                        categories.Add(row);
                    }

                    offset += retPrd.categories.Count;
                }

            }

            if (categories.Count == 0)
            {
                MessageBox.Show("カテゴリーが取得できませんでした。");
                return;
            }

            if (MessageBox.Show(string.Format("カテゴリー {0}件を取り込みますか?",categories.Count), "確認", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            using (AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter taQuery = new AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter())
            using (AppData.dsTnbToBCartTableAdapters.categoryTableAdapter taCate = new AppData.dsTnbToBCartTableAdapters.categoryTableAdapter())
            {
                // トランザクション処理開始
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        // カテゴリーの全削除
                        taQuery.DeleteCategory();

                        foreach (var row in categories)
                        {

                            // カテゴリーの追加（不要な項目は空文字にする）
                            taCate.Insert(
                                row.id,
                                row.name,
                                "", //row.description,
                                "", //row.rv_description,
                                row.parent_category_id,
                                "", //row.header_image,
                                "", //row.banner_image,
                                "", //row.menu_image,
                                "", //row.meta_title,
                                "", //row.meta_keywords,
                                "", //row.meta_description,
                                0, //row.priority,
                                (byte)row.flag);
                        }

                        ts.Complete();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("カテゴリーの取込でエラーが発生しました。");
                        return;
                    }
                }
            }

            MessageBox.Show("カテゴリーをBカートから取り込みました。");
        }


        private void btnGetFiature_Click(object sender, EventArgs e)
        {
            List<cProductFeatureGet> features = new List<cProductFeatureGet>();


            using (BCartApi.HttpApiCommon api = new BCartApi.HttpApiCommon())
            {
                int offset = 0;


                while (true)
                {

                    ApiCommandParam[] prm = { new ApiCommandParam("limit", "100"), new ApiCommandParam("offset", offset.ToString()) };

                    var retPrd = api.GetListCommand<cProductFeatures>("product_features", prm);

                    if (retPrd == null || retPrd.product_features == null || retPrd.product_features.Count == 0)
                    {
                        break;
                    }

                    foreach (var row in retPrd.product_features)
                    {
                        features.Add(row);
                    }

                    offset += retPrd.product_features.Count;
                }

            }

            if (features.Count == 0)
            {
                MessageBox.Show("特集が取得できませんでした。");
                return;
            }

            if (MessageBox.Show(string.Format("特集 {0}件を取り込みますか?", features.Count), "確認", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            using (AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter taQuery = new AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter())
            using (AppData.dsTnbToBCartTableAdapters.product_featuresTableAdapter taCate = new AppData.dsTnbToBCartTableAdapters.product_featuresTableAdapter())
            {
                // トランザクション処理開始
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        // カテゴリーの全削除
                        taQuery.DeleteFroductFeatures();

                        foreach (var row in features)
                        {

                            // カテゴリーの追加（不要な項目は空文字にする）
                            taCate.Insert(
                                row.id,
                                row.name,
                                "", //row.description,
                                "", //row.rv_description,
                                "", //row.header_image,
                                "", //row.banner_image,
                                "", //row.menu_image,
                                "", //row.meta_title,
                                "", //row.meta_keywords,
                                ""); //row.meta_description,
                        }

                        ts.Complete();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("特集の取込でエラーが発生しました。");
                        return;
                    }
                }
            }

            MessageBox.Show("特集をBカートから取り込みました。");
        }
    }
}
