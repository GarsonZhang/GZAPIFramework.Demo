using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZAPIFramework.Biz.RequestBase
{
    /// <summary>
    /// Object参数  空返回
    /// </summary>
    /// <typeparam name="TRequestBody"></typeparam>
    public abstract class RequestWithObjectGetVoid<TRequestBody> :
        GZAPI.Core.Biz.Base.RequestWithObjectGetVoidBase<Model.RequestModel, Model.ResponseModel, TRequestBody> where TRequestBody : class
    {
        public RequestWithObjectGetVoid(Model.RequestModel data) : base(data)
        {
        }
    }
}
