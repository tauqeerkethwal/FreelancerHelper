using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelancer.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        FreelancerEntities dbContext;

        public FreelancerEntities Init()
        {
            return dbContext ?? (dbContext = new FreelancerEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
