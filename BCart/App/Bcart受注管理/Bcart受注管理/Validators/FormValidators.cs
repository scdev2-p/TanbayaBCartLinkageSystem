using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Bcart受注管理.Validators
{
    internal class FormValidators
    {
        ///// <summary>
        ///// 必須チェック
        ///// </summary>
        ///// <param name="name">検証対象の項目名</param>
        ///// <param name="value">検証する値</param>
        ///// <returns>検証結果</returns>
        //public static ValidationResult IsRequired(string name, string? value)
        //{
        //    var validationResult = new ValidationResult();
        //    if (string.IsNullOrWhiteSpace(value))
        //    {
        //        validationResult.IsError = true;
        //        validationResult.ErrorMessage = $"{name}は未入力です";
        //    }
        //    return validationResult;
        //}

        /// <summary>
        /// 必須チェック
        /// </summary>
        /// <param name="formValues">検証対象の項目名と検証する値</param>
        /// <returns>検証結果</returns>
        public static ValidationResult IsRequiredList(List<KeyValuePair<string, string>> formValues)
        {
            var validationResult = new ValidationResult();

            foreach (var pair in formValues)
            {
                // 入力が空の場合はエラーメッセージを生成
                if (string.IsNullOrWhiteSpace(pair.Value))
                {
                    validationResult.IsError = true;
                    validationResult.ErrorMessage = $"{pair.Key}は未入力です";

                    return validationResult;
                }
            }
            return validationResult;
        }
        /// <summary>
        /// 整数チェック
        /// </summary>
        /// <param name="name">検証対象の項目名</param>
        /// <param name="value">検証する値</param>
        /// <returns>検証結果</returns>
        public static ValidationResult IsIntager(string name, string? value)
        {

            var validationResult = new ValidationResult();
            if(!long.TryParse(value, out _))
            {
                validationResult.IsError = true;
                validationResult.ErrorMessage = $"{name}は整数以外が入力されています";
            }

            return validationResult;
        }
        /// <summary>
        /// 桁数チェック(以下)
        /// </summary>
        /// <param name="name">検証対象の項目名</param>
        /// <param name="value">検証する値</param>
        /// /// <param name="maxLength">最大値</param>
        /// <returns>検証結果</returns>
        public static ValidationResult CheckMaxLength(string name, string? value,int maxLength)
        {

            var validationResult = new ValidationResult();
            if (value.Length > maxLength)
            {
                validationResult.IsError = true;
                validationResult.ErrorMessage = $"{name}は{maxLength}桁以下で入力してください";
            }

            return validationResult;
        }
        /// <summary>
        /// 桁数チェック（以上）
        /// </summary>
        /// <param name="name">検証対象の項目名</param>
        /// <param name="value">検証する値</param>
        /// <param name="minLength">最大値</param>
        /// <returns>検証結果</returns>
        public static ValidationResult CheckMinLength(string name, string? value, int minLength)
        {

            var validationResult = new ValidationResult();
            if (value.Length < minLength)
            {
                validationResult.IsError = true;
                validationResult.ErrorMessage = $"{name}は{minLength}桁以上で入力してください";
            }

            return validationResult;
        }

        /// <summary>
        /// 郵便番号チェック
        /// </summary>
        /// <param name="name">検証対象の項目名</param>
        /// <param name="value">検証する値</param>
        /// <returns>>検証結果</returns>
        public static ValidationResult IsValidPostalCode(string name, string value)
        {
            var validationResult = new ValidationResult();

            // 郵便番号の正規表現パターン
            string pattern = @"^\d{3}-?\d{4}$";

            // 正規表現によるチェック
            if (!Regex.IsMatch(value, pattern))
            {
                validationResult.IsError = true;
                validationResult.ErrorMessage = $"{name}は(3桁の整数)-(4桁の整数)の形式で入力してください";
            };

            return validationResult;

        }

        /// <summary>
        /// 整数もしくはハイフンのみかチェック
        /// </summary>
        /// /// <param name="name">検証対象の項目名</param>
        /// <param name="value">検証する値</param>
        /// <returns>検証結果</returns>
        public static ValidationResult IsIntegerOrHyphen(string name,string value)
        {
            var validationResult = new ValidationResult();

            // ハイフンまたは整数の正規表現パターン
            string pattern = @"^[0-9-]+$";

            // 正規表現によるチェック
            if (!Regex.IsMatch(value, pattern))
            {   
                validationResult.IsError = true;
                validationResult.ErrorMessage = $"{name}は整数とハイフン（-）以外が入力されています";
            };

            return validationResult;

        }

        /// <summary>
        /// メールアドレスチェック
        /// </summary>
        /// <param name="name">検証対象の項目名</param>
        /// <param name="value">検証する値</param>
        /// <returns>>検証結果</returns>
        public static ValidationResult IsValidEmail(string name, string value)
        {
            var validationResult = new ValidationResult();

            // メールアドレスの正規表現パターン
            string pattern = @"^[a-zA-Z0-9_+-]+(.[a-zA-Z0-9_+-]+)*@([a-zA-Z0-9][a-zA-Z0-9-]*[a-zA-Z0-9]*\.)+[a-zA-Z]{2,}$";

            // 正規表現によるチェック
            if (!Regex.IsMatch(value, pattern))
            {
                validationResult.IsError = true;
                validationResult.ErrorMessage = $"{name}は正しい形式で入力してください";
            };

            return validationResult;
        }

        /// <summary>
        /// パスワードチェック
        /// 「英字（大文字）」「英字（小文字）」「数字」を1文字以上含む、8文字以上であることをチェック※ 半角
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValidationResult IsPasswordValid(string name, string value)
        {
            var validationResult = new ValidationResult();
            // 8文字以上
            var tmpCheckMinLengthResult = CheckMinLength(name, value, 8);
            if (tmpCheckMinLengthResult.IsError) return tmpCheckMinLengthResult;

            // 「英字（大文字）」「英字（小文字）」「数字」を1文字以上含む
            // 正規表現パターン
            string uppercasePattern = @"[A-Z]";
            string lowercasePattern = @"[a-z]";
            string digitPattern = @"[0-9]";

            // 各条件のチェック
            bool containsUppercase = Regex.IsMatch(value, uppercasePattern);
            bool containsLowercase = Regex.IsMatch(value, lowercasePattern);
            bool containsDigit = Regex.IsMatch(value, digitPattern);

            // すべての条件を満たしているか
            if(!(containsUppercase && containsLowercase && containsDigit))
            {
                validationResult.IsError = true;
                validationResult.ErrorMessage = $"{name}は正しい形式で入力してください";
            };
            return validationResult;

        }

    }
}
