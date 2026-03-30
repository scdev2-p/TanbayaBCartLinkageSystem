using Bcart受注管理.Models;

namespace Bcart受注管理.Dtos
{
    /// <summary>
    /// BCart⇒受注管理システムの受注商品リストデータ転送
    /// </summary>
    internal class OrderProductsDto
    {
        public required List<OrderProduct> OrderProducts { get; set; }
    }
}
