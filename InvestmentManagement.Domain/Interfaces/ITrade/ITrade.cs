using InvestmentManagement.Domain.Interfaces.Generics;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Interfaces.ITrade
{
    public interface ITrade : InterfaceGeneric<Trade>
    {
        Task<IEnumerable<Trade>> GetTradesForUserAsync(string userEmail, DateTime? tradeDate = null);
    }
}
