using InvestmentManagement.Domain.Interfaces.IUserFinancialSystem;
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
    public class UserFinancialSystemRepository : RepositoriesGenerics<UserFinancialSystem>, IUserFinancialSystem
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public UserFinancialSystemRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<UserFinancialSystem> GetUserByEmail(string userEmail)
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                return await dbContext.UserFinancialSystem.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(userEmail));
            }
        }

        public async Task RemoveUsers(List<UserFinancialSystem> users)
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                dbContext.UserFinancialSystem
                .RemoveRange(users);

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<UserFinancialSystem>> GetUserFinancialSystemList(int IdSystem)
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                return await dbContext.UserFinancialSystem
                      .Where(s => s.IdSystem == IdSystem).AsNoTracking()
                      .ToListAsync();
            }
        }
    }
}
