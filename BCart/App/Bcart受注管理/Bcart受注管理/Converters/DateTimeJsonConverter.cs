using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bcart受注管理.Converters
{
    /// <summary>
    /// 文字列(yyyy-MM-dd HH:mm:ss)をDateTimeへ変換するコンバーター
    /// </summary>
    internal class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.GetString()! == null) return DateTime.MinValue;
            return DateTime.ParseExact(reader.GetString()!,
                "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(dateTimeValue.ToString(
                "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture));
    }
}
