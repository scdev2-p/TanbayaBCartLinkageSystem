using Bcart受注管理.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bcart受注管理.Dtos.CustomerCreateDto;

namespace Bcart受注管理.Dtos
{
    internal class CustomerDto
    {
        public List<Customer>? Customers { get; set; }
    }
}
