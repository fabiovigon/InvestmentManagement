using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Respositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Infra.Respositories
{
    public class ProductFinancialRepository : RepositoriesGenerics<ProductFinancial>, IProductFinancial
    {
    }
}
