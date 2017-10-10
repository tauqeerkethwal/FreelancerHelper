
using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.CustomerPet;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Service
{
    public interface ICustomerPetService
    {

        void DeletePreviousCustomerPets(Guid CustomerId);
        void AddNewCustomerPets(Guid CustomerId, List<CustomerPet> CustomerPetList);
        IEnumerable<CustomerPet> GetPetsByCustomerId(Guid Id);
        void CreateCustomerPet(CustomerPet customerPet);
        void SaveCategory();
    }

    public class CustomerPetService : ICustomerPetService
    {
        private readonly ICustomerPetRepository customerPetRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerPetService(ICustomerPetRepository customerPetRepository, IUnitOfWork unitOfWork)
        {
            this.customerPetRepository = customerPetRepository;
            this.unitOfWork = unitOfWork;
        }
        public void DeletePreviousCustomerPets(Guid CustomerId)
        {

            if (CustomerId != null)
            {
                customerPetRepository.GetMany(x => x.CustomerId == CustomerId && x.del == false).ToList().ForEach(a => a.del = true);
            }
        }
        public void AddNewCustomerPets(Guid CustomerId, List<CustomerPet> CustomerPetList)
        {

            if (CustomerPetList != null)
            {
                DeletePreviousCustomerPets(CustomerId);
                foreach (var customerkey in CustomerPetList)
                {
                    customerkey.CustomerId = CustomerId;
                    CreateCustomerPet(customerkey);

                }

            }
        }

        #region 

        public IEnumerable<CustomerPet> GetPetsByCustomerId(Guid Id)
        {
            var animalsByEmployee = customerPetRepository.GetPetsByCustomerId(Id);
            return animalsByEmployee;
        }

        public void CreateCustomerPet(CustomerPet customerPet)
        {
            customerPetRepository.Add(customerPet);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
