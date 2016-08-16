using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// Array参数 空返回
    /// </summary>
    /// <typeparam name="TRequestBody"></typeparam>
    public abstract class RequestWithArrayGetVoid<TRequestBody>
        : GZAPI.Core.Biz.Base.RequestWithArrayGetVoidBase<Model.RequestModel, Model.ResponseModel, TRequestBody> where TRequestBody : class
    {
        public RequestWithArrayGetVoid(Model.RequestModel data) : base(data)
        {
        }
    }
}
