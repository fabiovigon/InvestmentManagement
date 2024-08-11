using InvestmentManagement.Domain.Interfaces.Generics;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Interfaces.IUserFinancialSystem
{
    public interface IUserFinancialSystem : InterfaceGeneric<UserFinancialSystem>
    {
        Task<IList<UserFinancialSystem>> UserFinancialSystemList(int IdSystem);

        Task RemoveUsers(List<UserFinancialSystem> users);

        Task<UserFinancialSystem> GetUserByEmail(string userEmail);
    }
}
