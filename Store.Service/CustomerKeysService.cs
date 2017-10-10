using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.CustomerKeys;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Service
{
    public interface ICustomerKeysService
    {

        IEnumerable<CustomerKeys> GetCustomerKeys(Guid CustomerId);
        void CreateCustomerKeys(CustomerKeys CustomerKeys);
        void DeletePreviousKeys(Guid CustomerId);
        void AddNewKeys(Guid CustomerId, List<CustomerKeys> CustomerKeyList);
        void Update(CustomerKeys customerKeys);
        void SaveCustomerKeys();
    }

    public class CustomerKeysService : ICustomerKeysService
    {
        private readonly ICustomerKeysRepository customerKeysRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmployeeTypeRepository employeeTypeRepository;

        public CustomerKeysService(ICustomerKeysRepository customerKeysRepository, IEmployeeTypeRepository employeeTypeRepository, IUnitOfWork unitOfWork)
        {
            this.customerKeysRepository = customerKeysRepository;
            this.unitOfWork = unitOfWork;
            this.employeeTypeRepository = employeeTypeRepository;
        }
        public void Update(CustomerKeys customerKeys)
        {

            customerKeysRepository.Update(customerKeys);
        }
        public void DeletePreviousKeys(Guid CustomerId)
        {

            if (CustomerId != null)
            {
                customerKeysRepository.GetMany(x => x.CustomerId == CustomerId && x.del == false).ToList().ForEach(a => a.del = true);
            }
        }
        public void AddNewKeys(Guid CustomerId, List<CustomerKeys> CustomerKeyList)
        {

            if (CustomerKeyList != null)
            {
                DeletePreviousKeys(CustomerId);
                foreach (var customerkey in CustomerKeyList)
                {
                    customerkey.CustomerId = CustomerId;
                    CreateCustomerKeys(customerkey);

                }

            }
        }
        #region 
        public IEnumerable<CustomerKeys> GetCustomerKeys(Guid CustomerId)
        {
            var Customer = customerKeysRepository.GetAll().Where(x => x.CustomerId == CustomerId && x.del == false);
            return Customer;
        }

        public void CreateCustomerKeys(CustomerKeys customerKeys)
        {

            customerKeysRepository.Add(customerKeys);
        }

        public void SaveCustomerKeys()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
