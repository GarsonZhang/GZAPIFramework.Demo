using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(GZAPIFramework.Demo.SignalR.BicycleStartup))]
namespace GZAPIFramework.Demo.SignalR
{
    public class BicycleStartup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}