using InvestmentManagement.Domain.Interfaces.IFinancialSystem;
using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Services
{
    public class FinancialSystemService : IFinancialSystemService
    {
        private readonly IFinancialSystem _iFinancialSystem;
        public FinancialSystemService(IFinancialSystem ifinancialSystem)
        {
            _iFinancialSystem = ifinancialSystem;   
        }

        public async Task AddFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.PropertyValidString(financialSystem.Name, "Name");
            if (valid)
            {
                var date = DateTime.UtcNow;
                financialSystem.SendEmailProductExpiration = true;
                financialSystem.Year = date.Year;
                financialSystem.Month = date.Month;

                await _iFinancialSystem.Add(financialSystem);
            }
        }

        public async Task UpdateFinancialSystem(FinancialSystem financialSystem)
        {
            var valid = financialSystem.PropertyValidString(financialSystem.Name, "Name");
            if (valid)
            {
                await _iFinancialSystem.Update(financialSystem);
            }
        }
    }
}
