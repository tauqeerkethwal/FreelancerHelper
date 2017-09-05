using AutoMapper;
using Freelancer.Model;
using Freelancer.Model.Models.Pets;
using Freelancer.Model.Models.Employee;
using Freelancer.Web.Areas.Admin.ViewModels;

using Freelancer.Web.ViewModels;
using System;
using System.Linq.Expressions;
using System.Reflection;
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
            Mapper.CreateMap<Employee, EmployeeViewModel>();

            Mapper.CreateMap<Employee, EmployeeViewModel>().ForMember(dest => dest.Type,
               opts => opts.Ignore());

            Mapper.CreateMap<Pet, PetViewModel>();
            Mapper.CreateMap<PetFormViewModel, Pet>();
            Mapper.CreateMap<Gadget, GadgetViewModel>();
        }
    }
}