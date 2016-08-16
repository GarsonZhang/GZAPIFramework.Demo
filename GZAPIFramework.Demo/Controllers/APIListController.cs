using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GZAPIFramework.Demo.Controllers
{
    public class APIListController : ApiController
    {
        [HttpGet]
        public object get()
        {
            return Biz.APIHelp.getAllInterface();
        }
    }
}
