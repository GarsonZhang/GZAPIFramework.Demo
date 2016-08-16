using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// Object参数  Object类型返回
    /// </summary>
    /// <typeparam name="TRequestBody"></typeparam>
    /// <typeparam name="TResponseBody"></typeparam>
    public abstract class RequestWithObjectGetObject<TRequestBody, TResponseBody>
        : GZAPI.Core.Biz.Base.RequestWithObjectGetObjectBase<Model.RequestModel, Model.ResponseModel, TRequestBody, TResponseBody> where TRequestBody : class where TResponseBody : class
    {
        public RequestWithObjectGetObject(Model.RequestModel data) : base(data)
        {
        }
    }
}
