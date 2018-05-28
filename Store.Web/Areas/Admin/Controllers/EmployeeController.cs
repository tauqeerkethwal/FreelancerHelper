using AutoMapper;
using Freelancer.Model.Models.Base;
using Freelancer.Model.Models.Employee;
using Freelancer.Model.Models.EmployeePet;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
using Freelancer.Web.Areas.Admin.ViewModels.DataTable;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Freelancer.Web.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        private readonly IEmployeeService _employeeService;
        private readonly IPetService _petService;
        private readonly IEmployeeTypeService _employeeTypeService;
        private readonly IEmployeePetService _employeePetService;
        public EmployeeController(IEmployeeService _employeeService, IEmployeeTypeService _employeeTypeService, IPetService _petService, IEmployeePetService _employeePetService)
        {
            this._employeeService = _employeeService;
            this._employeeTypeService = _employeeTypeService;
            this._petService = _petService;
            this._employeePetService = _employeePetService;
        }
        public ActionResult Index()
        {
            EmployeeViewModel viewModelEmployee;
            Employee employee = new Employee();
            viewModelEmployee = Mapper.Map<Employee, EmployeeViewModel>(employee);
           // viewModelEmployee.Type = _employeeTypeService.GetAllEmployeeTypesDropdown();
            viewModelEmployee.PetList = _petService.GetAllPetDropdown();
            return View(viewModelEmployee);

        }


        [HttpPost]
        public ActionResult Index(EmployeeFormViewModel employeeFormViewModel)
        {

            Employee employee = Mapper.Map<EmployeeFormViewModel, Employee>(employeeFormViewModel);
            var employeeViewModel = Mapper.Map<Employee, EmployeeViewModel>(employee);
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                _employeeService.SaveEmployee();
                //employeeViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(employeeFormViewModel.TypeId.ToString());
                //employeeViewModel.TypeId = employeeFormViewModel.TypeId;
                _employeePetService.AddNewEmployeePets(_employeeService.GetMaxEmployeeId(), employeeFormViewModel.PetCollection);
                _employeePetService.SaveEmployeePet();
                employeeViewModel.PetList = _petService.GetAllPetDropdown();
                employeeViewModel.PetId = employeeFormViewModel.PetId;
                return RedirectToAction("index");
            }
            else
            {
                //employeeViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(employeeFormViewModel.TypeId.ToString());
                //employeeViewModel.TypeId = employeeViewModel.TypeId;
                //employeeViewModel.Gender = employeeViewModel.Gender == null ? 3 : employeeViewModel.Gender;
                employeeViewModel.PetList = _petService.GetAllPetDropdown();
                employeeViewModel.PetId = employeeFormViewModel.PetId;

            }

            return View(employeeViewModel);

        }


        public ActionResult edit(int Id, string BackUrl)
        {

            EmployeeViewModel viewModelEmployee;
            Employee employee = _employeeService.GetEmployee(Id);
            viewModelEmployee = Mapper.Map<Employee, EmployeeViewModel>(employee);
           // viewModelEmployee.Type = _employeeTypeService.GetAllEmployeeTypesDropdown();
            return View(viewModelEmployee);
        }

        [HttpPost]

        public ActionResult edit(EmployeeFormViewModel model)
        {
            Employee employee = Mapper.Map<EmployeeFormViewModel, Employee>(model);
            var employeeViewModel = Mapper.Map<Employee, EmployeeViewModel>(employee);

            if (ModelState.IsValid)
            {

                _employeeService.Update(employee);
                _employeeService.SaveEmployee();
                return RedirectToAction("index", "Employee");
            }
            else
            {
                //employeeViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(model.TypeId.ToString());
                //employeeViewModel.TypeId = employeeViewModel.TypeId;
                ////employeeViewModel.Gender = employeeViewModel.Gender == null ? 3 : employeeViewModel.Gender;
            }
            return View(employeeViewModel);



        }


        [HttpPost]
        public ActionResult AddEmployeePet(int index, List<EmployeePet> PetCollection)
        {
            List<EmployeePet> employeePetList = new List<EmployeePet>();
            employeePetList.Add(new EmployeePet());
            Tuple<List<EmployeePet>, int> tuple = new Tuple<List<EmployeePet>, int>(PetCollection == null ? employeePetList : PetCollection, index);
            return PartialView("_EmployeePetRow", tuple);
        }
        [HttpPost]
        public ActionResult RemoveObjectPet(int index, List<EmployeePet> PetCollection)
        {
            Tuple<List<EmployeePet>, int> tuple = new Tuple<List<EmployeePet>, int>(PetCollection, index);
            return PartialView("_EmployeePetRow", tuple);
        }

        [HttpPost]

        public bool deleteUndelete(int id, bool value)
        {
            if (id != null)
            {
                var employee = _employeeService.GetEmployee(id);
                employee.del = value;
                _employeeService.Update(employee);
                _employeeService.SaveEmployee();
            }

            return true;
        }
        [HttpPost]

        public bool ActiveInActive(int id, bool value)
        {
            if (id != null)
            {
                var employee = _employeeService.GetEmployee(id);
                employee.Active = value;
                _employeeService.Update(employee);
                _employeeService.SaveEmployee();
            }

            return true;
        }
        [HttpPost]
        public ActionResult LoadAllData(DTParameters param, EmployeeSearchModel model)
        {
            var SearchValue = Request.Form.GetValues("search[value]")[0];
            var parameters = param.GetSearchParameters();
            parameters.SearchText = SearchValue;

            var listResult = _employeeService.GetAll(parameters, model);

            var result = GetListResult<EmployeeListModel>(param, listResult);

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