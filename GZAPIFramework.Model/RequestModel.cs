using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Model
{
    /// <summary>
    /// 请求参数
    /// </summary>
    public class RequestModel : GZAPI.Core.Models.Interface.IRequestModel
    {
        /// <summary>
        /// 接口请求参数
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 接口号
        /// </summary>
        public int InterfaceCode { get; set; }
        
        /// <summary>
        /// Token令牌
        /// </summary>
        public string token { get; set; }

        public string Account { get; set; }

        /// <summary>
        /// 接口参数转换为对象集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> DataToList<T>() where T : class
        {
            List<T> lst = new List<T>();
            if (data is Newtonsoft.Json.Linq.JArray)
            {
                foreach (Newtonsoft.Json.Linq.JObject o in data as Newtonsoft.Json.Linq.JArray)
                {
                    var v = ToObject<T>(o);
                    if (v != null)
                    {
                        lst.Add(v);
                    }
                }
            }
            return lst;
        }
        /// <summary>
        /// 接口参数转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T DataToObject<T>() where T : class
        {
            if (data is Newtonsoft.Json.Linq.JObject)
                return ToObject<T>(data as Newtonsoft.Json.Linq.JObject);
            else
                return null;
        }

        /// <summary>
        /// JObjerct转换为对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>

        private T ToObject<T>(Newtonsoft.Json.Linq.JObject o) where T : class
        {
            if (o == null) return null;
            return o.ToObject<T>();
        }
    }
}
