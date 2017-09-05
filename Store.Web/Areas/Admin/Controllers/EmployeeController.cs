using AutoMapper;
using Freelancer.Model.Models.Employee;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
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
        public ActionResult Index(EmployeeViewModel employeeViewModel)
        {
            SelectList s = employeeViewModel.Type;

            EmployeeViewModel viewModelEmployee;
            Employee employee = new Employee();
            viewModelEmployee = Mapper.Map<Employee, EmployeeViewModel>(employee);
            viewModelEmployee.Gender = 3;
            viewModelEmployee.Type = _employeeTypeService.GetAllEmployeeTypesDropdown(employeeViewModel.TypeId.ToString());
            return View(employeeViewModel);

        }
    }
}