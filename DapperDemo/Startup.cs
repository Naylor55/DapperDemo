using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DapperDemo.Startup))]
namespace DapperDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
