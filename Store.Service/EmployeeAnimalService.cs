
using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model;
using System.Collections.Generic;

namespace Freelancer.Service
{
    public interface IEmployeeAnimalService
    {



        IEnumerable<EmployeeAnimal> GetAnimalsByEmployeeId(int EmployeeId);
        void CreateEmployeeAnimal(EmployeeAnimal EmployeeAnimal);
        void SaveCategory();
    }

    public class EmployeeAnimalService : IEmployeeAnimalService
    {
        private readonly IEmployeeAnimalRepository employeeAnimalRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeeAnimalService(IEmployeeAnimalRepository employeeAnimalRepository, IUnitOfWork unitOfWork)
        {
            this.employeeAnimalRepository = employeeAnimalRepository;
            this.unitOfWork = unitOfWork;
        }

        #region 

        public IEnumerable<EmployeeAnimal> GetAnimalsByEmployeeId(int EmployeeId)
        {
            var animalsByEmployee = employeeAnimalRepository.GetAnimalsByEmployeeId(EmployeeId);
            return animalsByEmployee;
        }

        public void CreateEmployeeAnimal(EmployeeAnimal employeeAnimal)
        {
            employeeAnimalRepository.Add(employeeAnimal);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
