using InvestmentManagement.Domain.Interfaces.ITrade;
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
    public class TradeRepository : RepositoriesGenerics<Trade>, ITrade
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;

        public TradeRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<IEnumerable<Trade>> GetTradesForUserAsync(string userEmail, DateTime? tradeDate = null)
        {
            using (var dbContext = new ContextBase(_optionsBuilder))
            {
                var query = dbContext.Trade.AsQueryable();

                query = query.Where(t => t.UserEmail == userEmail);

                if (tradeDate.HasValue)
                {
                    query = query.Where(t => t.TradeDate.Date == tradeDate.Value.Date);
                }

                return await query.AsNoTracking().ToListAsync();
            }
        }
    }
}

