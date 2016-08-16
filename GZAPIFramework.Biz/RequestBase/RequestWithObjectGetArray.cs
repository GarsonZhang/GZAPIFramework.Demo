using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// Object参数  Array类型返回
    /// </summary>
    /// <typeparam name="TRequestBody"></typeparam>
    /// <typeparam name="TResponseBody"></typeparam>
    public abstract class RequestWithObjectGetArray<TRequestBody, TResponseBody>
        : GZAPI.Core.Biz.Base.RequestWithObjectGetArrayBase<Model.RequestModel, Model.ResponseModel, TRequestBody, TResponseBody> where TRequestBody : class where TResponseBody : class
    {
        public RequestWithObjectGetArray(Model.RequestModel data) : base(data)
        {
        }
    }
}
