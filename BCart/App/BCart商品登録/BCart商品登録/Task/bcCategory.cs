using BCartApi;
using BCartApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCartApi;
using BCartApi.Entity;

namespace BCart商品登録.Task
{
    internal class bcCategory : IDisposable
    {
        HttpApiCommon api = new HttpApiCommon();
        private const string commandUrlCategories = "categories";


        public bcCategory()
        {

        }

        public void Dispose()
        {
            api.Dispose();
        }

        public bool getCategory(string categoryCD, out string categoryName)
        {
            categoryName = "";

            var ret = api.GetCommandId<cCategory>(commandUrlCategories, categoryCD);
            if(ret == null || ret.category == null)
            {
                return false;
            }
            categoryName = ret.category.name;

            return true;
        }


    }
}
