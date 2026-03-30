using Bcart受注管理.AppData;
using Bcart受注管理.AppData.Ds;
using Bcart受注管理.Dtos;
using Bcart受注管理.Models;
using Bcart受注管理.Services;
using Bcart受注管理.Utils;
using Bcart受注管理.Validators;
using System.Xml.Linq;

namespace Bcart受注管理.Forms
{
    public partial class frmRegistCustomer : Form
    {
        private readonly CustomerService _customerService;

        private string TnbCustomerID { get; set; }

        public frmRegistCustomer(string tnbCustomerID)
        {
            InitializeComponent();
            TnbCustomerID = tnbCustomerID;
            _customerService = Program.GetService<CustomerService>();
        }

        private void frmRegistCustomer_Load(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start {nameof(TnbCustomerID)}={TnbCustomerID}");

            this.lblDate.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd)");
            this.lblTitle.Text = "BCartへ会員を登録";

            dsBCartLink.M_都道府県DataTable dtPref = new dsBCartLink.M_都道府県DataTable();
            using (AppData.Ds.dsBCartLinkTableAdapters.M_都道府県TableAdapter ta = new AppData.Ds.dsBCartLinkTableAdapters.M_都道府県TableAdapter())
            {
                ta.Fill(dtPref);
                this.cmbPrefectures.DisplayMember = "都道府県名";
                this.cmbPrefectures.ValueMember = "都道府県コード";
                this.cmbPrefectures.DataSource = dtPref;
            }


