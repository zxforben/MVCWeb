using System.Web.Mvc;

namespace WebAPIAngularJs.Controllers
{
    public class HomeController:Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
