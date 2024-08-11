using InvestmentManagement.Domain.Interfaces.IUserFinancialSystem;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Services
{
    public class UserFinancialSystemService : IUserFinancialSystemService
    {
        private readonly IUserFinancialSystem _iUserFinancialSystem;
        public UserFinancialSystemService(IUserFinancialSystem iuserFinancialSystem)
        {
            _iUserFinancialSystem = iuserFinancialSystem;
        }
        
        public async Task CreateUserFinancialSystem(UserFinancialSystem userFinancialSystem)
        {
            await _iUserFinancialSystem.Add(userFinancialSystem);
        }

        public async Task UpdateUserFinancialSystem(UserFinancialSystem userFinancialSystem)
        {
            await _iUserFinancialSystem.Update(userFinancialSystem);
        }
    }
}