            using (AppData.Ds.dsBCartLinkTableAdapters.BC_顧客送信用TableAdapter ta = new AppData.Ds.dsBCartLinkTableAdapters.BC_顧客送信用TableAdapter())
            using (AppData.Ds.dsBCartLink.BC_顧客送信用DataTable dt = new dsBCartLink.BC_顧客送信用DataTable())
            {
                ta.Fill(dt, this.TnbCustomerID);
                if (dt.Count == 0)
                {
                    Log.ErrWrite(string.Format("顧客データ取得エラー[{0}]", this.TnbCustomerID));
                    Program.ScLogger.Error($"顧客データ取得エラー[{TnbCustomerID}]");
                    MessageBox.Show("顧客情報の取得に失敗しました。", "システムエラー");
                    DialogResult = DialogResult.Cancel;
                }
                this.lblCustomerID.Text = dt[0].顧客管理番号;
                this.lblCustomerCode.Text = dt[0].顧客コード;
                this.lblCustomerName.Text = dt[0].顧客名;
                this.lblCustomerNameKana.Text = dt[0].顧客名カナ;
                this.txtName_Sei.Text = "ご担当者";
                this.txtName_Mei.Text = "";

                this.lblRank.Text = dt[0].クラス;
                this.lblRank2.Text = dt[0].ランク;
                this.lblOversea.Text = dt[0].海外禁止 == "0" ? "" : "海外禁止";
                this.lblOversea2.Text = dt[0].海外禁止;
                this.lblTGLimit.Text = dt[0].IsTG設定額Null() ? "" : dt[0].TG設定額.ToString();
                this.lblSpecialShippingCost.Text = dt[0].海外禁止 == "2" ? "0" : "なし";
                this.lblClosingDate.Text = "20";
                this.lblPayment1.Text = "銀行振込";
                this.lblPayment2.Text = "代金引換";
                this.lblPayment3.Text = "クレジット";

                if (IsTGCard(dt[0].代表顧客コード))      // TGカード有無判定
                {
                    // "銀行振込,代金引換,PayPal,カスタム,カスタム2";
                    this.lblPayment4.Text = "yhカード";
                    this.lblPayment5.Text = "您所配合的代工";
                }
                else
                {
                    // "銀行振込,代金引換,PayPal,カスタム2";
                    this.lblPayment4.Text = "您所配合的代工";
                    this.lblPayment5.Text = "";
                }


                string tmp郵便番号 = "";
                string tmp住所 = "";
                string tmp電話番号 = "";
                string tmpFax = "";

                if (dt[0].送り先有 != 0)
                {
                    // 送り先
                    tmp郵便番号 = dt[0].Is送り先郵便番号Null() ? "" : dt[0].送り先郵便番号.ToString();
                    tmp住所 = dt[0].Is送り先住所1Null() ? "" : dt[0].送り先住所.ToString();
                    tmp電話番号 = dt[0].Is送り先電話番号Null() ? "" : dt[0].送り先電話番号.ToString();
                    tmpFax = dt[0].Is送り先FAX番号Null() ? "" : dt[0].送り先FAX番号.ToString();

                }
                else
                {
                    // マスタ
                    tmp郵便番号 = dt[0].Is郵便番号Null() ? "" : dt[0].郵便番号.ToString();
                    tmp住所 = dt[0].Is住所1Null() ? "" : dt[0].住所.ToString();
                    tmp電話番号 = dt[0].Is電話番号Null() ? "" : dt[0].電話番号.ToString();
                    tmpFax = dt[0].IsFAX番号Null() ? "" : dt[0].FAX番号.ToString();
                }

                if (tmp郵便番号.Length > 4)
                    tmp郵便番号 = tmp郵便番号.Substring(0, 3) + "-" + tmp郵便番号.Substring(3);
                this.txtZip.Text = tmp郵便番号;

                var cnvAd = ConvertAddress(tmp住所);
                if (cnvAd != null)
                {
                    this.cmbPrefectures.SelectedText = cnvAd.Address1;
                    this.txtAddress1.Text = cnvAd.Address2;
                    this.txtAddress2.Text = cnvAd.Address3;
                    this.txtAddress3.Text = cnvAd.Address4;
                }
                else
                {
                    this.txtAddress1.Text = tmp住所;
                }

                //this.txtTel.Text = tmp電話番号;
                //this.txtFax.Text = tmpFax;

                // 電話番号、FAXに-をつける
                this.txtTel.Text = PhoneNumberFormatter.FormatPhoneNumber(tmp電話番号);
                this.txtFax.Text = PhoneNumberFormatter.FormatPhoneNumber(tmpFax);


                this.txtEMail.Text = dt[0].IsメールアドレスNull() ? "" : dt[0].メールアドレス;
                this.txtPassword.Text = "";

                Program.ScLogger.Info($"before {nameof(this.lblCustomerID)}={this.lblCustomerID.Text}, {nameof(this.lblCustomerCode)}={this.lblCustomerCode.Text}, {nameof(this.lblCustomerName)}={this.lblCustomerName.Text}, {nameof(this.lblCustomerNameKana)}={this.lblCustomerNameKana.Text}, {nameof(this.txtName_Sei)}={this.txtName_Sei.Text}, {nameof(this.txtName_Mei)}={this.txtName_Mei.Text}, {nameof(this.lblRank)}={this.lblRank.Text}, {nameof(this.lblOversea)}={this.lblOversea.Text}, {nameof(this.lblTGLimit)}={this.lblTGLimit.Text}, {nameof(this.lblClosingDate)}={this.lblClosingDate.Text}, {nameof(this.lblPayment1)}={this.lblPayment1.Text}, {nameof(this.lblPayment2)}={this.lblPayment2.Text}, {nameof(this.lblPayment3)}={this.lblPayment3.Text}, {nameof(this.lblPayment4)}={this.lblPayment4.Text}, {nameof(this.lblPayment5)}={this.lblPayment5.Text}, {nameof(this.txtZip)}={this.txtZip.Text}, {nameof(this.cmbPrefectures)}={this.cmbPrefectures.SelectedText}, {nameof(this.txtAddress1)}={this.txtAddress1.Text}, {nameof(this.txtAddress2)}={this.txtAddress2.Text}, {nameof(this.txtAddress3)}={this.txtAddress3.Text}, {nameof(this.txtTel)}={this.txtTel.Text}, {nameof(this.txtFax)}={this.txtFax.Text}, {nameof(this.txtEMail)}={this.txtEMail.Text}");
            }

            Program.ScLogger.Info($"end");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start");
            // 画面を閉じる
            this.DialogResult = DialogResult.Cancel;
            Program.ScLogger.Info($"end");
        }

