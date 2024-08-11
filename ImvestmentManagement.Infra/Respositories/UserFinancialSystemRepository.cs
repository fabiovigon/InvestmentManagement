using InvestmentManagement.Domain.Interfaces.IUserFinancialSystem;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Respositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Infra.Respositories
{
    public class UserFinancialSystemRepository : RepositoriesGenerics<UserFinancialSystem>, IUserFinancialSystem
    {
        public Task<UserFinancialSystem> GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUsers(List<UserFinancialSystem> users)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserFinancialSystem>> UserFinancialSystemList(int IdSystem)
        {
            throw new NotImplementedException();
        }
    }
}
