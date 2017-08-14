using System.Web.Mvc;

namespace Bleum.Web.Controllers
{
    public class HelloChengDuController : Controller
    {
        // GET: HelloChengDu
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloChengDu/Welcome/  
        public ActionResult Welcome(string name, int numTimes=1)
        {
            ViewBag.Message = "Hello " + name;
            ViewBag.NumTimes = numTimes;
            return View();
            //return HttpUtility.HtmlEncode("Hello "+ name+ ", Numtimes is: "+numTimes);
        }
    }
}