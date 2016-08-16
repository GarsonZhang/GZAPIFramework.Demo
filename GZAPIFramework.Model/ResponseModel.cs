using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Model
{
    /// <summary>
    /// 响应数据
    /// </summary>
    public class ResponseModel : GZAPI.Core.Models.Interface.IResponseModel
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int errCode { get; private set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        public string errMsg { get; private set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// 设置错误
        /// </summary>
        /// <param name="errcode"></param>
        /// <param name="errorMsg"></param>
        public void setError(int errcode, string errorMsg)
        {
            errCode = errcode;
            errMsg = errorMsg;
        }
    }
}
