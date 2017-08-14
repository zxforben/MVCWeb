using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAPIAngularJs.Startup))]
namespace WebAPIAngularJs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}