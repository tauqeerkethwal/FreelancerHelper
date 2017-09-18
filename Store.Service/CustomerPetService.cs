
using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.CustomerPet;
using System;
using System.Collections.Generic;

namespace Freelancer.Service
{
    public interface ICustomerPetService
    {



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
