using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Models.Schedule;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Service
{
    // operations you want to expose
    public interface IScheduleEmployeeService
    {
        //
        void CreateAndUpdateScheduleEmployee(Schedule oldScheduleEmployee, List<ScheduleEmployee> NewScheduleEmployee);
        List<ScheduleEmployee> CompareExistingEmployeeFromSchedule(Schedule schedule, List<ScheduleEmployee> NewScheduleEmployee);
        void SaveCategory();
    }

    public class ScheduleEmployeeService : IScheduleEmployeeService
    {
        private readonly IScheduleEmployeeRepository scheduleEmployeeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ScheduleEmployeeService(IScheduleEmployeeRepository scheduleEmployeeRepository, IUnitOfWork unitOfWork)
        {
            this.scheduleEmployeeRepository = scheduleEmployeeRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members
        public List<ScheduleEmployee> IfoldEmployeeNotExistInNewList(Schedule oldScheduleEmployee, List<ScheduleEmployee> NewScheduleEmployee)
        {
            List<ScheduleEmployee> SelectedScheduleEmployee = new List<ScheduleEmployee>();
            if (oldScheduleEmployee.ScheduleEmployees != null)
            {
                for (int i = 0; i < oldScheduleEmployee.ScheduleEmployees.Count; i++)
                {
                    bool checkold = true;
                 
                        for (int j = 0; j < NewScheduleEmployee.Count; j++)
                        {
                            if (NewScheduleEmployee[j].EmployeeId == oldScheduleEmployee.ScheduleEmployees[i].EmployeeId)
                            {
                                checkold = false;
                            }
                        }
                        if (checkold)
                            SelectedScheduleEmployee.Add(oldScheduleEmployee.ScheduleEmployees[i]);
                    }
                
            }
            return SelectedScheduleEmployee;
        }

        public List<ScheduleEmployee> CompareExistingEmployeeFromSchedule(Schedule oldScheduleEmployee, List<ScheduleEmployee> NewScheduleEmployee)
        {
            
            List<ScheduleEmployee> SelectedScheduleEmployee = new List<ScheduleEmployee>();
            for (int i = 0; i < NewScheduleEmployee.Count; i++)
            {
                bool checkold = true;
                if(oldScheduleEmployee.ScheduleEmployees==null)
                {
                    SelectedScheduleEmployee.Add(NewScheduleEmployee[i]);
                }
                else
                {
                for (int j = 0; j < oldScheduleEmployee.ScheduleEmployees.Count; j++)
                {
                    if(NewScheduleEmployee[i].EmployeeId==oldScheduleEmployee.ScheduleEmployees[j].EmployeeId)
                    {
                        checkold = false;
                    }
                }
                if (checkold)
                    {
                        NewScheduleEmployee[i].ScheduleId = oldScheduleEmployee.ScheduleId;
                        SelectedScheduleEmployee.Add(NewScheduleEmployee[i]); }
                    
                }
            }
            
            return SelectedScheduleEmployee;
        }

        public void CreateAndUpdateScheduleEmployee(Schedule oldScheduleEmployee, List<ScheduleEmployee> NewScheduleEmployee)
        {

            scheduleEmployeeRepository.SoftDeleteScheduleEmployee(
            IfoldEmployeeNotExistInNewList(oldScheduleEmployee, NewScheduleEmployee));
          
            scheduleEmployeeRepository.CreateScheduleEmployee(CompareExistingEmployeeFromSchedule(oldScheduleEmployee, NewScheduleEmployee));
          

        }
        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
