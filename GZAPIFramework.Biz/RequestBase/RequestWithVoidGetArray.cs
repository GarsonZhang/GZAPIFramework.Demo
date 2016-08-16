using GZAPI.Core.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// 空参数 Arry类型返回
    /// </summary>
    /// <typeparam name="TResponseBody"></typeparam>
    public abstract class RequestWithVoidGetArray<TResponseBody> :
        GZAPI.Core.Biz.Base.RequestWithVoidGetArrayBase<Model.RequestModel, Model.ResponseModel, TResponseBody> 
        where TResponseBody : class
    {
        public RequestWithVoidGetArray(Model.RequestModel data) : base(data)
        {
        }
    }
}
