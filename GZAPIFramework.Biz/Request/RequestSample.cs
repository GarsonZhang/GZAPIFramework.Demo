using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZAPIFramework.Model;
using System.ComponentModel;

namespace GZAPIFramework.Biz.Request
{
    [Description("测试接口实例1")]
    public class RequestSample : RequestBase.RequestWithObjectGetObject<SmpleRequestBody, SampleResponseBody>
    {
        public RequestSample(RequestModel data) : base(data)
        {
        }

        protected override bool CustomerValidateBodyData(SmpleRequestBody BodyData)
        {
            if (BodyData.Account != "garsonzhang")
            {
                base.setError(-1, "用户名必须是：garsonzhang");
                return false;
            }
            return base.CustomerValidateBodyData(BodyData);
        }
        protected override SampleResponseBody ProcessingRequest()
        {
            SampleResponseBody data = new SampleResponseBody();
            data.Account = RequestBodyData.Account;
            data.UserName = "GZFramework";
            data.Status = 1;

            return data;
        }
    }

    public class SmpleRequestBody
    {
        [GZAPI.Core.DataValidate.StringNotNull(ErrorMsg = "Account不能为空")]
        [DefaultValue("garsonzhang")]
        [Description("用户账号")]
        public string Account { get; set; }
        [GZAPI.Core.DataValidate.StringNotNull(ErrorMsg = "Pwd不能为空")]
        [DefaultValue("123456")]
        [Description("登录密码")]
        public string Pwd { get; set; }
    }
    public class SampleResponseBody
    {
        [Description("账号")]
        [DefaultValue("garsonzhang")]
        public string Account { get; set; }

        [Description("用户名")]
        [DefaultValue("GZ")]
        public string UserName { get; set; }

        [Description("用户状态 1 正常 2 被锁定")]
        [DefaultValue(1)]
        public int Status { get; set; }
    }
}
