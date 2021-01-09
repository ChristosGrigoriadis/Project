using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UberTappDeveloping.Startup))]
namespace UberTappDeveloping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
