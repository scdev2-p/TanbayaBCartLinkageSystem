using BCartApi;
using BCartApi.Entity;
using BCart商品登録.AppData;
using BCart商品登録.Forms.SubForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace BCart商品登録.Forms
{
    public partial class frmNewProductsDetaail : Form
    {

        private const string c_imageUrl = "";

        private const int ProductCustom1_ID = 4;    // 基本カスタム項目1のID  ブランド
        private const int ProductCustom2_ID = 5;    // 基本カスタム項目２のID  メーカー
        private const int ProductCustom3_ID = 6;    // 基本カスタム項目3のID  分類
        private const int ProductCustom4_ID = 11;    // 基本カスタム項目4のID  備考
        private const int ProductCustom5_ID = 12;    // 基本カスタム項目4のID  担当
        private const int ProductCustom6_ID = 13;    // 基本カスタム項目4のID  上代変更
        private const int ProductCustom7_ID = 14;    // 基本カスタム項目4のID  お知らせ
        private const int ProductCustom8_ID = 15;    // 基本カスタム項目4のID  販売条件
        private const int ProductCustom9_ID = 16;    // 基本カスタム項目4のID  同シリーズはこちら→
        private const int ProductCustom10_ID = 17;    // 基本カスタム項目4のID  おすすめブランド

        //private Dictionary<int, string> featureList = new Dictionary<int, string>() {
        //    { 0, "" },
        //    { 1, "在庫処分SALE" },
        //    { 2, "Winter sale" },
        //    { 3, "BREAK TIME COFFEE【コーヒー関連グッズ】" },
        //    { 4, "お茶関連グッズ" },
        //    { 5, "レース＆ファブリック" },
        //    { 6, "花柄ポーチ" },
        //    { 7, "日本製商品" },
        //    { 8, "印傳屋 上原勇七" },
        //    { 9, "松尾ミユキ" },
        //    { 10, "西淑" },
        //    { 11, "マツモトヨーコ" },
        //    { 12, "ナタリー・レテ" },
        //    { 13, "エコバッグ" }
        //};

        //private class cRegiststateState
        //{
        //    public string Barcode { get; set; } = "";
        //    public string Status { get; set; } = "";
        //    public string bcProductsID { get; set; } = "";
        //}

        private dsTnbToBCart.bc商品登録ステータスDataTable lst登録ステータス = new dsTnbToBCart.bc商品登録ステータスDataTable();
        private List<dsTnbToBCart.S_新規商品差分抽出2Row>? lst登録商品選択リスト;        // 一覧から呼び出されたときのリストデータ
        private int listIndex = 0;

        private dsTnbToBCart.tnb商品情報Row? currentTnb商品情報;


        public frmNewProductsDetaail(List<dsTnbToBCart.S_新規商品差分抽出2Row>? lstProducts)
        {
            InitializeComponent();

            //// カテゴリのリストをセット
            lstCategory1.ValueMember = "key";
            lstCategory1.DisplayMember = "value";
            lstCategory1.DataSource = getCategoryList().ToList();


            // 特集
            lstFeature1.ValueMember = "Key";
            lstFeature1.DisplayMember = "Value";
            lstFeature1.DataSource = getFeaturesList().ToList();
            lstFeature2.ValueMember = "Key";
            lstFeature2.DisplayMember = "Value";
            lstFeature2.DataSource = getFeaturesList().ToList();
            lstFeature3.ValueMember = "Key";
            lstFeature3.DisplayMember = "Value";
            lstFeature3.DataSource = getFeaturesList().ToList();

            lblSearch.Visible = false;


            listIndex = 0;

            lst登録商品選択リスト = null;
            if (lstProducts != null)
            {
                lst登録商品選択リスト = lstProducts;
                foreach (var row in lstProducts)
                {
                    var p = lst登録ステータス.Newbc商品登録ステータスRow();
                    p.Barcode = row.バーコード;
                    p.Status = "";
                    p.bcProductsID = "";
                    p.Name = row.商品名;
                    lst登録ステータス.Addbc商品登録ステータスRow(p);
                }

                // バーコード入力不可
                txtBarcode.ReadOnly = true;
                txtBarcode.BackColor = SystemColors.Control;
                txtBarcode.Text = lstProducts[listIndex].バーコード;
                lblBarcodeRequired.Visible = false;

                // 現在のバーコードの商品マスタを取得しCurrentにセット
                getTnb商品情報toCurrent(lstProducts[listIndex].バーコード);
            }
            else
            {
                // バーコード入力可
                txtBarcode.ReadOnly = false;
                txtBarcode.BackColor = Color.FromArgb(255, 255, 192);
                lblBarcodeRequired.Visible = true;
            }

            dgvBarcodeList.AutoGenerateColumns = false;
            dgvBarcodeList.DataSource = lst登録ステータス;

            Barcode.Width = 100;
            ProductName.Width = 250;
            Status.Width = 70;

            initProductsData();

        }

        private void frmNewProductsDetaail_Load(object sender, EventArgs e)
        {


        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 終了
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnRegist_Click(object sender, EventArgs e)
        {

            // 入力チェック


            // 必須チェックをまとめてやる
            StringBuilder sb = new StringBuilder();
            string categoryName = "";

            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                sb.Append("バーコードは必須です。\n");
            }

            if (currentTnb商品情報 == null)
            {
                sb.Append("バーコードが商品マスタにありません。\n");
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                sb.Append("商品名は必須です。\n");
            }

            if (string.IsNullOrEmpty(txtSetName.Text))
            {
                sb.Append("セット名は必須です。\n");
            }

            if (string.IsNullOrEmpty(txtCategory1.Text))
            {
                sb.Append("メインカテゴリは必須です。\n");
            }
            else if (!int.TryParse(txtCategory1.Text, out int n))
            {
                sb.Append("メインカテゴリは数字で入力してください。\n");
            }
            else if (!checkCategory(txtCategory1.Text, out categoryName))
            {
                sb.Append("メインカテゴリが不明なカテゴリです。\n");
            }

            // 生産地、サイズ、素材、メーカー、説明は必須
            //if (string.IsNullOrEmpty(txtMadeIn.Text))
            //{
            //    sb.Append("生産地は必須です。\n");
            //}
            //if (string.IsNullOrEmpty(txtSize.Text))
            //{
            //    sb.Append("サイズは必須です。\n");
            //}
            //if (string.IsNullOrEmpty(txtSozai.Text))
            //{
            //    sb.Append("素材は必須です。\n");
            //}
            // メーカーは必須
            if (string.IsNullOrEmpty(txtMaker.Text))
            {
                sb.Append("メーカーは必須です。\n");
            }
            //if (string.IsNullOrEmpty(txtDescription.Text))
            //{
            //    sb.Append("説明は必須です。\n");
            //}


            // その他チェック

            Regex reg = new Regex(@"^[\d,]+$");
            if (!string.IsNullOrEmpty(txtSubCategory.Text) && !reg.IsMatch(txtSubCategory.Text))
            {
                sb.Append("サブカテゴリに数字とカンマ(,)以外の文字があります。");
                return;
            }
            if (!string.IsNullOrEmpty(txtSubCategory.Text))
            {
                if (!checkSubCategory(txtSubCategory.Text))
                {
                    sb.Append("サブカテゴリ[{0}]は不明なカテゴリです。");
                    return;
                }
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
                return;
            }



            // 編集モードであればバーコードのチェック
            if (!txtBarcode.ReadOnly)
            {
                // Bカートバーコード重複チェック
                checkBcBarcodeProducts(txtBarcode.Text);
            }

            // --------------------------------------------------------
            // Bカートへ商品を登録する
            cProductsNewDetail ps = new cProductsNewDetail();
            ps.name = txtName.Text;
            ps.category_id = int.Parse(txtCategory1.Text);
            ps.sub_category_id = txtSubCategory.Text;
            ps.feature_id1 = lstFeature1.SelectedIndex <= 0 ? null : int.Parse(lstFeature1.SelectedValue.ToString());
            ps.feature_id2 = lstFeature2.SelectedIndex <= 0 ? null : int.Parse(lstFeature2.SelectedValue.ToString());
            ps.feature_id3 = lstFeature3.SelectedIndex <= 0 ? null : int.Parse(lstFeature3.SelectedValue.ToString());
            List<string> tmpProductStatus = new List<string>();
            if (chkTag_1F.Checked)
                tmpProductStatus.Add("1f");
            if (chkTag_2F.Checked)
                tmpProductStatus.Add("2f");
            if (chkTag_3F.Checked)
                tmpProductStatus.Add("3f");
            if (chkTag_4F.Checked)
                tmpProductStatus.Add("4f");
            if (chkTag_New.Checked)
                tmpProductStatus.Add("new");
            if (chkTag_Recommend.Checked)
                tmpProductStatus.Add("recommend");
            if (chkTag_Limited.Checked)
                tmpProductStatus.Add("limited");
            if (chkTag_Standard.Checked)
                tmpProductStatus.Add("standard");
            if (chkTag_Sale.Checked)
                tmpProductStatus.Add("sale");
            if (chkTag_Original.Checked)
                tmpProductStatus.Add("original");
            ps.tag = string.Join(',', tmpProductStatus.ToArray());
            ps.catch_copy = txtCatchCopy.Text;
            ps.made_in = txtMadeIn.Text;
            ps.size = txtSize.Text;
            ps.sozai = txtSozai.Text;
            ps.caution = txtCaution.Text;
            ps.customs = new List<cCustom>() { new cCustom() {field_id=ProductCustom2_ID, value=txtMaker.Text },
                                               new cCustom() {field_id=ProductCustom4_ID, value=txtNote.Text },
                                               new cCustom() {field_id=ProductCustom5_ID, value=txtTanto.Text },
                                               new cCustom() {field_id=ProductCustom7_ID, value=txtInfo.Text },
                                               new cCustom() {field_id=ProductCustom8_ID, value=txtSaleCondition.Text },
                                               new cCustom() {field_id=ProductCustom9_ID, value=txtSameSeries.Text } };
            ps.description = txtDescription.Text;
            ps.sub_images = null;

            // 商品非表示グループ
            List<string> tmpVf = new List<string>();
            // 海外禁止
            if (currentTnb商品情報 != null && !currentTnb商品情報.Is海外禁止Null())
                tmpVf.Add("2");
            // NET販売NG
            if (currentTnb商品情報 != null && currentTnb商品情報.WEB販売拒否フラグ)
                tmpVf.Add("6");
            ps.view_group_filter = string.Join(',', tmpVf.ToArray());

            ps.updated_at = DateTime.Now;

            ps.meta_keywords = txtMetaKeyword.Text;

            // 以下は固定部分
            // customは不要
            ps.view_pattern = 0;
            ps.priority = 0;
            ps.flag = "非表示";
            ps.updated_at = DateTime.Now;

            long bcProductID;

            //if (false)        // debug
            //{
            // Bカートへ商品基本情報とセット情報を登録し、DBの登録済商品に登録する
            using (Task.bcNewProductsDetailRegist t = new BCart商品登録.Task.bcNewProductsDetailRegist())
            {
                bcProductID = t.RegistNew(currentTnb商品情報, ps, txtSetName.Text, txtProductSetNo.Text);
                if (bcProductID < 0)
                {
                    MessageBox.Show("商品の登録でエラーが発生しました。");
                    return;
                }
            }

            //}
            //bcProductID = 200001 + lst登録ステータス.Count;         //debug

            if (lst登録商品選択リスト != null)
            {

                // 商品一覧からの登録の場合、次の商品へ

                // ステータスを済にする
                lst登録ステータス[listIndex].Status = "済";
                lst登録ステータス[listIndex].bcProductsID = bcProductID.ToString();
                this.Update();

                //次の商品へ
                listIndex++;

                // 終了判定
                if (listIndex >= lst登録商品選択リスト.Count)
                {
                    MessageBox.Show("全ての商品登録が終了しました。");

                    // 終了
                    this.DialogResult = DialogResult.OK;
                    return;
                }

                // 現在のバーコードの商品マスタを取得しCurrentにセット
                getTnb商品情報toCurrent(lst登録商品選択リスト[listIndex].バーコード);
                setCurrentTnb商品();

                // 商品名
                txtName.Text = currentTnb商品情報 != null ? currentTnb商品情報.商品名 : "";
                txtSetName.Text = currentTnb商品情報 != null ? currentTnb商品情報.商品名 : "";
                txtProductSetNo.Text = "";

                chkTag_New.Checked = true;      // 新着のみチェック
                chkTag_Recommend.Checked = false;
                chkTag_Limited.Checked = false;
                chkTag_Standard.Checked = false;
                chkTag_Sale.Checked = false;
                chkTag_Original.Checked = false;


                ////////////////////////////////////////
                // その他の入力項目はそのまま残す
                ////////////////////////////////////////

            }
            else
            {
                // 商品連続登録の場合

                // ステータスを済にする
                var p = lst登録ステータス.Newbc商品登録ステータスRow();
                p.Barcode = txtBarcode.Text;
                p.Status = "済";
                p.bcProductsID = bcProductID.ToString();
                p.Name = txtName.Text;
                lst登録ステータス.Addbc商品登録ステータスRow(p);

                //次の商品へ
                listIndex++;

                // バーコード関連をリセット
                txtBarcode.Text = "";
                lblJoudai.Text = "";
                lblStock.Text = "";

                // フロアをリセット

                chkTag_1F.Checked = false;
                chkTag_2F.Checked = false;
                chkTag_3F.Checked = false;
                chkTag_4F.Checked = false;


                ////////////////////////////////////////
                // その他の入力項目はそのまま残す
                ////////////////////////////////////////

            }

            // 登録ステータスリストの設定
            dgvBarcodeList.AutoGenerateColumns = false;
            dgvBarcodeList.DataSource = lst登録ステータス;

        }


        private void initProductsData()
        {
            // FormLoad時
            // クリアボタンクリック時
            // のみ

            if (lst登録商品選択リスト != null)
            {
                // 商品一覧からの登録の場合

                txtBarcode.Text = currentTnb商品情報 != null ? currentTnb商品情報.バーコード : "";

                // 商品名
                txtName.Text = currentTnb商品情報 != null ? currentTnb商品情報.商品名 : "";
                txtSetName.Text = currentTnb商品情報 != null ? currentTnb商品情報.商品名 : "";
                txtProductSetNo.Text = "";

                lblJoudai.Text = string.Format("{0:#,0}円", currentTnb商品情報 != null ? currentTnb商品情報.上代単価 : 0);
                lblStock.Text = string.Format("{0:#,0}", currentTnb商品情報 != null && !currentTnb商品情報.Is数量Null() ? currentTnb商品情報.数量 : 0);
            }
            else
            {
                //商品連続登録の場合

                txtBarcode.Text = "";

                // 商品名
                txtName.Text = "";
                txtProductNo.Text = "";
                txtSetName.Text = "";
                txtProductSetNo.Text = "";

                lblJoudai.Text = "";
                lblStock.Text = "";

            }


            // カテゴリ
            txtCategory1.Text = "";
            lstCategory1.SelectedIndex = -1;
            txtSubCategory.Text = "";

            // 特集をリセット
            lstFeature1.SelectedIndex = -1;
            lstFeature2.SelectedIndex = -1;
            lstFeature3.SelectedIndex = -1;


            // 商品特徴
            chkTag_1F.Checked = false;
            chkTag_2F.Checked = false;
            chkTag_3F.Checked = false;
            chkTag_4F.Checked = false;
            if (lst登録商品選択リスト != null)
            {
                // 商品一覧からの登録の場合、商品マスタのフロアをセット

                if (currentTnb商品情報 != null)
                {
                    switch (currentTnb商品情報.フロアコード)
                    {
                        case "3":
                            chkTag_1F.Checked = true;
                            break;
                        case "5":
                            chkTag_2F.Checked = true;
                            break;
                        case "2":
                        case "7":
                        case "8":
                            chkTag_3F.Checked = true;
                            break;
                        case "1":
                            chkTag_4F.Checked = true; ;
                            break;
                    }
                }
            }
            chkTag_New.Checked = true;      // 新着のみチェック
            chkTag_Recommend.Checked = false;
            chkTag_Limited.Checked = false;
            chkTag_Standard.Checked = false;
            chkTag_Sale.Checked = false;
            chkTag_Original.Checked = false;

            // キャッチコピー
            txtCatchCopy.Text = "";

            // 生産地
            txtMadeIn.Text = "";

            // サイズ
            txtSize.Text = "";

            // 素材
            txtSozai.Text = "";

            // 注意事項
            txtCaution.Text = "";

            // メーカー
            txtMaker.Text = "";

            // 備考
            txtNote.Text = "";

            // 担当
            txtTanto.Text = "";

            // お知らせ
            txtInfo.Text = "";

            // 販売条件
            txtSaleCondition.Text = "";

            // 同シリーズはこちら→
            txtSameSeries.Text = "";

            // 説明
            txtDescription.Text = "";

            // メタキーワード
            txtMetaKeyword.Text = "";

        }


        ////////////////////////////////////////////////////
        // カテゴリのリスト用

        private Dictionary<int, string> getCategoryList()
        {
            Dictionary<int, string> categoryList = new Dictionary<int, string>();
            int level = 0;

            using (AppData.dsTnbToBCartTableAdapters.categoryTableAdapter ta = new AppData.dsTnbToBCartTableAdapters.categoryTableAdapter())
            using (dsTnbToBCart.categoryDataTable dt = new dsTnbToBCart.categoryDataTable())
            {
                ta.FillByParent(dt);
                foreach (var row in dt)
                {
                    categoryList.Add(row.id, string.Format("【{0}】{1}", row.id, row.name));

                    // 親カテゴリのみにする 2024/12/18
                    getChildCategory(categoryList, ta, row.id, level + 1);
                }
            }

            return categoryList;
        }

        private bool checkCategory(string categoryID, out string categoryName)
        {
            if(string.IsNullOrEmpty(categoryID))
            {
                categoryName = "";
                return false;
            }
            int cid;
            if(!int.TryParse(categoryID, out cid))
            {
                categoryName = "";
                return false;
            }

            using (AppData.dsTnbToBCartTableAdapters.categoryTableAdapter ta = new AppData.dsTnbToBCartTableAdapters.categoryTableAdapter())
            using (dsTnbToBCart.categoryDataTable dt = new dsTnbToBCart.categoryDataTable())
            {
                ta.FillByID(dt, cid);
                if (dt.Count == 0)
                {
                    categoryName = "";
                    return false;
                }
                else
                {
                    categoryName = dt[0].name;
                    return true;
                }
            }

            //using (Task.bcCategory bc = new Task.bcCategory())
            //{
            //    return bc.getCategory(categoryID.ToString(), out categoryName);
            //}

        }
        private bool checkMaker(string makerCD, out string makerName)
        {
            using (AppData.dsTnbToBCartTableAdapters.M_仕入先TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.M_仕入先TableAdapter())
            using (dsTnbToBCart.M_仕入先DataTable dt = new dsTnbToBCart.M_仕入先DataTable())
            {
                ta.FillByCD(dt, makerCD);
                if (dt.Count == 0)
                {
                    makerName = "";
                    return false;
                }
                else
                {
                    makerName = dt[0].仕入先名;
                    return true;
                }
            }
        }

        private bool checkStaff(string staffCD, out string staffName)
        {
            using (AppData.dsTnbToBCartTableAdapters.M_社員TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.M_社員TableAdapter())
            using (dsTnbToBCart.M_社員DataTable dt = new dsTnbToBCart.M_社員DataTable())
            {
                ta.FillByCD(dt, staffCD);
                if (dt.Count == 0)
                {
                    staffName = "";
                    return false;
                }
                else
                {
                    staffName = dt[0].社員名;
                    return true;
                }
            }
        }


        private void getChildCategory(Dictionary<int, string> categoryList, AppData.dsTnbToBCartTableAdapters.categoryTableAdapter ta, int parentID, int level)
        {
            using (dsTnbToBCart.categoryDataTable dt = new dsTnbToBCart.categoryDataTable())
            {

                ta.FillByChild(dt, parentID);
                foreach (dsTnbToBCart.categoryRow row in dt)
                {
                    categoryList.Add(row.id, "".PadLeft(level, '　') + string.Format("【{0}】{1}", row.id, row.name));
                    getChildCategory(categoryList, ta, row.id, level + 1);
                }
            }
        }


        private bool checkSubCategory(string subCategory)
        {
            using (AppData.dsTnbToBCartTableAdapters.categoryTableAdapter ta = new AppData.dsTnbToBCartTableAdapters.categoryTableAdapter())
            using (dsTnbToBCart.categoryDataTable dt = new dsTnbToBCart.categoryDataTable())
            {
                foreach (var id in txtSubCategory.Text.Split(','))
                {
                    ta.FillByID(dt, int.Parse(id));
                    if (dt.Count == 0)
                    {
                        MessageBox.Show(string.Format("サブカテゴリの【{0}】は不明なカテゴリです。", id));
                        return false;
                    }
                }
            }

            return true;
        }


        // 特集のリスト
        private Dictionary<int, string> getFeaturesList()
        {
            Dictionary<int, string> FeaturesList = new Dictionary<int, string>();
            int level = 0;

            using (AppData.dsTnbToBCartTableAdapters.product_featuresTableAdapter ta = new AppData.dsTnbToBCartTableAdapters.product_featuresTableAdapter())
            using (dsTnbToBCart.product_featuresDataTable dt = new dsTnbToBCart.product_featuresDataTable())
            {
                FeaturesList.Add(0, "");     // 最初の空行

                ta.Fill(dt);
                foreach (var row in dt)
                {
                    FeaturesList.Add(row.id, string.Format("【{0}】{1}", row.id, row.name));
                }
            }

            return FeaturesList;
        }


        ////////////////////////////////////////////////////


        /// <summary>
        /// Bカートの商品情報を取得して入力項目にコピーする
        /// </summary>
        /// <param name="productID"></param>
        private void copyBcProducts(string productID)
        {

            using (BCartApi.HttpApiCommon api = new BCartApi.HttpApiCommon())
            {
                cProduct retPrd = api.GetCommandId<cProduct>("products", productID);

                if (retPrd == null || retPrd.product == null)
                {
                    MessageBox.Show("Error:Bカートの商品情報を取得できませんでした。");
                    return;
                }

                txtName.Text = retPrd.product.name;     // 商品名
                txtCategory1.Text = retPrd.product.category_id.ToString();  // メインカテゴリー
                //lstCategory1.SelectedValue = retPrd.product.category_id;

                txtSubCategory.Text = retPrd.product.sub_category_id;       // サブカテゴリー

                lstFeature1.SelectedIndex = -1;
                lstFeature2.SelectedIndex = -1;
                lstFeature3.SelectedIndex = -1;
                if (retPrd.product.feature_id1 != null)
                    lstFeature1.SelectedValue = retPrd.product.feature_id1;     // 特集1
                if (retPrd.product.feature_id2 != null)
                    lstFeature2.SelectedValue = retPrd.product.feature_id2;     // 特集2
                if (retPrd.product.feature_id3 != null)
                    lstFeature3.SelectedValue = retPrd.product.feature_id3;     // 特集3

                // 商品特徴
                chkTag_1F.Checked = false;
                chkTag_2F.Checked = false;
                chkTag_3F.Checked = false;
                chkTag_4F.Checked = false;
                chkTag_New.Checked = false;
                chkTag_Recommend.Checked = false;
                chkTag_Limited.Checked = false;
                chkTag_Standard.Checked = false;
                chkTag_Sale.Checked = false;
                chkTag_Original.Checked = false;
                foreach (var t in retPrd.product.tag.Split(','))
                {
                    switch (t)
                    {
                        case "1f":
                            chkTag_1F.Checked = true; break;
                        case "2f":
                            chkTag_2F.Checked = true; break;
                        case "3f":
                            chkTag_3F.Checked = true; break;
                        case "4f":
                            chkTag_4F.Checked = true; break;
                        case "new":
                            chkTag_New.Checked = true; break;
                        case "recommend":
                            chkTag_Recommend.Checked = true; break;
                        case "limited":
                            chkTag_Limited.Checked = true; break;
                        case "standard":
                            chkTag_Standard.Checked = true; break;
                        case "sale":
                            chkTag_Sale.Checked = true; break;
                        case "original":
                            chkTag_Original.Checked = true; break;

                    }
                }

                txtCatchCopy.Text = retPrd.product.catch_copy;  // キャッチコピー
                txtMadeIn.Text = retPrd.product.made_in;        // 生産地
                txtSize.Text = retPrd.product.size;             // サイズ
                txtSozai.Text = retPrd.product.sozai;           // 素材
                txtCaution.Text = retPrd.product.caution;       // 注意事項

                // カスタム項目
                foreach (var c in retPrd.product.customs)
                {
                    // メーカー
                    if (c.field_id == ProductCustom2_ID)
                    {
                        txtMaker.Text = c.value;
                    }

                    // 備考
                    if (c.field_id == ProductCustom4_ID)
                    {
                        txtNote.Text = c.value;
                    }
                    // 担当
                    if (c.field_id == ProductCustom5_ID)
                    {
                        txtTanto.Text = c.value;
                    }
                    // お知らせ
                    if (c.field_id == ProductCustom7_ID)
                    {
                        txtInfo.Text = c.value;
                    }
                    // 販売条件
                    if (c.field_id == ProductCustom8_ID)
                    {
                        txtSaleCondition.Text = c.value;
                    }
                    // 同シリーズはこちら→
                    if (c.field_id == ProductCustom9_ID)
                    {
                        txtSameSeries.Text = c.value;
                    }
                }

                txtDescription.Text = retPrd.product.description;       // 説明

                txtMetaKeyword.Text = retPrd.product.meta_keywords;

                ApiCommandParam[] prm = { new ApiCommandParam("product_id", productID) };
                cProductSetNewResponse retSet = api.GetListCommand<cProductSetNewResponse>("product_sets", prm);
                if (retSet != null && retSet.product_sets != null && retSet.product_sets.Count > 0)
                {
                    txtSetName.Text = retSet.product_sets[0].name;              // セット名
                    txtProductSetNo.Text = retSet.product_sets[0].product_no;   // 品番
                }

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            initProductsData();
        }

        private void txtBarcode_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
                return;

            setProductsInfoByBarcode();

            checkBcBarcodeProducts(txtBarcode.Text);
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length != 13)
                return;

            //setProductsInfoByBarcode();

            //checkBcBarcodeProducts(txtBarcode.Text);
        }

        /// <summary>
        /// 現在のバーコードの商品マスタを取得しCurrentにセット
        /// </summary>
        /// <param name="barcode"></param>
        private void getTnb商品情報toCurrent(string barcode)
        {
            Cursor.Current = Cursors.WaitCursor;
            currentTnb商品情報 = null;
            using (AppData.dsTnbToBCartTableAdapters.tnb商品情報TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.tnb商品情報TableAdapter())
            using (dsTnbToBCart.tnb商品情報DataTable dt = new dsTnbToBCart.tnb商品情報DataTable())
            {
                ta.Fill(dt, barcode);
                Cursor.Current = Cursors.Default;
                if (dt.Count == 0)
                {
                    return;
                }
                currentTnb商品情報 = dt[0];
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            // 編集モードでEnterでバーコードチェック
            if (!this.txtBarcode.ReadOnly && e.KeyCode == Keys.Enter)
            {
                if (setProductsInfoByBarcode())
                {
                    txtCategory1.Focus();
                }
            }
        }

        private bool setProductsInfoByBarcode()
        {
            if (string.IsNullOrEmpty(txtBarcode.Text))
                return false;

            // 全角半角変換
            txtBarcode.Text = Strings.StrConv(txtBarcode.Text, Microsoft.VisualBasic.VbStrConv.Narrow, 0x411);

            // 現在のバーコードの商品マスタを取得しCurrentにセット
            getTnb商品情報toCurrent(txtBarcode.Text);
            if (currentTnb商品情報 == null)
            {
                MessageBox.Show("バーコードが商品マスタにありません。");
                return false;
            }

            setCurrentTnb商品();

            // メーカー製品情報をセット
            //setMakerProductInfo(txtBarcode.Text);

            return true;
        }


        /// <summary>
        /// 商品マスタの情報を表示  上代、在庫、フロア
        /// </summary>
        private void setCurrentTnb商品()
        {
            txtName.Text = currentTnb商品情報.商品名;
            txtSetName.Text = currentTnb商品情報.商品名;
            lblJoudai.Text = string.Format("{0:#,0}円", currentTnb商品情報 != null ? currentTnb商品情報.上代単価 : 0);
            lblStock.Text = string.Format("{0:#,0}", currentTnb商品情報 != null && !currentTnb商品情報.Is数量Null() ? currentTnb商品情報.数量 : 0);

            // 商品特徴(フロアのみ再セット）
            chkTag_1F.Checked = false;
            chkTag_2F.Checked = false;
            chkTag_3F.Checked = false;
            chkTag_4F.Checked = false;
            if (currentTnb商品情報 != null)
            {
                switch (currentTnb商品情報.フロアコード)
                {
                    case "3":
                        chkTag_1F.Checked = true;
                        break;
                    case "5":
                        chkTag_2F.Checked = true;
                        break;
                    case "2":
                    case "7":
                    case "8":
                        chkTag_3F.Checked = true;
                        break;
                    case "1":
                        chkTag_4F.Checked = true; ;
                        break;
                }
            }
        }

        /// <summary>
        /// Bカートの商品情報よりバーコードがあるか取得
        /// </summary>
        /// <param name="barcode"></param>
        private void checkBcBarcodeProducts(string barcode)
        {
            // 検索中表示
            lblSearch.Visible = true;
            lblSearch.Update();

            // バーコードチェック画面
            using (frmCheckBcBarcode f = new frmCheckBcBarcode(barcode))
            {
                // 検索中非表示
                lblSearch.Visible = false;
                lblSearch.Update();

                // バーコードが使われていない場合は終了
                if (!f.ExistOtherBarcode)
                    return;

                // バーコードが使われている場合は画面表示(確認のみ)
                f.ShowDialog();
            }

        }

        private void dgvBarcodeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridView dgv = (DataGridView)sender;

            // クリックされた行にバインドされているRowデータを取得
            dsTnbToBCart.bc商品登録ステータスRow dbRow = (dsTnbToBCart.bc商品登録ステータスRow)((System.Data.DataRowView)dgv.Rows[e.RowIndex].DataBoundItem).Row;

            if (dbRow.Status == "済" && !string.IsNullOrEmpty(dbRow.bcProductsID))
            {
                // Bカートに登録済であれば商品情報を取得してコピーする
                copyBcProducts(dbRow.bcProductsID);
            }

        }

        //private void chkPrentCategory_CheckedChanged(object sender, EventArgs e)
        //{
        //    // カテゴリリストの再セット
        //    lstCategory1.DataSource = getCategoryList().ToList();
        //    lstCategory1.SelectedIndex = -1;
        //}


        /// <summary>
        /// メーカー商品情報をセットする
        /// </summary>
        /// <param name="barcode"></param>
        private void setMakerProductInfo(string barcode)
        {
            using (AppData.dsTnbToBCartTableAdapters.dt_メーカー商品情報TableAdapter ta = new AppData.dsTnbToBCartTableAdapters.dt_メーカー商品情報TableAdapter())
            using (dsTnbToBCart.dt_メーカー商品情報DataTable dt = new dsTnbToBCart.dt_メーカー商品情報DataTable())
            using (AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter qt = new AppData.dsTnbToBCartTableAdapters.QueriesTableAdapter())
            {
                // メーカー名の取得
                string maker = (string)qt.GetMakerByBarcode(barcode);
                txtMaker.Text = maker;

                // メーカー商品情報の取得
                ta.FillByBarcode(dt, barcode);
                if (dt.Count > 0)
                {
                    var row = dt[0];
                    //if (!row.IsメーカーNull())
                    //    txtMaker.Text = row.メーカー;

                    if (!row.Is商品名Null())
                        txtName.Text = row.商品名;
                    //if (!row.Is商品番号Null())
                    //    txtProductNo.Text = row.商品番号;

                    if (!row.Is商品セット名Null())
                        txtSetName.Text = row.商品セット名;
                    if (!row.Is品番Null())
                        txtProductSetNo.Text = row.品番;

                    if (!row.IsブランドNull())
                        txtBrand.Text = row.ブランド;

                    if (!row.Is生産地Null())
                        txtMadeIn.Text = row.生産地;
                    if (!row.IsサイズNull())
                        txtSize.Text = row.サイズ;
                    if (!row.Is素材Null())
                        txtSozai.Text = row.素材;

                    if (!row.Is注意事項Null())
                        txtCaution.Text = row.注意事項;

                    if (!row.Is説明Null())
                        txtDescription.Text = row.説明;


                }
            }
        }

        private bool nonNumberEntered = false;
        private void txtCategory1_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
        private void txtCategory1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void txtCategory1_Leave(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(txtCategory1.Text))
            //{
            //    lblCategoryName.Text = string.Empty;
            //    return;
            //}

            //string categoryName;
            //if (!checkCategory(int.Parse(txtCategory1.Text), out categoryName))
            //{
            //    lblCategoryName.Text = "不明なカテゴリーです";
            //    return;
            //}
            //lblCategoryName.Text = categoryName;

        }

        private void txtCategory1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCategory1.Text))
            {
                string categoryName;
                if (!checkCategory(txtCategory1.Text, out categoryName))
                {
                    lstCategory1.SelectedValue = -1;
                    return;
                }
                lstCategory1.SelectedValue = int.Parse(txtCategory1.Text);
            }
            else
            {
                txtCategory1.Text = string.Empty;
                lstCategory1.SelectedValue = -1;
            }
        }

        private void txtMaker_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaker_KeyDown(object sender, KeyEventArgs e)
        {
            Regex reg = new Regex(@"^[0-9]{3}$");

            if (e.KeyCode == Keys.Enter && reg.IsMatch(txtMaker.Text))
            {
                string makerCD = txtMaker.Text.Trim();
                string MakerName;
                if (!checkMaker(makerCD, out MakerName))
                {
                    MessageBox.Show("不明な仕入先です。");
                    return;
                }
                txtMaker.Text = makerCD + "," + MakerName;
                txtMetaKeyword.Text = txtMaker.Text;

            }
        }

        private void txtTanto_KeyDown(object sender, KeyEventArgs e)
        {
            Regex reg = new Regex(@"^[0-9]{3}$");

            if (e.KeyCode == Keys.Enter && reg.IsMatch(txtTanto.Text))
            {
                string staffCD = txtTanto.Text.Trim();
                string staffName;
                if (!checkStaff(staffCD, out staffName))
                {
                    MessageBox.Show("不明な社員です。");
                    return;
                }
                txtTanto.Text = staffCD + "," + staffName;

            }
        }

        private void lstCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstCategory1.SelectedValue != null)
            {
                txtCategory1.Text = lstCategory1.SelectedValue != null ? lstCategory1.SelectedValue.ToString() : "";
            }
        }


    }
}
