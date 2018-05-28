using Freelancer.Core.Extensions;
using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Common;
using Freelancer.Model.Models.Base;
using Freelancer.Model.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Freelancer.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetActiveEmplyee();
        Employee GetEmployee(int EmployeeId);
        SelectList GetAllEmployeeDropdown(string Value = null);
        void CreateEmployee(Employee EmployeeAnimal);
        ListResult<EmployeeListModel> GetAll(SearchParameters searchParameters, EmployeeSearchModel model);
        void Update(Employee employee);
        int GetMaxEmployeeId();
        void SaveEmployee();
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeTypeRepository employeeTypeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeTypeRepository employeeTypeRepository, IUnitOfWork unitOfWork)
        {
            this.employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
            this.employeeTypeRepository = employeeTypeRepository;
        }
        public SelectList GetAllEmployeeDropdown(string Value = null)
        {
            if (string.IsNullOrEmpty(Value))
            {
                var listItems = employeeRepository.GetMany(x => x.del == false && x.Active == true).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.EmployeeId.ToString()
                }).ToList();


                return new SelectList(listItems, "Value", "Text");


            }

            else
            {
                var listItems = employeeRepository.GetMany(x => x.del == false).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.EmployeeId.ToString()
                }).ToList();


                return new SelectList(listItems, "Value", "Text", Value);

            }
        }
        public IEnumerable<Employee> GetActiveEmplyee()
        {
            return employeeRepository.GetMany(x => x.del == false && x.Active == true);
        }
        public void Update(Employee employee)
        {

            employeeRepository.Update(employee);
        }
        #region 
        public Employee GetEmployee(int EmployeeId)
        {
            var Employee = employeeRepository.GetById(EmployeeId);
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
        public EmployeeListModel ConvertToModel(Employee item)
        {
            return new EmployeeListModel
            {
                Active = item.Active,
                Car = item.Car,
                del = item.del,
                Address = item.Street + ", " + item.PostCode + " " + item.City,
                DateCreated = DateExtensions.DisplayFormattedDateTime(item.DateCreated),
                DrivingLicence = item.DrivingLicence,
                Email = item.Email,
                EmployeeId = item.EmployeeId,
                HourlyPay = item.HourlyPay,
                Name = item.Name,
                Tlf = item.Tlf,
               // Type = employeeTypeRepository.GetById(item.TypeId).Name



            };
        }

        public IEnumerable<EmployeeListModel> ConvertToModel(IEnumerable<Employee> item)
        {

            return item.Select(x => ConvertToModel(x));

        }

        public int GetMaxEmployeeId()
        {
            if (employeeRepository.GetAll().Count() == 0)
                return 0;
            else
                return employeeRepository.GetAll().Max(x => x.EmployeeId);

        }
        public ListResult<EmployeeListModel> GetAll(SearchParameters searchParameters, EmployeeSearchModel model)
        {
            try
            {
                if (searchParameters == null)
                {
                    throw new NullReferenceException("Search Parameters Cannot be null");
                }

                var items = employeeRepository.GetAll().AsQueryable();

                // Filter records using method implemented in drive class.
                items = FilterRecords(items, searchParameters, model);

                // Get total count of Filtered Records
                var totalRecords = items.Count();


                // Apply Sort Order
                items = CommonHelper.ApplyEmployeePaging(searchParameters, items);

                // Return Result
                var returnObject = new ListResult<EmployeeListModel>();

                returnObject.TotalRecords = totalRecords;

                returnObject.ResultData = ConvertToModel(items).ToList(); ;
                //add row number
                int r = searchParameters.PageStart;
                returnObject.ResultData.ForEach(i => i.SNo = ++r);
                return returnObject;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private IQueryable<Employee> FilterOnSearchText(IQueryable<Employee> items, SearchParameters searchParameters)
        {


            if (!string.IsNullOrEmpty(searchParameters.SearchText))
            {
                items = items.Where(x =>
                                        x.Name.ToLower().Contains(searchParameters.SearchText.ToLower())

                                   );
            }


            return items;
        }

        public IQueryable<Employee> FilterRecords(IQueryable<Employee> items, SearchParameters searchParameters, EmployeeSearchModel model)
        {


            items = FilterOnSearchText(items, searchParameters);

            return items;

        }
        #endregion
    }
}
