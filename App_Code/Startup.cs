using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSiteTI.Startup))]
namespace WebSiteTI
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
