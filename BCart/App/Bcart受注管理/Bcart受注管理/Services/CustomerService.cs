using Bcart受注管理.Dtos;
using Bcart受注管理.Models;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace Bcart受注管理.Services
{
    /// <summary>
    /// BCartの会員API
    /// </summary>
    /// <param name="httpClientFactory">HTTPのファクトリー</param>
    internal class CustomerService(IHttpClientFactory httpClientFactory)
    {
        /// <summary>
        /// BCartに会員登録します
        /// </summary>BCartに送るデータ
        /// <param name="createValue"></param>
        /// <returns>成功時は成功内容、失敗時はエラーメッセージを返します</returns>
        public CustomerResultDto CreateCustomer(Customer createValue)
        {
            Program.ScLogger.Info($"start {nameof(createValue)}={JsonManager.GetJsonString(createValue)}");

            var jsonString = JsonManager.GetJsonString(new CustomerCreateDto(createValue));
            Program.ScLogger.Info($"update {nameof(jsonString)}={jsonString}");
            using var json = new StringContent(jsonString, Encoding.UTF8, MediaTypeNames.Application.Json);

            using var client = httpClientFactory.CreateClient(Settings.Default.BCartHttpClientName);
            try
            {
                var result = client.PostAsync($"customers/", json);
                result.Wait();
                var httpResponse = result.Result;
                var resultRead = httpResponse.Content.ReadAsStringAsync();
                resultRead.Wait();
                var prefecturesJsonString = resultRead.Result;

                if (httpResponse.IsSuccessStatusCode)
                {
                    // 成功
                    return new CustomerResultDto()
                    {
                        Customer = JsonSerializer.Deserialize<CustomerDto?>(prefecturesJsonString, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                            WriteIndented = true
                        }) 
                    };
                }
                else
                {
                    // 失敗
                    return new CustomerResultDto()
                    {
                        ErrorInfo = JsonSerializer.Deserialize<BCartApiErrorDto?>(prefecturesJsonString, new JsonSerializerOptions()
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                            WriteIndented = true
                        })
                    };
                }
            }
            catch (Exception ex)
            {
                Program.ScLogger.Error(ex);
                throw;
            }
        }
    }
}
