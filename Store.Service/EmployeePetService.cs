
using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.EmployeePet;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Service
{
    public interface IEmployeePetService
    {

        void DeletePreviousEmployeePets(int EmployeeId);
        void AddNewEmployeePets(int EmployeeId, List<EmployeePet> EmployeePetList);
        IEnumerable<EmployeePet> GetPetsByEmployeeId(int Id);
        void CreateEmployeePet(EmployeePet employeePet);
        void SaveEmployeePet();
    }

    public class EmployeePetService : IEmployeePetService
    {
        private readonly IEmployeePetRepository employeePetRepository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeePetService(IEmployeePetRepository employeePetRepository, IUnitOfWork unitOfWork)
        {
            this.employeePetRepository = employeePetRepository;
            this.unitOfWork = unitOfWork;
        }
        public void DeletePreviousEmployeePets(int EmployeeId)
        {

            if (EmployeeId != 0)
            {
                employeePetRepository.GetMany(x => x.EmployeeId == EmployeeId && x.del == false).ToList().ForEach(a => a.del = true);
            }
        }
        public void AddNewEmployeePets(int EmployeeId, List<EmployeePet> EmployeePetList)
        {

            if (EmployeePetList != null)
            {
                DeletePreviousEmployeePets(EmployeeId);
                foreach (var employeepet in EmployeePetList)
                {
                    employeepet.EmployeeId = EmployeeId;
                    CreateEmployeePet(employeepet);

                }

            }
        }

        #region 

        public IEnumerable<EmployeePet> GetPetsByEmployeeId(int Id)
        {
            var animalsByEmployee = employeePetRepository.GetPetsByEmployeeId(Id);
            return animalsByEmployee;
        }

        public void CreateEmployeePet(EmployeePet employeePet)
        {
            employeePetRepository.Add(employeePet);
        }

        public void SaveEmployeePet()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
