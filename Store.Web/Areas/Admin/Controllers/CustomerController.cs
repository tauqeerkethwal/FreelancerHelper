using Freelancer.Model.Models.CustomerKeys;
using Freelancer.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.Controllers
{
    public class SelectedInterventionsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public System.DateTime ToDoBefore { get; set; }

        public System.DateTime PlannedDate { get; set; }
    }
    public class CustomerController : Controller
    {
        // GET: Admin/Customer
        public ActionResult Index()
        {
            CustomerViewModel cv = new CustomerViewModel();
            List<CustomerKeys> li = new List<CustomerKeys>();
            li.Add(new CustomerKeys { Name = "0fa", CustomerId = "0", KeyId = 0 });

            cv.CustomerKeysList = li;

            return View(cv);
        }
        [HttpPost]
        public ActionResult AddObject(int index, List<CustomerKeys> CustomerKeysList)
        {
            Tuple<List<CustomerKeys>, int> tuple = new Tuple<List<CustomerKeys>, int>(CustomerKeysList, index);
            return PartialView("_EmptyRow", tuple);
        }
        [HttpPost]
        public ActionResult RemoveObject(int index, List<CustomerKeys> CustomerKeysList)
        {
            Tuple<List<CustomerKeys>, int> tuple = new Tuple<List<CustomerKeys>, int>(CustomerKeysList, index);
            return PartialView("_DeleteRow", tuple);
        }
        //public ActionResult AddObject(int index)
        //{
        //    return PartialView("_EmptyRow", new CustomerKeys { CustomerId = index.ToString() });
        //}
        [HttpPost]
        public ActionResult Index(CustomerViewModel cv)
        {
            // CustomerViewModel cv = new CustomerViewModel();
            return View(cv);
        }
    }
}