using InvestmentManagement.Domain.Interfaces.ICategories;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Respositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Infra.Respositories
{
    public class CategoryRespository : RepositoriesGenerics<Categories>, ICategories
    {
    }
}
