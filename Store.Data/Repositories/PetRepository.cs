using Freelancer.Data.Infrastructure;
using Freelancer.Model.Models.Pets;
using System.Collections.Generic;
using System.Linq;
namespace Freelancer.Data.Repositories
{

    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        public PetRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {

        }



        public IEnumerable<Pet> GetAnimalName(string Name)
        {
            var employeetype = this.DbContext.Animals.Where(x => x.Name == Name && x.del == false);
            return employeetype;
        }
        public override void Update(Pet animal)
        {

            base.Update(animal);

        }
    }

    public interface IPetRepository : IRepository<Pet>
    {


        IEnumerable<Pet> GetAnimalName(string Name);
    }
}
