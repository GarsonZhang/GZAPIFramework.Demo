using System;
using System.Collections.Generic;
using System.Linq;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// �ղ����շ���
    /// </summary>
    public abstract class RequestWithVoidGetVoid
        : GZAPI.Core.Biz.Base.RequestWithVoidGetVoidBase<Model.RequestModel, Model.ResponseModel>
    {
        public RequestWithVoidGetVoid(Model.RequestModel data) : base(data)
        {
        }
    }
}
