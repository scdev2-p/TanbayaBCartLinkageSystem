using Bcart受注管理.Dtos;
using Bcart受注管理.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Bcart受注管理.Services
{
    /// <summary>
    /// BCartの受注商品APIに関するサービス
    /// </summary>
    /// <param name="httpClientFactory">HttpClientのファクトリー</param>
    internal sealed class OrderProductService(IHttpClientFactory httpClientFactory)
    {
        /// <summary>
        /// BCartの受注APIから受注情報を１件取得します
        /// </summary>
        /// <param name="id">受注商品のid値</param>
        /// <returns>受注商品情報</returns>
        public async Task<OrderProduct?> GetOrderProduct(long id)
        {
            Program.ScLogger.Info($"start {nameof(id)}={id}");

            using var client = httpClientFactory.CreateClient(Settings.Default.BCartHttpClientName);
            try
            {
                var orderProductDto = await client.GetFromJsonAsync<OrderProductDto>(
                    $"order_products/{id}",
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                        WriteIndented = true
                    });

                Program.ScLogger.Info($"{nameof(orderProductDto.OrderProduct)}={JsonManager.GetJsonString(orderProductDto?.OrderProduct)}");
                return orderProductDto?.OrderProduct;
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex);
                throw;
            }
        }

        /// <summary>
        /// BCartの受注商品APIから受注IDを元に受注商品情報のリストを取得します
        /// </summary>
        /// <remarks>
        /// BCart APIは1リクエストで最大100件のレコードが取得できます
        /// 最大件数はパラメータクエリでlimitを指定します
        /// offsetは取得の開始位置-1の数値を指定します
        /// </remarks>
        /// <param name="id">受注のid値</param>
        /// <param name="offset">オフセット</param>
        /// <returns>受注商品のリスト</returns>
        public async Task<List<OrderProduct>?> GetOrderProductsByOrderId(long id, long offset)
        {
            Program.ScLogger.Info($"start {nameof(id)}={id},{nameof(offset)}={offset}");

            using var client = httpClientFactory.CreateClient(Settings.Default.BCartHttpClientName);
            try
            {
                var orderProductsDto = await client.GetFromJsonAsync<OrderProductsDto>(
                    $"order_products?order_id={id}&limit={Settings.Default.Limit}&offset={offset}",
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                        WriteIndented = true
                    }) ;

                Program.ScLogger.Info($"{nameof(orderProductsDto.OrderProducts)}={JsonManager.GetJsonString(orderProductsDto?.OrderProducts)}");
                return orderProductsDto?.OrderProducts;
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex);
                throw;
            }
        }
    }
}
