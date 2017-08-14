using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bleum.Web.Startup))]
namespace Bleum.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
