using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Biz.Config
{
    /// <summary>
    /// 接口列表
    /// </summary>
    internal class InterfaceCodeList : GZAPI.Core.Interface.IInfaceCodeList
    {
        public Dictionary<int, Type> InitInterface()
        {
            Dictionary<int, Type> dic = new Dictionary<int, Type>();
            dic.Add(101, typeof(Request.RequestSample));
            dic.Add(102, typeof(Request.RequestSample2));
            return dic;
        }
    }
}
