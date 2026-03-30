using Bcart受注管理.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bcart受注管理.AppData
{
    internal static class PublicData
    {

        public static _LoginUser LoginUser { get; set; } = new _LoginUser();

        public static Single DpiX { get; set; }
        public static Single DpiY { get; set; }

        public static void Init()
        {



        }

    }
}
