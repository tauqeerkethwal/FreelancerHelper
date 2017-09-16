using AutoMapper;
using Freelancer.Model.Models.Base;
using Freelancer.Model.Models.Employee;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
using Freelancer.Web.Areas.Admin.ViewModels.DataTable;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeTypeService _employeeTypeService;
        public EmployeeController(IEmployeeService _employeeService, IEmployeeTypeService _employeeTypeService)
        {
            this._employeeService = _employeeService;
            this._employeeTypeService = _employeeTypeService;
        }
        public ActionResult Index()
        {
            EmployeeViewModel viewModelEmployee;
            Employee employee = new Employee();
            viewModelEmployee = Mapper.Map<Employee, EmployeeViewModel>(employee);
            viewModelEmployee.Type = _employeeTypeService.GetAllEmployeeTypesDropdown();
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
                employeeViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(employeeFormViewModel.TypeId.ToString());
                employeeViewModel.TypeId = employeeFormViewModel.TypeId;
                _employeeService.SaveEmployee();
            }
            else
            {
                employeeViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(employeeFormViewModel.TypeId.ToString());
                employeeViewModel.TypeId = employeeViewModel.TypeId;
                employeeViewModel.Gender = employeeViewModel.Gender == null ? 3 : employeeViewModel.Gender;
            }

            return View(employeeViewModel);

        }


        public ActionResult edit(int Id, string BackUrl)
        {

            EmployeeViewModel viewModelEmployee;
            Employee employee = _employeeService.GetEmployee(Id);
            viewModelEmployee = Mapper.Map<Employee, EmployeeViewModel>(employee);
            viewModelEmployee.Type = _employeeTypeService.GetAllEmployeeTypesDropdown();
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
                employeeViewModel.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(model.TypeId.ToString());
                employeeViewModel.TypeId = employeeViewModel.TypeId;
                employeeViewModel.Gender = employeeViewModel.Gender == null ? 3 : employeeViewModel.Gender;
            }
            return View(employeeViewModel);



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