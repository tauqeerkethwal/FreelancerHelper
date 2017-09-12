
using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.Employee;
using System.Collections.Generic;

namespace Freelancer.Service
{
    public interface IEmployeeService
    {



        IEnumerable<Employee> GetEmployeeByEmployeeId(int EmployeeId);
        void CreateEmployee(Employee EmployeeAnimal);
        void SaveEmployee();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
        }

        #region 

        public IEnumerable<Employee> GetEmployeeByEmployeeId(int EmployeeId)
        {
            var Employee = employeeRepository.GetEmployeeByEmployeeId(EmployeeId);
            return Employee;
        }

        public void CreateEmployee(Employee employee)
        {
            employeeRepository.Add(employee);
        }

        public void SaveEmployee()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
