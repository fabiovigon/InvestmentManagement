using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Interfaces.Services
{
    public interface IFinancialSystemService
    {
        Task AddFinancialSystem(FinancialSystem financialSystem);
        Task UpdateFinancialSystem(FinancialSystem financialSystem);
    }
}
