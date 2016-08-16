using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GZAPIFramework.Biz.Config
{
    public class GZAPIConfig
    {
        /// <summary>
        /// 初始化API框架
        /// </summary>
        public static void InitConfig()
        {

            GZAPI.Core.BicycleAPIuration.Configure(Config =>
            {
                Config.SetInfaceCodeList(new InterfaceCodeList());
                Config.SetValidateToken(new ValidateRequest());
                Config.SetCathException(new CatchAPIException());

                //设置请求模型
                Config.SetGenerateRequestModel(() =>
                {
                    return new Model.RequestModel();
                });

                //设置响应模型
                Config.SetGenerateResponseModel(() =>
                {
                    return new Model.ResponseModel();
                });
            });
        }
    }
}
