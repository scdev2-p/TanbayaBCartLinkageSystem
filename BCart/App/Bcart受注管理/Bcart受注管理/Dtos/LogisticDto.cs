using Bcart受注管理.Models;

namespace Bcart受注管理.Dtos
{
    /// <summary>
    /// BCart⇒受注管理システムの出荷データ転送
    /// </summary>
    internal class LogisticDto
    {
        public required Logistic Logistic { get; set; }
    }
}
