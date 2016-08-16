using System;
using System.Collections.Generic;
using System.Linq;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// �ղ���  Object���ͷ���
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
