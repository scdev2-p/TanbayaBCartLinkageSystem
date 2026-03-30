using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCartApi.Entity
{
    // JsonSerializerはパラメータしか変換できないので全て { get; set; } にする事


    public class cProductStockReq
    {
        public List<cProductsStock>? product_stock { get; set; }
    }


    public class cProductsStock
    {
        public string product_no { get; set; }
        public long stock {  get; set; }
    }

    /*
        "product_stock": [
            {
                "product_no": "XM-5",
                "stock_flag": 0,
                "stock": 50
            },
            {
                "product_no": "SSM-1",
                "stock_flag": 0,
                "stock": 50
            },
            {
                "product_no": "AK-M",
                "stock": "+-2"
            }
        ]


    */




}





