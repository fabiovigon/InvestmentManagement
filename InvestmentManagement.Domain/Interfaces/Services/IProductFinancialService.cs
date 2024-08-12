using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Interfaces.Services
{
    public interface IProductFinancialService
    {
        Task AddProductFinancial(ProductFinancial productFinancial);
        Task UpdateProductFinancial(ProductFinancial productFinancial);
        Task<object> GeneratePurchaseStatement(string userEmail);
    }
}
