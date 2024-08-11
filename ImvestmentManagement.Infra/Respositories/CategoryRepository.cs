using InvestmentManagement.Domain.Interfaces.ICategories;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Configurations;
using InvestmentManagement.Infra.Respositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Infra.Respositories
{
    public class CategoryRepository : RepositoriesGenerics<Categories>, ICategories
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public CategoryRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<Categories>> GetUserCategoriesList(string userEmail)
        {
            using( var dbContext = new ContextBase(_optionsBuilder))
            {
                return await (from s in dbContext.FinancialSystems
                              join c  in dbContext.Categories on s.Id equals c.IdSystem
                              join us in dbContext.UserFinancialSystem on s.Id equals us.IdSystem
                              where us.Email.Equals(userEmail) && us.CurrentSystem
                              select c).AsNoTracking().ToListAsync();
            }
        }
    }
}
