using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCartApi
{
    public static class Misc
    {

        /// <summary>
        /// オブジェクトのプロパティを簡易的にコピー
        /// 複雑な階層は対応できない
        /// </summary>
        /// <param name="objFrom"></param>
        /// <param name="objTo"></param>
        public static void CopyObject(object objFrom, object objTo)
        {
            foreach(var propFrom in objFrom.GetType().GetProperties())
            {
                foreach(var propTo in objTo.GetType().GetProperties())
                {
                    if(propFrom.Name == propTo.Name)
                    {
                        propTo.SetValue(objTo, propFrom.GetValue(objFrom));
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// オブジェクトを変換して新しく作る
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T NewConvertObject<T>(object obj)
        {
            T retObj = (T)Activator.CreateInstance(typeof(T));
            CopyObject(obj, retObj);
            return retObj;
        }

    }
}
