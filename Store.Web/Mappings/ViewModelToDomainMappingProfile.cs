using AutoMapper;
using Freelancer.Model;
using Freelancer.Model.Models.Employee;
using Freelancer.Model.Models.Customer;
using Freelancer.Web.Areas.Admin.ViewModels;
using Freelancer.Web.ViewModels;

namespace Freelancer.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EmployeeFormViewModel, EmployeeViewModel>().ForMember(g => g.Type, opts => opts.Ignore());
            Mapper.CreateMap<EmployeeFormViewModel, Employee>();
            Mapper.CreateMap<CustomerFormViewModel, Customer>();
            Mapper.CreateMap<GadgetFormViewModel, Gadget>()
                   .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
                   .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
                   .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
                   .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File.FileName))
                   .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.GadgetCategory));
        }
    }
}