using AutoMapper;
using Freelancer.Model.Models.Base;
using Freelancer.Model.Models.Pets;
using Freelancer.Service;
using Freelancer.Web.Areas.Admin.ViewModels;
using Freelancer.Web.Areas.Admin.ViewModels.DataTable;
using System.Web.Mvc;
namespace Freelancer.Web.Areas.Admin.Controllers
{
    public class PetController : Controller
    {
        // GET: Admin/Animal
        private readonly IPetService petService;

        public PetController(IPetService petService)
        {
            this.petService = petService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {


            PetViewModel viewModelAnimal;
            Pet pet = petService.GetPet(0);
            viewModelAnimal = Mapper.Map<Pet, PetViewModel>(pet);
            return View(viewModelAnimal);
        }
        public ActionResult edit(int Id, string BackUrl)
        {

            PetViewModel viewModelAnimal;
            Pet pet = petService.GetPet(Id);
            viewModelAnimal = Mapper.Map<Pet, PetViewModel>(pet);
            return View(viewModelAnimal);
        }


        [HttpPost]

        public bool deleteUndelete(int id, bool del)
        {
            if (id != null)
            {
                var pet = petService.GetPet(id);
                pet.del = del;
                petService.Update(pet);
                petService.SavePet();
            }

           return true;
        }

        [HttpPost]

        public ActionResult edit(PetFormViewModel model)
        {
            if (model != null)
            {
                var Pet = Mapper.Map<PetFormViewModel, Pet>(model);
                petService.Update(Pet);
                petService.SavePet();
            }

            //PetViewModel viewModelAnimal;
            //Pet pet = petService.GetPet(Id);
            //viewModelAnimal = Mapper.Map<Pet, PetViewModel>(pet);
            return RedirectToAction("Add", "Pet");
        }


        public ActionResult Create(PetFormViewModel newPet)
        {

            if (ModelState.IsValid)
            {
                var pet = Mapper.Map<PetFormViewModel, Pet>(newPet);
                petService.CreatePet(pet);
                petService.SavePet();
                return RedirectToAction("Add");
            }


            return View("Add");
        }
        protected DTResult<T> GetListResult<T>(DTParameters param, ListResult<T> listResult)
        {


            DTResult<T> result = new DTResult<T>
            {
                draw = param.Draw,
                data = listResult.ResultData,
                recordsFiltered = listResult.TotalRecords,
                recordsTotal = listResult.TotalRecords,

            };

            return result;

        }
        [HttpPost]
        public ActionResult LoadAllData(DTParameters param, PetSearchModel model)
        {
            var SearchValue = Request.Form.GetValues("search[value]")[0];
            var parameters = param.GetSearchParameters();
            parameters.SearchText = SearchValue;

            var listResult = petService.GetAll(parameters, model);

            var result = GetListResult<PetListModel>(param, listResult);

            return Json(result);

        }
    }
}