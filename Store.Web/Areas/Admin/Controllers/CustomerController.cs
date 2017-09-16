using Freelancer.Model.Models.CustomerKeys;
using Freelancer.Web.Areas.Admin.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            CustomerViewModel cv = new CustomerViewModel();
            List<CustomerKeys> li = new List<CustomerKeys>();
            li.Add(new CustomerKeys { Name = "0fa", CustomerId = "0" });

            cv.CustomerKeysList = li;

            return View(cv);
        }

        public ActionResult AddObject(int index)
        {
            return PartialView("_EmptyRow", new CustomerKeys { CustomerId = index.ToString() });
        }
        [HttpPost]
        public ActionResult Index(CustomerViewModel cv)
        {
            // CustomerViewModel cv = new CustomerViewModel();
            return View(cv);
        }
    }
}