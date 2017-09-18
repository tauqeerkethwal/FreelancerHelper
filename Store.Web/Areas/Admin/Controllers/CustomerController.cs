using AutoMapper;
using Freelancer.Model.Models.CustomerPet;
using Freelancer.Model.Models.Customer;
using Freelancer.Model.Models.CustomerKeys;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
namespace Freelancer.Web.Areas.Admin.Controllers
{

    public class CustomerController : Controller

    {
        private readonly IPetService _petService;
        private readonly ICustomerPetService _customerPetService;
        public CustomerController(IPetService _petService, ICustomerPetService _customerPetService)
        {
            this._petService = _petService;
            this._customerPetService = _customerPetService;
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {

            CustomerViewModel customerViewModel;
            Customer customer = new Customer();
            customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            customerViewModel.PetList = _petService.GetAllPetDropdown();
            CustomerPetViewModel customerPetViewModel;
           IEnumerable< CustomerPet > customerPet = _customerPetService.GetPetsByCustomerId(Guid.NewGuid());
            
            customerViewModel.PetCollection = _customerPetService.GetPetsByCustomerId(Guid.NewGuid()).ToList();


            //cv.CustomerKeysList = li;

            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult AddObject(int index, List<CustomerKeys> CustomerKeysList)
        {
            List<CustomerKeys> customerKeyList = new List<CustomerKeys>();
            customerKeyList.Add(new CustomerKeys());
            Tuple<List<CustomerKeys>, int> tuple = new Tuple<List<CustomerKeys>, int>(CustomerKeysList == null ? customerKeyList : CustomerKeysList, index);
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