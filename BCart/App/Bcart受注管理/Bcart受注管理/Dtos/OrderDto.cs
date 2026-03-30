using Bcart受注管理.Models;

namespace Bcart受注管理.Dtos
{
    /// <summary>
    /// BCart⇒受注管理システムの受注データ転送
    /// </summary>
    internal class OrderDto
    {
        public required Order Order { get; set; }
    }
}
