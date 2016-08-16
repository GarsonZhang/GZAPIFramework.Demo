using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Biz
{
    public class APIHelp
    {
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object RunInterface(Model.RequestModel data)
        {
            return GZAPI.Core.BicycleAPIuration.Configuration.DoRun(data);
        }


        /// <summary>
        /// 获得所有接口列表
        /// </summary>
        /// <returns></returns>
        public static object getAllInterface()
        {
            return GZAPI.Core.BicycleAPIuration.Configuration.getAllInterface();

        }
    }
}
