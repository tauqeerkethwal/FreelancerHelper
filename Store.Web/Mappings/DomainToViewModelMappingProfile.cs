using AutoMapper;
using Freelancer.Model;
using Freelancer.Model.Models.Customer;
using Freelancer.Model.Models.CustomerPet;
using Freelancer.Model.Models.Employee;
using Freelancer.Model.Models.Pets;
using Freelancer.Model.Models.Schedule;
using Freelancer.Web.Areas.Admin.ViewModels;
using Freelancer.Web.ViewModels;
namespace Freelancer.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<CustomerPet, CustomerPetViewModel>();
            Mapper.CreateMap<Customer, CustomerViewModel>().ForMember(dest => dest.Type,
              opts => opts.Ignore());

            Mapper.CreateMap<Employee, EmployeeViewModel>();

            Mapper.CreateMap<Pet, PetViewModel>();
            Mapper.CreateMap<PetFormViewModel, Pet>();
            Mapper.CreateMap<Gadget, GadgetViewModel>();
            Mapper.CreateMap<Schedule, ScheduleViewModel>();
            Mapper.CreateMap<ScheduleFormViewModel, Schedule>();
        }
    }
}