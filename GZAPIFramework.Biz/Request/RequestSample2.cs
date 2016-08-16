using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZAPIFramework.Model;
using System.ComponentModel;

namespace GZAPIFramework.Biz.Request
{
    [Description("测试接口实例2")]
    public class RequestSample2 : RequestBase.RequestWithObjectGetObject<SmpleRequestBody2, SampleResponseBody2>
    {
        public RequestSample2(RequestModel data) : base(data)
        {
        }

        protected override bool CustomerValidateBodyData(SmpleRequestBody2 BodyData)
        {
            if (BodyData.Account != "garsonzhang")
            {
                base.setError(-1, "用户名必须是：garsonzhang");
                return false; 
            }
            return base.CustomerValidateBodyData(BodyData);
        }
        protected override SampleResponseBody2 ProcessingRequest()
        {
            SampleResponseBody2 data = new SampleResponseBody2();
            data.Account = RequestBodyData.Account;
            data.UserName = "GZFramework";
            data.Status = 1;
            return data;
        }
    }

    public class SmpleRequestBody2
    {
        [GZAPI.Core.DataValidate.StringNotNull(ErrorMsg = "Account不能为空")]
        [DefaultValue("garsonzhang")]
        [Description("用户账号2")]
        public string Account { get; set; }
        [GZAPI.Core.DataValidate.StringNotNull(ErrorMsg = "Pwd不能为空")]
        [DefaultValue("123456")]
        [Description("登录密码2")]
        public string Pwd { get; set; }
    }
    public class SampleResponseBody2
    {
        [Description("账号2")]
        [DefaultValue("garsonzhang")]
        public string Account { get; set; }

        [Description("用户名2")]
        [DefaultValue("GZ")]
        public string UserName { get; set; }

        [Description("用户状态 1 正常 2 被锁定")]
        [DefaultValue(1)]
        public int Status { get; set; }
    }
}
