using BCartApi;
using BCartApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCartLinkBatch
{
    internal class OrdersApi
    {
        /// <summary>
        /// BCartからApiでオーダー（ステータスが新規注文）を取得します
        /// </summary>
        /// <param name="com">HTTP APIリクエストを表すCommandオブジェクト</param>
        /// <returns>APIリクエストの結果を表す（新規注文のオーダー情報）</returns>
        internal static cOrders? GetNewOrders(HttpApiCommon com)
        {
            // apiで新規注文のオーダーを取得
            ApiCommandParam[] prm = { new ApiCommandParam("status", "新規注文") };

            var ret = com.GetListCommand<cOrders>("orders", prm);
            if (ret == null)
            {
                Log.ErrWrite("新規注文取得エラー");
                return null;

            }
            else
            {
                return ret;
            }
        }

        /// <summary>
        /// 新規注文されたオーダーの商品ごとの明細をApiで取得
        /// </summary>
        /// <param name="com">HTTP APIリクエストを表すCommandオブジェクト</param>
        /// <param name="order_id">GetNewOrdersで取得した新規注文のオーダーID</param>
        /// <returns>APIリクエストの結果を表す（受注の明細（商品毎））</returns>
        internal static cOrder_products? GetNewOrderProducts(HttpApiCommon com, string order_id, string lastID, string limit)
        {
            // 受注の明細（商品毎）を取得
            ApiCommandParam[] prm2 = { new ApiCommandParam("order_id", order_id), new ApiCommandParam("limit", limit), new ApiCommandParam("offset", lastID) };
            var ret2 = com.GetListCommand<cOrder_products>("order_products", prm2);
            if (ret2 == null)
            {
                Log.ErrWrite("受注の明細（商品毎）取得エラー");
                return null;
            }
            else
            {
                return ret2;
            }
        }

        /// <summary>
        /// 新規注文されたオーダーの出荷をApiで取得
        /// </summary>
        /// <param name="com">HTTP APIリクエストを表すCommandオブジェクト</param>
        /// <param name="logistics_id">GetNewOrderProductsで取得した受注商品の出荷ID</param>
        /// <returns>Apiリクエストの結果を表す（出荷）</returns>
        internal static cLogisticsGetResponse GetNewLogistics(HttpApiCommon com, long logistics_id)
        {
            var ret = com.GetCommandId<cLogisticsGetResponse>("logistics", logistics_id.ToString());
            if (ret == null)
            {
                Log.ErrWrite("出荷取得エラー");
                return null;
            }
            else
            {
                return ret;
            }
        }



        internal static cOrderResponse? UpdateOrder(HttpApiCommon com, string orderID, cOrderStatus order)
        {
            return com.PatchCommandId<cOrderStatus, cOrderResponse>("orders", orderID, order);

        }

        internal static cOrders? debugGetNewOrder(HttpApiCommon com, string orderCD)
        {
            // apiで新規注文のオーダーを取得
            ApiCommandParam[] prm = { new ApiCommandParam("code", orderCD) };

            var ret = com.GetListCommand<cOrders>("orders", prm);
            if (ret == null)
            {
                Log.ErrWrite("新規注文取得エラー");
                return null;

            }
            else
            {
                return ret;
            }
        }


        internal static cProduct? GetProduct(HttpApiCommon com, string productID)
        {
            var ret = com.GetCommandId<cProduct>("products", productID);
            if (ret == null)
            {
                Log.ErrWrite("商品取得エラー");
                return null;
            }
            else
            {
                return ret;
            }

        }
    }
}
