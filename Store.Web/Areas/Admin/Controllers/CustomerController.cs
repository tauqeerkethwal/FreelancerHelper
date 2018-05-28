using AutoMapper;
using Freelancer.Model.Models.Base;
using Freelancer.Model.Models.Customer;
using Freelancer.Model.Models.CustomerKeys;
using Freelancer.Model.Models.CustomerPet;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
using Freelancer.Web.Areas.Admin.ViewModels.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Freelancer.Web.Areas.Admin.Controllers
{

    public class CustomerController : Controller

    {
        private readonly IPetService _petService;
        private readonly ICustomerPetService _customerPetService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeTypeService _employeeTypeService;
        private readonly ICustomerKeysService _customerKeysService;
        public CustomerController(IPetService _petService, ICustomerKeysService _customerKeysService, ICustomerService _customerService, IEmployeeTypeService _employeeTypeService, ICustomerPetService _customerPetService)
        {
            this._petService = _petService;
            this._customerService = _customerService;
            this._employeeTypeService = _employeeTypeService;
            this._customerPetService = _customerPetService;
            this._customerKeysService = _customerKeysService;

        }

        [HttpPost]
        public JsonResult AutoCompleteCustomerids(string Prefix)
        {
            //Note : you can bind same list from database  

            //Searching records from list using LINQ query  
            var CustomerIds = _customerService.GetCustomerIdListAutoComplete(Prefix);
            return Json(CustomerIds, JsonRequestBehavior.AllowGet);
        }
        public CustomerViewModel loadIndexPage()
        {
            CustomerViewModel customerViewModel;
            Customer customer = new Customer();
            customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            customerViewModel.PetList = _petService.GetAllPetDropdown("0");
            ////customerViewModel.PetList = _petService.GetAllPetDropdown();
            ////customerViewModel.PetId = customerFormViewModel.PetId;
            customerViewModel.PetCollection = _customerPetService.GetPetsByCustomerId(Guid.NewGuid()).ToList();
            customerViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown();
            return customerViewModel;
        }
        // GET: Admin/Customer
        public ActionResult Index()
        {

            CustomerViewModel customerViewModel = loadIndexPage();
            //Customer customer = new Customer();
            //customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            //customerViewModel.PetList = _petService.GetAllPetDropdown();
            //customerViewModel.PetCollection = _customerPetService.GetPetsByCustomerId(Guid.NewGuid()).ToList();
            //customerViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Index(CustomerFormViewModel customerFormViewModel)
        {

            Customer customer = Mapper.Map<CustomerFormViewModel, Customer>(customerFormViewModel);
            var customerViewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
            if (ModelState.IsValid && customerFormViewModel.Paymenttype != -1)
            {
                if (_customerService.CheckCustomerIdExist(customerFormViewModel.CustomerId))
                {
                    customerViewModel.PetList = _petService.GetAllPetDropdown();
                    customerViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(customerFormViewModel.TypeId.ToString());
                    customerViewModel.TypeId = customerViewModel.TypeId;
                    //customerViewModel.Gender = customerFormViewModel.Gender == null ? 3 : customerFormViewModel.Gender;
                    ModelState.AddModelError("CustomerId", "already exist");
                }
                else
                {
                    customer.Id = Guid.NewGuid();
                    _customerService.CreateCustomer(customer);
                    _customerKeysService.AddNewKeys(customer.Id, customerFormViewModel.CustomerKeysList);
                    _customerPetService.AddNewCustomerPets(customer.Id, customerFormViewModel.PetCollection);
                    customerViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(customerFormViewModel.TypeId.ToString());
                    customerViewModel.TypeId = customerFormViewModel.TypeId;
                    _customerService.SaveCustomer();
                    //customerViewModel.PetList = _petService.GetAllPetDropdown();
                    //customerViewModel.PetId = customerFormViewModel.PetId;
                    return RedirectToAction("index");
                }
            }
            else
            {
                customerViewModel.PetList = _petService.GetAllPetDropdown();
                customerViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(customerFormViewModel.TypeId.ToString());
                customerViewModel.TypeId = customerViewModel.TypeId;
                customerViewModel.CustomerKeysList = customerFormViewModel.CustomerKeysList;
                customerViewModel.PetCollection = customerFormViewModel.PetCollection;
                customerViewModel.Paymenttype = customerFormViewModel.Paymenttype;
                ModelState.AddModelError("Paymenttype", "Select Paymenttype");
                // customerViewModel.Gender = customerViewModel.Gender == null ? 3 : customerViewModel.Gender;
            }



            return View(customerViewModel);

        }

        public ActionResult edit(string Id, string BackUrl)
        {

            CustomerViewModel viewModelCustomer;
            Customer customer = _customerService.GetCustomer(Guid.Parse(Id));
            viewModelCustomer = Mapper.Map<Customer, CustomerViewModel>(customer);
            viewModelCustomer.PetCollection = _customerPetService.GetPetsByCustomerId(Guid.Parse(Id)).ToList();
            viewModelCustomer.CustomerKeysList = _customerKeysService.GetCustomerKeys(Guid.Parse(Id)).ToList();
            viewModelCustomer.Type = _employeeTypeService.GetAllEmployeeTypesDropdown();
            viewModelCustomer.PetList = _petService.GetAllPetDropdown();
            // viewModelCustomer.PetId = customerFormViewModel.PetId;
            return View(viewModelCustomer);
        }

        [HttpPost]

        public ActionResult edit(CustomerFormViewModel customerFormViewModel)
        {
            Customer customer = Mapper.Map<CustomerFormViewModel, Customer>(customerFormViewModel);
            var viewModelCustomer = Mapper.Map<Customer, CustomerViewModel>(customer);

            if (ModelState.IsValid && customerFormViewModel.Paymenttype != -1)
            {

                {
                    _customerService.Update(customer);

                    _customerKeysService.AddNewKeys(customer.Id, customerFormViewModel.CustomerKeysList);
                    _customerPetService.AddNewCustomerPets(customer.Id, customerFormViewModel.PetCollection);
                    _customerService.SaveCustomer();
                    return RedirectToAction("index", "customer");
                }

            }
            else
            {
                viewModelCustomer.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(customerFormViewModel.TypeId.ToString());
                viewModelCustomer.TypeId = customerFormViewModel.TypeId;
                viewModelCustomer.PetCollection = customerFormViewModel.PetCollection;
                viewModelCustomer.CustomerKeysList = customerFormViewModel.CustomerKeysList;
                viewModelCustomer.Gender = customerFormViewModel.Gender == null ? 3 : customerFormViewModel.Gender;
                viewModelCustomer.PetList = _petService.GetAllPetDropdown();
                viewModelCustomer.PetId = customerFormViewModel.PetId;
                ModelState.AddModelError("Paymenttype", "Select Paymenttype");
            }
            return View(viewModelCustomer);



        }


        [HttpPost]
        public ActionResult AddCustmerPet(int index, List<CustomerPet> PetCollection)
        {
            List<CustomerPet> customerPetList = new List<CustomerPet>();
            customerPetList.Add(new CustomerPet());
            Tuple<List<CustomerPet>, int> tuple = new Tuple<List<CustomerPet>, int>(PetCollection == null ? customerPetList : PetCollection, index);
            return PartialView("_CustomerPetRow", tuple);
        }
        [HttpPost]
        public ActionResult RemoveObjectPet(int index, List<CustomerPet> PetCollection)
        {
            Tuple<List<CustomerPet>, int> tuple = new Tuple<List<CustomerPet>, int>(PetCollection, index);
            return PartialView("_CustomerPetRow", tuple);
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
        [HttpPost]

        public bool deleteUndelete(string id, bool value)
        {
            if (id != null)
            {
                var customer = _customerService.GetCustomer(Guid.Parse(id));
                customer.del = value;
                _customerService.Update(customer);
                _customerService.SaveCustomer();
            }

            return true;
        }
        [HttpPost]

        public bool ActiveInActive(string id, bool value)
        {
            if (id != null)
            {
                var employee = _customerService.GetCustomer(Guid.Parse(id));
                employee.Active = value;
                _customerService.Update(employee);
                _customerService.SaveCustomer();
            }

            return true;
        }
        [HttpPost]
        public ActionResult LoadAllData(DTParameters param, CustomerSearchModel model)
        {
            var SearchValue = Request.Form.GetValues("search[value]")[0];
            var parameters = param.GetSearchParameters();
            parameters.SearchText = SearchValue;

            var listResult = _customerService.GetAll(parameters, model);

            var result = GetListResult<CustomerListModel>(param, listResult);

            return Json(result);

        }
        protected DTResult<T> GetListResult<T>(DTParameters param, ListResult<T> listResult)
        {


            DTResult<T> result = new DTResult<T>
            {
                draw = param.Draw,
                data = listResult.ResultData,
                recordsFiltered = listResult.TotalRecords,
                recordsTotal = listResult.TotalRecords,

            };

            return result;

        }
    }
}