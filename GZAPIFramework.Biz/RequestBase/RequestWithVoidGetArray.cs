using GZAPI.Core.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// �ղ��� Arry���ͷ���
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
