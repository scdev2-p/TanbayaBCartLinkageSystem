using System.Text.Json;

namespace Bcart受注管理.Services
{
    /// <summary>
    /// JSON文字列の操作用クラス
    /// </summary>
    internal static class JsonManager
    {
        /// <summary>
        /// JSON文字列のシリアライザーに渡すオプション
        /// </summary>
        private static readonly JsonSerializerOptions JsonSerializerOptions = new ()
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            WriteIndented = true
        };

        /// <summary>
        /// オブジェクトからJSON文字列に変換します
        /// オブジェクトがnullの場合は空文字を返します
        /// </summary>
        /// <typeparam name="T">JSON文字列に変換する対象オブジェクトのクラス</typeparam>
        /// <param name="obj">JSON文字列に変換する対象オブジェクト</param>
        /// <returns>JSON文字列</returns>
        public static string GetJsonString<T>(T? obj)
        {
            if (obj == null) return string.Empty;
            return JsonSerializer.Serialize(obj, JsonSerializerOptions);
        }
    }
}
