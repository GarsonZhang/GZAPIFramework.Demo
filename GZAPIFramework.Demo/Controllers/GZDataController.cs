using BicycleAPI.SignalR;
using GZAPIFramework.Biz;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GZAPIFramework.Demo.Controllers
{
    public class GZDataController : ApiController
    {
        [HttpGet]
        public object get()
        {
            return "API is Success!!";
        }

        [HttpPost]
        public object Post(Model.RequestModel request)
        {
            if (request != null)
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                string title = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                Log.Add(title + System.Environment.NewLine + json);
                SendSignalR(request.Account, request.InterfaceCode, title, json);
            }
            return Biz.APIHelp.RunInterface(request);
        }

        private void SendSignalR(string Phone, int interfaceCode, string Title, string json)
        {
            if (!String.IsNullOrEmpty(Phone))
            {
                var lst = SignlarHandler.ConnectedIds.Where(p => p.Value.ID == Phone || p.Value.ID == "*").ToArray();
                foreach (var Client in lst)
                {
                    GlobalHost.ConnectionManager.GetHubContext<LogListernerHub>().Clients.Client(Client.Key).sendMessage(interfaceCode, Title, json);
                }
            }
            else
            {
                var emptys = SignlarHandler.ConnectedIds.Where(p => p.Value.ListerEmpty == true).ToArray();
                foreach (var Client in emptys)
                {
                    GlobalHost.ConnectionManager.GetHubContext<LogListernerHub>().Clients.Client(Client.Key).sendMessage(interfaceCode, Title, json);
                }
            }
        }

    }
}