        private void btnRegistBCart_Click(object sender, EventArgs e)
        {
            Program.ScLogger.Info($"start after {nameof(this.lblCustomerID)}={this.lblCustomerID.Text}, {nameof(this.lblCustomerCode)}={this.lblCustomerCode.Text}, {nameof(this.lblCustomerName)}={this.lblCustomerName.Text}, {nameof(this.lblCustomerNameKana)}={this.lblCustomerNameKana.Text}, {nameof(this.txtName_Sei)}={this.txtName_Sei.Text}, {nameof(this.txtName_Mei)}={this.txtName_Mei.Text}, {nameof(this.lblRank)}={this.lblRank.Text}, {nameof(this.lblOversea)}={this.lblOversea.Text}, {nameof(this.lblTGLimit)}={this.lblTGLimit.Text}, {nameof(this.lblClosingDate)}={this.lblClosingDate.Text}, {nameof(this.lblPayment1)}={this.lblPayment1.Text}, {nameof(this.lblPayment2)}={this.lblPayment2.Text}, {nameof(this.lblPayment3)}={this.lblPayment3.Text}, {nameof(this.lblPayment4)}={this.lblPayment4.Text}, {nameof(this.lblPayment5)}={this.lblPayment5.Text}, {nameof(this.txtZip)}={this.txtZip.Text}, {nameof(this.cmbPrefectures)}={this.cmbPrefectures.SelectedText}, {nameof(this.txtAddress1)}={this.txtAddress1.Text}, {nameof(this.txtAddress2)}={this.txtAddress2.Text}, {nameof(this.txtAddress3)}={this.txtAddress3.Text}, {nameof(this.txtTel)}={this.txtTel.Text}, {nameof(this.txtFax)}={this.txtFax.Text}, {nameof(this.txtEMail)}={this.txtEMail.Text}");
            // 操作ログ記載
            string machinname = Environment.MachineName;
            using AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter bco = new AppData.Ds.dsBCartLinkTableAdapters.QueriesTableAdapter();
            bco.Insert_bcOperationLog(DateTime.Now, machinname, "顧客登録", "CustomerCode:" + this.lblCustomerCode.Text);
            // -------------------------------------- 入力値チェック ------------------------------------------- //
            // 必須チェック
            // フォームの項目名と入力された値のペアを格納するリスト
            List<KeyValuePair<string, string>> formValues = new List<KeyValuePair<string, string>>();

            // データを追加
            formValues.Add(new KeyValuePair<string, string>("担当者名（姓）", this.txtName_Sei.Text));
            formValues.Add(new KeyValuePair<string, string>("郵便番号", this.txtZip.Text));
            formValues.Add(new KeyValuePair<string, string>("都道府県", this.cmbPrefectures.Text));
            formValues.Add(new KeyValuePair<string, string>("市区町村", this.txtAddress1.Text));
            formValues.Add(new KeyValuePair<string, string>("町域・番地", this.txtAddress2.Text));
            formValues.Add(new KeyValuePair<string, string>("電話番号", this.txtTel.Text));
            formValues.Add(new KeyValuePair<string, string>("メールアドレス", this.txtEMail.Text));
            formValues.Add(new KeyValuePair<string, string>("パスワード", this.txtPassword.Text));

            var validationResult = FormValidators.IsRequiredList(formValues);

            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }


            // 郵便番号が(3桁整数)-(4桁整数)かどうか
            validationResult = FormValidators.IsValidPostalCode("郵便番号", this.txtZip.Text);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            // 電話番号が整数と半角ハイフン(-)のみかどうか
            validationResult = FormValidators.IsIntegerOrHyphen("電話番号", this.txtTel.Text);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            // FAXが整数と半角ハイフン(-)のみかどうか
            if(this.txtFax.Text != "")
            validationResult = FormValidators.IsIntegerOrHyphen("FAX", this.txtFax.Text);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            // メールアドレスが正しい形式かどうか
            validationResult = FormValidators.IsValidEmail("Eメールアドレス", this.txtEMail.Text);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            // パスワードに必要な文字が含まれているかどうか(「英字（大文字）」「英字（小文字）」「数字」を1文字以上含む、8文字以上であることをチェック※ 半角)
            validationResult = FormValidators.IsPasswordValid("パスワード", this.txtPassword.Text);
            if (validationResult.ShowError())
            {
                Program.ScLogger.Info($"{nameof(validationResult.ErrorMessage)}={validationResult.ErrorMessage}");
                return;
            }

