using Bcart受注管理.Dtos;
using Bcart受注管理.Models;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Bcart受注管理.Services
{
    /// <summary>
    /// BCartの出荷APIに関するサービス
    /// </summary>
    /// <param name="httpClientFactory">HttpClientのファクトリー</param>
    internal sealed class LogisticService(IHttpClientFactory httpClientFactory)
    {
        /// <summary>
        /// BCartの出荷APIから出荷情報を１件取得します
        /// </summary>
        /// <param name="id">出荷のid値</param>
        /// <returns>出荷情報</returns>
        public async Task<Logistic?> GetLogistic(long id)
        {
            Program.ScLogger.Info($"start {nameof(id)}={id}");

            using var client = httpClientFactory.CreateClient(Settings.Default.BCartHttpClientName);
            try
            {
                var logisticDto = await client.GetFromJsonAsync<LogisticDto>(
                    $"logistics/{id}",
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                        WriteIndented = true
                    });

                Program.ScLogger.Info($"{nameof(logisticDto.Logistic)}={JsonManager.GetJsonString(logisticDto?.Logistic)}");
                return logisticDto?.Logistic;
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// BCartの出荷APIの出荷情報更新用クラス
        /// </summary>
        private class LogisticUpdate()
        {
            public LogisticUpdate(Logistic updateValue) : this()
            {
                DeliveryCode = updateValue.DeliveryCode;
                ShipmentDate = updateValue.ShipmentDate?.ToString("yyyy-MM-dd");
                Status = updateValue.Status;
            }

            public string? DeliveryCode { get; set; }
            public string? ShipmentDate { get; set; }
            public string? Status { get; set; }
        }

        /// <summary>
        /// BCartの出荷APIから出荷情報を1件更新します
        /// </summary>
        /// <param name="updateValue">出荷の更新情報</param>
        /// <returns>更新後の出荷情報</returns>
        public async Task<Logistic?> UpdateLogistic(Logistic updateValue)
        {
            Program.ScLogger.Info($"start {nameof(updateValue)}={JsonManager.GetJsonString(updateValue)}");

            var jsonString = JsonManager.GetJsonString(new LogisticUpdate(updateValue));
            Program.ScLogger.Info($"update {nameof(jsonString)}={jsonString}");
            using var json = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json);

            using var client = httpClientFactory.CreateClient(Settings.Default.BCartHttpClientName);
            try
            {
                var httpResponse = await client.PatchAsync($"logistics/{updateValue.Id}", json);
                httpResponse.EnsureSuccessStatusCode();
                var prefecturesJsonString = await httpResponse.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Logistic>(prefecturesJsonString);
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex);
                throw;
            }
        }
    }
}
