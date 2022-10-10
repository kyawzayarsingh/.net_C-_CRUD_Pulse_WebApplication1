using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(MVCCrudCodeFirst.Startup))]

namespace MVCCrudCodeFirst
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}
