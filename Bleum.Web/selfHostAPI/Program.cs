using System;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace selfHostAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";
            // 启动 OWIN host
            WebApp.Start<Startup>(url: baseAddress);
            Console.WriteLine("程序已启动,按任意键退出");
            Console.ReadLine();
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                }
            );
            appBuilder.UseWebApi(config);
        }
    }

    public class UserController : ApiController
    {
        [HttpPost, HttpGet]
        public string PostGetInfo()
        {
            return "API测试地址";
        }
    }
}
