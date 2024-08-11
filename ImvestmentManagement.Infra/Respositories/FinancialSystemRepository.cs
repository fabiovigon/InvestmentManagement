using InvestmentManagement.Domain.Interfaces.IFinancialSystem;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Configurations;
using InvestmentManagement.Infra.Respositories.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Infra.Respositories
{
    public class FinancialSystemRepository : RepositoriesGenerics<FinancialSystem>, IFinancialSystem
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public FinancialSystemRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IList<FinancialSystem>> GetUserFinancialSystemList(string userEmail)
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                return await(from s in dbContext.FinancialSystems
                             join us in dbContext.UserFinancialSystem on s.Id equals us.IdSystem
                             where us.Email.Equals(userEmail)
                             select s).AsNoTracking().ToListAsync();
            }
        }
    }
}
