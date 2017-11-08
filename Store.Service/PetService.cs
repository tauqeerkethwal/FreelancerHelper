using Freelancer.Data.Infrastructure;
using Freelancer.Data.Repositories;
using Freelancer.Model.Common;
using Freelancer.Model.Models.Base;
using Freelancer.Model.Models.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
namespace Freelancer.Service
{
    public interface IPetService

    {
        IEnumerable<Pet> GetAllPets(string name = null);

        Pet GetPet(int id);
        IEnumerable<Pet> GetPet(string name);
        void CreatePet(Pet employeeTypes);
        ListResult<PetListModel> GetAll(SearchParameters searchParameters, PetSearchModel model);
        void Update(Pet animal);
        SelectList GetAllPetDropdown(string Value = null);
        void SavePet();
    }

    public class PetService : IPetService
    {
        private readonly IPetRepository petRepository;
        private readonly IUnitOfWork unitOfWork;

        public PetService(IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            this.petRepository = petRepository;
            this.unitOfWork = unitOfWork;
        }
        public SelectList GetAllPetDropdown(string Value = null)
        {
            if (string.IsNullOrEmpty(Value))
            {
                var listItems = petRepository.GetMany(x => x.del == false).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.AnimalId.ToString()
                }).ToList();

                listItems.Add(new SelectListItem() { Value = "-1", Text = "Others" });
                return new SelectList(listItems, "Value", "Text");


            }

            else
            {
                var listItems = petRepository.GetMany(x => x.del == false).Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.AnimalId.ToString()
                }).ToList();

                listItems.Add(new SelectListItem() { Value = "-1", Text = "Others" });
                return new SelectList(listItems, "Value", "Text", Value);

            }
        }

        public void Update(Pet animal)
        {

            petRepository.Update(animal);
        }
        public PetListModel ConvertToModel(Pet item)
        {
            return new PetListModel
            {
                AnimalId = item.AnimalId,
                DateCreated = item.DateCreated,
                del = item.del,
                Name = item.Name,



            };
        }

        public IEnumerable<PetListModel> ConvertToModel(IEnumerable<Pet> item)
        {

            return item.Select(x => ConvertToModel(x));

        }

        #region 
        public ListResult<PetListModel> GetAll(SearchParameters searchParameters, PetSearchModel model)
        {
            try
            {
                if (searchParameters == null)
                {
                    throw new NullReferenceException("Search Parameters Cannot be null");
                }

                var items = petRepository.GetAll().AsQueryable();

                // Filter records using method implemented in drive class.
                items = FilterRecords(items, searchParameters, model);

                // Get total count of Filtered Records
                var totalRecords = items.Count();


                // Apply Sort Order
                items = CommonHelper.ApplyPetPaging(searchParameters, items);

                // Return Result
                var returnObject = new ListResult<PetListModel>();

                returnObject.TotalRecords = totalRecords;

                returnObject.ResultData = ConvertToModel(items).ToList(); ;
                //add row number
                int r = searchParameters.PageStart;
                returnObject.ResultData.ForEach(i => i.SNo = ++r);
                return returnObject;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public IEnumerable<Pet> GetAllPets(string name = null)
        {

            ///

            if (string.IsNullOrEmpty(name))
                return petRepository.GetAll();
            else
                return petRepository.GetAll().Where(c => c.Name == name);
        }

        public Pet GetPet(int id)
        {
            var animal = petRepository.GetById(id);
            return animal;
        }

        public IEnumerable<Pet> GetPet(string name)
        {
            var animal = petRepository.GetAnimalName(name);
            return animal;
        }

        public void CreatePet(Pet pet)
        {
            petRepository.Add(pet);
        }

        public void SavePet()
        {
            unitOfWork.Commit();
        }
        private IQueryable<Pet> FilterOnSearchText(IQueryable<Pet> items, SearchParameters searchParameters)
        {


            if (!string.IsNullOrEmpty(searchParameters.SearchText))
            {
                items = items.Where(x =>
                                        x.Name.ToLower().Contains(searchParameters.SearchText.ToLower())

                                   );
            }


            return items;
        }

        public IQueryable<Pet> FilterRecords(IQueryable<Pet> items, SearchParameters searchParameters, PetSearchModel model)
        {

            // items = items.Where(w => w.del == false);

            // Filter Records on search text
            items = FilterOnSearchText(items, searchParameters);

            return items;

        }


        #endregion
    }
}
