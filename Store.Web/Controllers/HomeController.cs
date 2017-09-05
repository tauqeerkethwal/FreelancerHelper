using System.Web.Mvc;

namespace Freelancer.Web.Controllers
{
    public class HomeController : Controller
    {



        // GET: Home
        public ActionResult Index()
        {

            return RedirectToAction("Index", "admin/AdminHome");
        }


    }
}