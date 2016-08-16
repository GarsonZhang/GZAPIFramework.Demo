using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZAPI.Core.Models.Interface;

namespace GZAPIFramework.Biz.Config
{
    /// <summary>
    /// 获取请求成功后处理
    /// </summary>
    internal class ValidateRequest : GZAPI.Core.Interface.IValidateRequset
    {
        public delegate void EventLogHandle(string Phone, int interfaceCode, string Title, string json);

        public bool DoValidateRequset(IRequestModel request, IResponseModel response, bool ValidaToken)
        {
            ApiLog(request as Model.RequestModel);

            return true;
        }

        private void ApiLog(Model.RequestModel data)
        {
            if (data == null) return;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            string title = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
            Log.Add(title + System.Environment.NewLine + json);

            if (LogChanged != null)
            {
                LogChanged(data.Account, data.InterfaceCode, title, json);
            }

        }
        public event EventLogHandle LogChanged;
    }
}
