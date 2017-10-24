using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Common;
using Freelancer.Model.Models.Base;
using Freelancer.Model.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Service
{
    public interface ICustomerService
    {

        Customer GetCustomer(Guid Id);
        void CreateCustomer(Customer customer);
        ListResult<CustomerListModel> GetAll(SearchParameters searchParameters, CustomerSearchModel model);
        void Update(Customer customer);
        bool CheckCustomerIdExist(string CustomerId);
        List<Customer> GetCustomerIdListAutoComplete(string customerId);
        void SaveCustomer();
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerKeysService customerKeysService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeTypeRepository employeeTypeRepository;

        public CustomerService(ICustomerRepository customerRepository, IEmployeeTypeRepository employeeTypeRepository, ICustomerKeysService customerKeysService, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.customerKeysService = customerKeysService;
            this.unitOfWork = unitOfWork;
            this.employeeTypeRepository = employeeTypeRepository;
        }
        public void Update(Customer customer)
        {

            customerRepository.Update(customer);
        }
        #region 
        public Customer GetCustomer(Guid Id)
        {
            var Customer = customerRepository.GetMany(x => x.Id == Id).FirstOrDefault();

            return Customer;
        }

        public List<Customer> GetCustomerIdListAutoComplete(string customerId)
        {

            var Customer = customerRepository.GetMany(x => x.CustomerId.StartsWith(customerId)).ToList();


            return Customer;
        }
        public bool CheckCustomerIdExist(string CustomerId)
        {
            return customerRepository.GetMany(x => x.CustomerId == CustomerId).ToList().Count > 0 ? true : false;
        }

        public void CreateCustomer(Customer customer)
        {
            customerRepository.Add(customer);


        }

        public void SaveCustomer()
        {
            unitOfWork.Commit();
        }
        public CustomerListModel ConvertToModel(Customer item)
        {
            return new CustomerListModel
            {
                Id = item.Id,
                Active = item.Active,
                del = item.del,
                Address = item.Street + ", " + item.PostCode + " " + item.City,
                Email = item.Email,
                CustomerId = item.CustomerId,
                HourlyRate = item.HourlyRate,
                Name = item.Name,
                Tlf = item.Tlf,
                Type = employeeTypeRepository.GetById(item.TypeId).Name,
                CVR = item.CVR,
                EAN = item.EAN,
                CustomerKeysList = customerKeysService.GetCustomerKeys(item.Id).ToList()
            };
        }

        public IEnumerable<CustomerListModel> ConvertToModel(IEnumerable<Customer> item)
        {

            return item.Select(x => ConvertToModel(x));

        }
        public ListResult<CustomerListModel> GetAll(SearchParameters searchParameters, CustomerSearchModel model)
        {
            try
            {
                if (searchParameters == null)
                {
                    throw new NullReferenceException("Search Parameters Cannot be null");
                }

                var items = customerRepository.GetAll().AsQueryable();

                // Filter records using method implemented in drive class.
                items = FilterRecords(items, searchParameters, model);

                // Get total count of Filtered Records
                var totalRecords = items.Count();


                // Apply Sort Order
                items = CommonHelper.ApplyCustomerPaging(searchParameters, items);

                // Return Result
                var returnObject = new ListResult<CustomerListModel>();

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

        private IQueryable<Customer> FilterOnSearchText(IQueryable<Customer> items, SearchParameters searchParameters)
        {


            if (!string.IsNullOrEmpty(searchParameters.SearchText))
            {
                items = items.Where(x =>
                                        x.Name.ToLower().Contains(searchParameters.SearchText.ToLower())

                                   );
            }


            return items;
        }

        public IQueryable<Customer> FilterRecords(IQueryable<Customer> items, SearchParameters searchParameters, CustomerSearchModel model)
        {


            items = FilterOnSearchText(items, searchParameters);

            return items;

        }
        #endregion
    }
}
