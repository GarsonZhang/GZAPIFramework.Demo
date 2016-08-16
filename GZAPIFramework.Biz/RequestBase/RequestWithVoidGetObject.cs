using System;
using System.Collections.Generic;
using System.Linq;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// 空参数  Object类型返回
    /// </summary>
    /// <typeparam name="TResponseBody"></typeparam>
    public abstract class RequestWithVoidGetObject<TResponseBody>
        : GZAPI.Core.Biz.Base.RequestWithVoidGetObjectBase<Model.RequestModel, Model.ResponseModel, TResponseBody> where TResponseBody : class
    {
        public RequestWithVoidGetObject(Model.RequestModel data) : base(data)
        {
        }
    }
}