            if (MessageBox.Show("BCartに登録します。\nよろしいですか？", "BCartへ会員を登録", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                Program.ScLogger.Info($"end キャンセルクリック");
                return;
            }
            
            // -------------------------------------- BCartに登録する ------------------------------------------- //

            List<Label> lblPayments = new List<Label>
            {
                lblPayment1, // フォームに配置したlabelの名前
                lblPayment2,
                lblPayment3,
                lblPayment4,
                lblPayment5
            };

            // 支払い方法を一行にまとめる
            // 入力データを格納するリスト
            List<string> data = new List<string>();

            // 各Labelのテキストをチェックし、データが入力されていればリストに追加
            foreach (var label in lblPayments)
            {
                if (!string.IsNullOrWhiteSpace(label.Text))
                {
                    // yhカードはカスタム、您所配合的代工はカスタム2に変換
                    label.Text = (label.Text == "yhカード") ? label.Text = "カスタム": label.Text;
                    label.Text = (label.Text == "您所配合的代工") ? label.Text = "カスタム2" : label.Text;

                    data.Add(label.Text);
                    Program.ScLogger.Info($"{nameof(label.Text)}={label.Text}");
                }
            }

            // ,で一行につなげる
            string payments = string.Join(",", data);
            // string payments = "銀行振込,代金引換,クレジット,カスタム";

            // 出荷情報取得
            var customerResult = _customerService.CreateCustomer(new Models.Customer()
            {
                ExtId = this.lblCustomerID.Text,
                CompName = this.lblCustomerName.Text,
                CompNameKana = this.lblCustomerNameKana.Text,
                TantoLastName = this.txtName_Sei.Text,
                TantoFirstName = this.txtName_Mei.Text,
                Zip = this.txtZip.Text,
                Pref = this.cmbPrefectures.Text,
                Address1 = this.txtAddress1.Text,
                Address2 = this.txtAddress2.Text,
                Address3 = this.txtAddress3.Text,
                Email = this.txtEMail.Text,
                Tel = this.txtTel.Text,
                Fax = (this.txtFax.Text == null) ? "" : this.txtFax.Text,
                Payment = payments,
                SpecialShippingCost = (this.lblOversea2.Text == "2") ? "0" : "",
                PriceGroupId = long.Parse(this.lblRank2.Text),
                ViewGroupId = (this.lblOversea2.Text == "0") ? null : long.Parse(this.lblOversea2.Text),
                CutoffDate = "20",
                Customs = new List<Models.CustomerCustom>
                    {
                        new Models.CustomerCustom()
                        {
                            FieldId = 3,
                            Value = this.lblCustomerCode.Text,
                        }
                    },
                CreditLimit = this.lblTGLimit.Text == "" ? null : decimal.Parse(this.lblTGLimit.Text),
                Password = this.txtPassword.Text,
            }) ;

            Program.ScLogger.Info($"{nameof(this.lblCustomerID.Text)}={this.lblCustomerID.Text}, {nameof(this.lblCustomerName.Text)}={this.lblCustomerName.Text},{nameof(this.lblCustomerNameKana.Text)}={this.lblCustomerNameKana.Text},{nameof(this.txtName_Sei.Text)}={this.txtName_Sei.Text},{nameof(this.txtName_Mei.Text)}={this.txtName_Mei.Text},{nameof(this.txtZip.Text)}={this.txtZip.Text},{nameof(this.cmbPrefectures.Text)}={this.cmbPrefectures.Text},{nameof(this.txtAddress1.Text)}={this.txtAddress1.Text},{nameof(this.txtAddress2.Text)}={this.txtAddress2.Text},{nameof(this.txtAddress3.Text)}={this.txtAddress3.Text},{nameof(this.txtEMail.Text)}={this.txtEMail.Text},{nameof(this.txtTel.Text)}={this.txtTel.Text},{nameof(this.txtFax.Text)}={this.txtFax.Text},{nameof(payments)}={payments},{nameof(this.lblOversea.Text)}={this.lblOversea.Text},{nameof(this.lblRank2.Text)}={this.lblRank2.Text},{nameof(this.lblCustomerCode.Text)}={this.lblCustomerCode.Text},{nameof(this.lblTGLimit.Text)}={this.lblTGLimit.Text},{nameof(this.txtPassword.Text)}={this.txtPassword.Text}");

            if (customerResult?.ErrorInfo != null)
            {
                // 顧客登録でBCart API側でエラー
                var errorMessage = string.Empty;
                customerResult.ErrorInfo.Errors.ForEach(errorDic =>
                {
                    foreach (KeyValuePair<string, string> kvp in errorDic)
                    {
                        if (!string.IsNullOrWhiteSpace(errorMessage))
                        {
                            errorMessage += Environment.NewLine;
                        }
                        errorMessage += kvp.Value;
                    }
                });

                Program.ScLogger.Info($"{nameof(errorMessage)}={errorMessage}");
                MessageBox.Show(errorMessage, "入力エラー(BCartからのメッセージ)");
                return;
            }
            else if(!string.IsNullOrWhiteSpace(customerResult?.Error))
            {
                Program.ScLogger.Info($"{nameof(customerResult.Error)}={customerResult?.Error}");
                MessageBox.Show(customerResult?.Error, "入力エラー(BCartからのメッセージ)");
                return;
            }

            // --------------------------------------- bc登録済顧客に追加 ------------------------------------------------ //
            // --------------------------------- tnb.dbo.M_顧客配送 に登録する ------------------------------------------- //　対応不要

            if (customerResult?.Customer?.Customers?.FirstOrDefault() is Customer customer)
            {
                var priceGroupId = "";
                var viewGroupId = "";
                var address = "";
                if (customer.Address3 == "")
                {
                    address = customer.Pref + customer.Address1 + customer.Address2;
                } else
                {
                    address = customer.Pref + customer.Address1 + customer.Address2 + customer.Address3;
                }
                // ハイフン削除ver
                var tel = customer.Tel.Replace("-", "");
                var fax = (customer.Fax == null) ? null : customer.Fax.Replace("-", "");
                var zip = (customer.Zip == null) ? "" : customer.Zip.Replace("-", "");

                using AppData.Ds.dsBCartLinkTableAdapters.bc登録済顧客TableAdapter Ta = new AppData.Ds.dsBCartLinkTableAdapters.bc登録済顧客TableAdapter();
                // bc登録済顧客に登録する（BCart顧客IDを付ける）
                Ta.Insert(
                        null,
                        (int)customer.Id,
                        this.lblCustomerID.Text,
                        customer.CompName,
                        customer.CompNameKana,
                        null,
                        null,
                        null,
                        null,
                        customer.Department = (customer.Department == "")? null: customer.Department,
                        customer.TantoLastName = (customer.TantoLastName == "") ? null : customer.TantoLastName,
                        customer.TantoFirstName = (customer.TantoFirstName == "") ? null : customer.TantoFirstName,
                        customer.TantoLastNameKana = (customer.TantoLastNameKana == "") ? null : customer.TantoLastNameKana,
                        customer.TantoFirstNameKana = (customer.TantoFirstNameKana == "") ? null : customer.TantoFirstNameKana,
                        customer.Zip,
                        customer.Pref,
                        customer.Address1,
                        customer.Address2,
                        customer.Address3 = (customer.Address3 == "") ? null : customer.Address3,
                        customer.Email,
                        "0",
                        customer.EmailCc = (customer.EmailCc == "") ? null : customer.EmailCc,
                        customer.Tel,
                        customer.MobilePhone = (customer.MobilePhone == "") ? null : customer.MobilePhone,
                        customer.Fax = (customer.Fax == "") ? null : customer.Fax,
                        priceGroupId = (customer.PriceGroupId == null) ? "0" : customer.PriceGroupId.ToString(),
                        viewGroupId = (customer.ViewGroupId == null) ? "0" : customer.ViewGroupId.ToString(),
                        this.lblCustomerCode.Text,
                        null
                        );

                Program.ScLogger.Info($"{nameof(customer.Id)}={customer.Id}, " +
                    $"{nameof(customer.CompName)}={customer.CompName}, " +
                    $"{nameof(customer.CompNameKana)}={customer.CompNameKana}, " +
                    $"{nameof(customer.Department)}={(string.IsNullOrEmpty(customer.Department) ? "null" : customer.Department)}, " +
                    $"{nameof(customer.TantoLastName)}={(string.IsNullOrEmpty(customer.TantoLastName) ? "null" : customer.TantoLastName)}, " +
                    $"{nameof(customer.TantoFirstName)}={(string.IsNullOrEmpty(customer.TantoFirstName) ? "null" : customer.TantoFirstName)}, " +
                    $"{nameof(customer.TantoLastNameKana)}={(string.IsNullOrEmpty(customer.TantoLastNameKana) ? "null" : customer.TantoLastNameKana)}, " +
                    $"{nameof(customer.TantoFirstNameKana)}={(string.IsNullOrEmpty(customer.TantoFirstNameKana) ? "null" : customer.TantoFirstNameKana)}, " +
                    $"{nameof(customer.Zip)}={customer.Zip}, " +
                    $"{nameof(customer.Pref)}={customer.Pref}, " +
                    $"{nameof(customer.Address1)}={customer.Address1}, " +
                    $"{nameof(customer.Address2)}={customer.Address2}, " +
                    $"{nameof(customer.Address3)}={(string.IsNullOrEmpty(customer.Address3) ? "null" : customer.Address3)}, " +
                    $"{nameof(customer.Email)}={customer.Email}, " +
                    $"{nameof(customer.EmailCc)}={(string.IsNullOrEmpty(customer.EmailCc) ? "null" : customer.EmailCc)}, " +
                    $"{nameof(customer.Tel)}={customer.Tel}, " +
                    $"{nameof(customer.MobilePhone)}={(string.IsNullOrEmpty(customer.MobilePhone) ? "null" : customer.MobilePhone)}, " +
                    $"{nameof(customer.Fax)}={(string.IsNullOrEmpty(customer.Fax) ? "null" : customer.Fax)}, " +
                    $"{nameof(customer.PriceGroupId)}={(customer.PriceGroupId == null ? "0" : customer.PriceGroupId.ToString())}, " +
                    $"{nameof(customer.ViewGroupId)}={(customer.ViewGroupId == null ? "0" : customer.ViewGroupId.ToString())}");


                //tnb.dbo.M_顧客配信設定にメールアドレスを登録する
                using AppData.Ds.dsBCartLinkTableAdapters.M_顧客配信設定TableAdapter MCustomerMailTa = new AppData.Ds.dsBCartLinkTableAdapters.M_顧客配信設定TableAdapter();
                try
                {
                    using var MCustomerMailda = new dsBCartLink.M_顧客配信設定DataTable();
                    MCustomerMailTa.Fill(MCustomerMailda, this.lblCustomerID.Text);
                    if (MCustomerMailda.Count > 0)
                    {
                        Program.ScLogger.Info($"{nameof(this.lblCustomerID.Text)}={this.lblCustomerID.Text}, before {nameof(MCustomerMailda.PCメールアドレスColumn)}={MCustomerMailda[0].PCメールアドレス}");
                        Program.ScLogger.Info($"{nameof(this.lblCustomerID.Text)}={this.lblCustomerID.Text}, before {nameof(MCustomerMailda.PCメールフラグColumn)}={MCustomerMailda[0].PCメールフラグ}");
                        MCustomerMailda[0].PCメールアドレス = this.txtEMail.Text;
                        MCustomerMailda[0].PCメールフラグ = true;
                        Program.ScLogger.Info($"{nameof(this.lblCustomerID.Text)}={this.lblCustomerID.Text}, after {nameof(MCustomerMailda.PCメールアドレスColumn)}={MCustomerMailda[0].PCメールアドレス}");
                        Program.ScLogger.Info($"{nameof(this.lblCustomerID.Text)}={this.lblCustomerID.Text}, after {nameof(MCustomerMailda.PCメールフラグColumn)}={MCustomerMailda[0].PCメールフラグ}");
                        MCustomerMailTa.Update(MCustomerMailda);
                    }
                }
                catch 
                {
                    Program.ScLogger.Info($"{("M_顧客配信設定更新")}={"UPDATEに失敗しました"}");
                }

                //tnb.dbo.M_顧客配送 に登録する
                //using AppData.Ds.dsTnbTableAdapters.M_顧客配送TableAdapter CustomerShippingTa = new AppData.Ds.dsTnbTableAdapters.M_顧客配送TableAdapter();
                //CustomerShippingTa.Insert(
                //        customer.ExtId,
                //        customer.CompName,
                //        zip,
                //        address,
                //        tel,
                //        customer.Fax = customer.Fax == null ? null : customer.Fax.Replace("-", ""),
                //        //登録者番号 ?
                //        "",
                //        //登録日
                //        DateTime.Parse(customer.CreatedAt),
                //        //更新者番号
                //        null,
                //        //更新日
                //        null
                //        );
            }
            else
            {
                MessageBox.Show("登録された顧客情報の取得に失敗しました", "入力エラー");
                return;
            }

                MessageBox.Show("BCartに登録しました。", "BCart顧客登録");
            // 画面を閉じる
            this.DialogResult = DialogResult.OK;

            Program.ScLogger.Info($"end");
        }



