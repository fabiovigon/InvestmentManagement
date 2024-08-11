using InvestmentManagement.Domain.Interfaces.ICategories;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategories _iCategories;
        public CategoryService(ICategories iCategories)
        {
            _iCategories = iCategories;
        }

        public async Task AddCategory(Categories categories)
        {
            var valid = categories.PropertyValidString(categories.Name, "Name");
            if (valid)
            {
                await _iCategories.Add(categories);
            }
        }

        public async Task UpdateCategory(Categories categories)
        {
            var valid = categories.PropertyValidString(categories.Name, "Name");
            if (valid)
            {
                await _iCategories.Update(categories);
            }
        }
    }
}
