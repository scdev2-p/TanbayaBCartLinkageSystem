using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace BCartApi
{
    // 参考
    // https://qiita.com/hatobeam75/items/c4d7a2d2dc8df697030d
    // System.Text.Json.Serialization で DateTime がエラーになるのでローカライズする
    // BCartは"yyyy-MM-dd HH:mm:ss"形式

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

    internal class DateJsonConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.GetString()! == null) return DateTime.MinValue;
            return DateTime.ParseExact(reader.GetString()!,
                "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options) =>
            writer.WriteStringValue(dateTimeValue.ToString(
                "yyyy-MM-dd", CultureInfo.InvariantCulture));
    }

}
