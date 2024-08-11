using InvestmentManagement.Domain.Interfaces.IFinancialSystem;
using InvestmentManagement.Entities.Entities;
using InvestmentManagement.Infra.Respositories.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Infra.Respositories
{
    public class FinancialSystemRepository : RepositoriesGenerics<FinancialSystem>, IFinancialSystem
    {
    }
}
