using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZAPI.Core.Models.Interface;

namespace GZAPIFramework.Biz.Config
{
    /// <summary>
    /// 处理异常捕获
    /// </summary>
    internal class CatchAPIException : GZAPI.Core.Interface.ICatchAPIException
    {
        public void CatchException(IResponseModel data, Exception e)
        {
            
        }
    }
}
