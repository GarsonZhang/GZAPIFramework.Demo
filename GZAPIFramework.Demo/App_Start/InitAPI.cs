using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace GZAPIFramework.Demo
{
    public class InitAPI
    {
        public static void Init(HttpConfiguration config)
        {
            //HttpConfiguration config = GlobalConfiguration.Configuration;
            /*
             这种方式虽然可以实现功能，
             但是所有的conent negotiation还是会发生，这就会产生以下额外的开销了。
             因为，你已经知道要返回的结果了，也只想返回Json，其他的content negotiation都不需要了。
             */
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            //最好的方法是使用自定义的只返回Json Result的content negotiation代替Web Api中默认的content negotiation。
            /*使用此方法，对日期的处理等自定义不起作用
            var jsonFormatter = new JsonMediaTypeFormatter();
            //optional: set serializer settings here
            config.Services.Replace(typeof(IContentNegotiator), new JsonContentNegotiator(jsonFormatter));
            */


            // 解决json序列化时的循环引用问题
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            // 对 JSON 数据使用混合大小写。驼峰式,但是是javascript 首字母小写形式.
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            // 对 JSON 数据使用混合大小写。跟属性名同样的大小.输出
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new UnderlineSplitContractResolver();

        }
    }

    public class UnderlineSplitContractResolver : DefaultContractResolver
    {



        //解决API NULL 和时间格式问题
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties()
                   .Select(p =>
                   {
                       var jp = base.CreateProperty(p, memberSerialization);
                       if (jp.PropertyType == typeof(System.String))
                           jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                       if (jp.PropertyType.ToString().Contains("System.DateTime"))
                       {
                           jp.Converter = new DateConvert();
                       }
                       return jp;
                   }).ToList();
        }



    }

    public class DateConvert : IsoDateTimeConverter
    {
        public DateConvert()
        {
            //DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //serializer.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            //serializer.DateFormatString = "";
            //serializer.DateParseHandling = DateParseHandling.DateTimeOffset;
            //JsonSerializer f = new JsonSerializer();
            //base.WriteJson(writer, value, serializer);
            try
            {
                DateTime time = Convert.ToDateTime(value);
                DateTimeOffset fs = new DateTimeOffset(time);

                //var t1 = (fs.UtcDateTime - DateTime.Parse("1970-01-01"));
                //writer.WriteValue(t1.TotalMilliseconds);
                long trick = (fs.UtcTicks - 621355968000000000) / 10000;//毫秒值
                writer.WriteValue(trick);
            }
            catch (Exception ex)
            {
                writer.WriteValue(0);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }

    /// <summary>
    /// 解决返回json数据null问题
    /// </summary>
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }
        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target);

            if (_MemberInfo.PropertyType == typeof(string) && result == null)
                return "";

            return result;
        }
        public void SetValue(object target, object value)
        {
            _MemberInfo.SetValue(target, value);
        }
    }



    /// <summary>
    /// JSON格式返回
    /// </summary>
    public class JsonContentNegotiator : IContentNegotiator
    {
        private readonly JsonMediaTypeFormatter _jsonFormatter;
        public JsonContentNegotiator(JsonMediaTypeFormatter formatter)
        {
            _jsonFormatter = formatter;
        }
        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {
            var result = new ContentNegotiationResult(_jsonFormatter, new MediaTypeHeaderValue("application/json"));
            return result;
        }
    }
}