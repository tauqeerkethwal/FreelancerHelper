﻿using Freelancer.Data.Infrastructure;
using Freelancer.Model;
using System;
using System.Linq;

namespace Freelancer.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

        public override void Update(Category entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}
