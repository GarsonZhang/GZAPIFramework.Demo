using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// Array参数 Object类型返回
    /// </summary>
    /// <typeparam name="TRequestBody"></typeparam>
    /// <typeparam name="TResponseBody"></typeparam>
    public abstract class RequestWithArrayGetObject<TRequestBody, TResponseBody> :
        GZAPI.Core.Biz.Base.RequestWithArrayGetObjectBase<Model.RequestModel, Model.ResponseModel, TRequestBody, TResponseBody> where TRequestBody : class where TResponseBody : class
    {
        public RequestWithArrayGetObject(Model.RequestModel data) : base(data)
        {
        }
    }
}
