using BCartApi.Entity;


namespace Bcart受注管理
{
    /// <summary>
    /// データベースに商品を登録するクラス
    /// </summary>
    internal class OrdersData
    {   
        /// <summary>
        /// 新規注文をデータベースに登録します
        /// </summary>
        /// <param name="order">ApiでBCartから取ってきたオーダー情報</param>
        /// <param name="ta"></param>
        internal static void InsertOrder(cOrdersGet order,  AppData.Ds.dsBCartLink2TableAdapters.bc_OrderTableAdapter ta, string tnb顧客コード)
        {
            // null回避
            List<decimal?> order_totals = new List<decimal?>
            {
                null,null,null
            };

            if (order.order_totals != null)
            {
                for (int i = 0; i < order.order_totals.Count; i++)
                {
                    order_totals[i] = order.order_totals[i].total_incl_tax;
                }
            }

            List<string> customs = new List<string>
            {
                "","",""
            };

            if (order.customs != null)
            {
                for (int i = 0; i < order.customs.Count; i++)
                {
                    customs[i] = order.customs[i].value;

                }
            }

            ta.Insert
            (
                order.id,
                order.code,
                order.customer_id,
                order.customer_ext_id,
                order.customer_parent_id,
                order.customer_salesman_id,
                order.customer_comp_name,
                order.customer_department,
                order.customer_name,
                order.customer_tel,
                order.customer_mobile_phone,
                order.customer_email,
                order.customer_price_group_id,
                order.customer_zip,
                order.customer_pref,
                order.customer_address1,
                order.customer_address2,
                order.customer_address3,
                order.customer_custom1,
                order.customer_custom2,
                tnb顧客コード,
                order.payment,
                order.payment_at,
                order.total_price,
                order.tax,
                order.tax_rate,
                order.COD_cost,
                order.shipping_cost,
                order.final_price,
                order.use_point,
                order.get_point,
                order_totals[0],
                order_totals[1],
                order_totals[2],
                order.customer_message,
                order.admin_message,
                order.memo,
                customs[0],
                customs[1],
                customs[2],
                order.enquete1,
                order.enquete2,
                order.enquete3,
                order.enquete4,
                order.enquete5,
                order.ordered_at,
                order.affiliate_id,
                // order.estimate_id,
                null,
                order.status

            );
        }
        /// <summary>
        /// 新規注文の商品ごとの明細をデータベースに登録します
        /// </summary>
        /// <param name="order_product">商品ごとの明細</param>
        /// <param name="ta2"></param>
        internal static void InsertOrderProduct(cOrder_productsGet order_product, AppData.Ds.dsBCartLink2TableAdapters.bc_OrderProductsTableAdapter ta2)
        {
            List<string> product_set_customs = new List<string>
             {
                 "","",""
             };

            if (order_product.product_set_customs != null)
            {
                for (int i = 0; i < order_product.product_set_customs.Count; i++)
                {
                    product_set_customs[i] = order_product.product_set_customs[i].value;
                }
            }
                ta2.Insert
                (
                    order_product.id,
                    order_product.order_id,
                    order_product.logistics_id,
                    order_product.product_id,
                    order_product.main_no,
                    order_product.product_no,
                    order_product.jan_code,
                    order_product.location_no,
                    order_product.product_name,
                    order_product.product_set_id,
                    order_product.set_name,
                    order_product.unit_price,
                    order_product.set_quantity.ToString(),
                    order_product.set_unit,
                    order_product.order_pro_count,
                    order_product.shipping_size,
                    order_product.tax_rate,
                    order_product.tax_type_id,
                    order_product.tax_incl,
                    order_product.item_type,
                    // 不要なためnull
                    // order_product.pro_custom1,
                    // order_product.pro_custom2,
                    null,
                    null,
                    null,
                    product_set_customs[0].Trim(),
                    product_set_customs[1].Trim(),
                    product_set_customs[2].Trim(),
                    order_product.options?[0].value,
                    order_product.options?[1].value,
                    order_product.options?[2].value
                );
        }

        internal static void InsertLogistics(cLogisticsGet logistics, AppData.Ds.dsBCartLink2TableAdapters.bc_LogisticsTableAdapter ta)
        {
            ta.Insert(
                logistics.id,
                logistics.shipment_code,
                logistics.delivery_code,
                logistics.destination_code,
                logistics.shipping_group_id.ToString(),
                logistics.comp_name,
                logistics.department,
                logistics.name,
                logistics.zip,
                logistics.pref,
                logistics.address1,
                logistics.address2,
                logistics.address3,
                logistics.tel,
                logistics.due_date,
                logistics.due_time,
                logistics.memo,
                logistics.shipment_date,
                logistics.arrival_date,
                logistics.status,
                logistics.complete
            );
        }


    }
}
