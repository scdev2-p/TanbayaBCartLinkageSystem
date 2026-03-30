using Bcart受注管理.Dtos;
using Bcart受注管理.Models;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bcart受注管理.Services
{
    /// <summary>
    /// BCartの受注APIに関するサービス
    /// </summary>
    /// <param name="httpClientFactory">HttpClientのファクトリー</param>
    internal sealed class OrderService(IHttpClientFactory httpClientFactory)
    {
        /// <summary>
        /// BCartの受注APIから受注情報を１件取得します
        /// </summary>
        /// <param name="id">受注のid値</param>
        /// <returns>受注情報</returns>
        public async Task<Order?> GetOrder(long id)
        {
            Program.ScLogger.Info($"start {nameof(id)}={id}");

            using var client = httpClientFactory.CreateClient(Settings.Default.BCartHttpClientName);
            try
            {
                var orderDto = await client.GetFromJsonAsync<OrderDto>(
                    $"orders/{id}",
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                        WriteIndented = true
                    });

                Program.ScLogger.Info($"{nameof(orderDto.Order)}={JsonManager.GetJsonString(orderDto?.Order)}");
                return orderDto?.Order;
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// BCartの受注APIの受注情報更新用クラス
        /// </summary>
        private class OrderUpdate()
        {
            public OrderUpdate(Order updateValue) : this()
            {
                Status = updateValue.Status;
            }
            public string? Status { get; set; }
        }
        /// <summary>
        /// BCartの受注APIから受注情報を1件更新します
        /// </summary>
        /// <param name="updateValue">受注の更新情報</param>
        /// <returns>更新後の受注情報</returns>
        public async Task<Order?> UpdateOrder(Order updateValue)
        {
            Program.ScLogger.Info($"{nameof(UpdateOrder)} start:{nameof(updateValue)}={JsonManager.GetJsonString(updateValue)}");

            var jsonString = JsonManager.GetJsonString(new OrderUpdate(updateValue));
            Program.ScLogger.Info($"update {nameof(jsonString)}={jsonString}");
            using var json = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json);

            using var client = httpClientFactory.CreateClient(Settings.Default.BCartHttpClientName);
            try
            {
                var httpResponse = await client.PatchAsync($"orders/{updateValue.Id}", json);
                httpResponse.EnsureSuccessStatusCode();
                var prefecturesJsonString = await httpResponse.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<Order>(prefecturesJsonString);
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex);
                throw;
            }
        }
    }
}
