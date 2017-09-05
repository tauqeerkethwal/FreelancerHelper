using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.EmployeeType;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Freelancer.Service
{
    public interface IEmployeeTypeService
    {
        IEnumerable<EmployeeType> GetAllEmployeeTypes(string name = null);
        SelectList GetAllEmployeeTypesDropdown(string Value = null);

        EmployeeType GetEmployeeTypes(int id);
        IEnumerable<EmployeeType> GetEmployeeTypes(string name);
        void CreateEmployeeType(EmployeeType employeeTypes);
        void SaveCategory();
    }

    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository employeeTypeRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeTypeService(IEmployeeTypeRepository employeeTypeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeTypeRepository = employeeTypeRepository;
            this.unitOfWork = unitOfWork;
        }

        #region 
        public SelectList GetAllEmployeeTypesDropdown(string Value = null)
        {
            if (string.IsNullOrEmpty(Value))
            {
                return new SelectList(employeeTypeRepository.GetAll().Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.TypeId.ToString()
                }).ToList(), "Value", "Text"); ;

            }

            else
            {
                return new SelectList(employeeTypeRepository.GetAll().Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.TypeId.ToString()
                }).ToList(), "Value", "Text", Value);
            }
        }
        public IEnumerable<EmployeeType> GetAllEmployeeTypes(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return employeeTypeRepository.GetAll();
            else
                return employeeTypeRepository.GetAll().Where(c => c.Name == name);
        }

        public EmployeeType GetEmployeeTypes(int id)
        {
            var employeeType = employeeTypeRepository.GetById(id);
            return employeeType;
        }

        public IEnumerable<EmployeeType> GetEmployeeTypes(string name)
        {
            var employeeType = employeeTypeRepository.GetEmployeeTypesByName(name);
            return employeeType;
        }

        public void CreateEmployeeType(EmployeeType employeeType)
        {
            employeeTypeRepository.Add(employeeType);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
