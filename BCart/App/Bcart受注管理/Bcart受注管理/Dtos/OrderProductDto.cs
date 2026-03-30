using Bcart受注管理.Models;

namespace Bcart受注管理.Dtos
{
    /// <summary>
    /// BCart⇒受注管理システムの受注商品データ転送
    /// </summary>
    internal class OrderProductDto
    {
        public required OrderProduct OrderProduct { get; set; }
    }

}