        private bool IsTGCard(string 代表顧客番号)
        {
            Program.ScLogger.Info($"start {nameof(代表顧客番号)}={代表顧客番号}");
            bool ret = false;

            using (AppData.Ds.dsTnbTableAdapters.M_顧客カードTableAdapter ta = new AppData.Ds.dsTnbTableAdapters.M_顧客カードTableAdapter())
            using (dsTnb.M_顧客カードDataTable dt = new dsTnb.M_顧客カードDataTable())
            {
                ta.Fill(dt, 代表顧客番号);
                if (dt.Count > 0)
                    ret = true;
            }

            Program.ScLogger.Info($"end {nameof(ret)}={ret}");
            return ret;
        }


        private class _AddressInfo
        {
            public string Address1 { get; set; } = string.Empty;
            public string Address2 { get; set; } = string.Empty;
            public string Address3 { get; set; } = string.Empty;
            public string Address4 { get; set; } = string.Empty;
        }

        private _AddressInfo? ConvertAddress(string address)
        {
            Program.ScLogger.Info($"start {nameof(address)}={address}");

            using (AppData.Ds.dsBCartLinkTableAdapters.utf_ken_allTableAdapter ta = new AppData.Ds.dsBCartLinkTableAdapters.utf_ken_allTableAdapter())
            using (dsBCartLink.utf_ken_allDataTable dt = new dsBCartLink.utf_ken_allDataTable())
            {
                try
                {
                    string tmpAdr = address.Replace('ケ', 'ヶ');
                    ta.Fill(dt, tmpAdr);
                    if (dt.Count == 0)
                    {
                        tmpAdr = address.Replace('ヶ', 'ケ');
                        ta.Fill(dt, tmpAdr);
                    }

                    if (dt.Count > 0)
                    {
                        _AddressInfo ret = new _AddressInfo();
                        ret.Address1 = dt[0].都道府県;
                        ret.Address2 = dt[0].市区町村;
                        tmpAdr = tmpAdr.Replace(ret.Address1 + ret.Address2, "");
                        string[] tmpAd = tmpAdr.Split("　");
                        ret.Address3 = tmpAd[0];
                        tmpAd = address.Split("　");
                        if (tmpAd.Length > 1)
                            ret.Address4 = tmpAd[1];

                        Program.ScLogger.Info($"end {nameof(ret.Address1)}={ret.Address1}, {nameof(ret.Address2)}={ret.Address2}, {nameof(ret.Address3)}={ret.Address3}, {nameof(ret.Address4)}={ret.Address4}");
                        return ret;
                    }
                }
                catch (Exception ex)
                {
                    Program.ScLogger.Error(ex);
                    throw new Exception(address + ex.ToString());
                }
            }

            Program.ScLogger.Info($"end");
            return null;
        }

        /// <summary>
        /// フォームが閉じられた後のイベントハンドラー
        /// </summary>
        /// <param name="sender">イベント発生元オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        private void frmRegistCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.ScLogger.Info($"start-end");
        }
    }
}
