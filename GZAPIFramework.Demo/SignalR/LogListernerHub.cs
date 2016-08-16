using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BicycleAPI.SignalR
{
    [HubName("logListernerHub")]
    public class LogListernerHub : Hub
    {
        //用户进入页面时执行的（连接操作）
        public void controllerConnected(string id, int listenerempty, string guid)
        {
            //进行编码，防止XSS攻击
            id = HttpUtility.HtmlEncode(id);
            bool b = listenerempty == 1;
            //新增目前使用者上线清单

            SignlarHandler.ConnectedIds[Context.ConnectionId] = new SignlarConnectionInfo(id, b, guid);
        }

        //发送信息给特定人
        public void sendMessage(string toid, int code, string title, string msg)
        {
            var lst = SignlarHandler.ConnectedIds.Where(p => p.Value.ID == toid).ToArray();
            foreach (var Client in lst)
            {
                Clients.Client(Client.Key).sendMessage(code, title, msg);
            }

        }
        //当使用者断线时执行
        public override Task OnDisconnected(bool stopCalled)
        {
            //当使用者离开时，移除在清单内的ConnectionId
            Clients.All.removeList(Context.ConnectionId);
            SignlarHandler.ConnectedIds.Remove(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }
    }


    //声明静态变量存储当前在线用户
    public static class SignlarHandler
    {
        public static Dictionary<string, SignlarConnectionInfo> ConnectedIds = new Dictionary<string, SignlarConnectionInfo>();
    }

    public class SignlarConnectionInfo
    {
        public string ID { get; set; }
        public string GUID { get; set; }
        public bool ListerEmpty { get; set; }

        public SignlarConnectionInfo(string sn, bool listerEmpty, string guid)
        {
            ID = sn;
            GUID = guid;
            ListerEmpty = listerEmpty;
        }
    }
}