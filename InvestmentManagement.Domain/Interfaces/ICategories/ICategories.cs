using InvestmentManagement.Domain.Interfaces.Generics;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Interfaces.ICategories
{
    public interface ICategories : InterfaceGeneric<Categories>
    {
        Task<IList<Categories>> GetUserCategoriesList(string userEmail);
    }
}
