using InvestmentManagement.Domain.Interfaces.ICategories;
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
    public class ProductFinancialService : IProductFinancialService
    {
        private readonly IProductFinancial _iproductFinancial;
        public ProductFinancialService(IProductFinancial iproductFinancial)
        {
            _iproductFinancial = iproductFinancial;
        }

        public async Task AddProductFinancial(ProductFinancial productFinancial)
        {
            var date = DateTime.UtcNow;
            productFinancial.Dt_Inclusion = date;
            productFinancial.Year = date.Year;
            productFinancial.Month = date.Month;

            var valid = productFinancial.PropertyValidString(productFinancial.Name, "Name");
            if (valid)
                await _iproductFinancial.Add(productFinancial);

        }

        public async Task UpdateProductFinancial(ProductFinancial productFinancial)
        {
            var date = DateTime.UtcNow;
            productFinancial.Dt_Change = date;

            if (!productFinancial.ProductExpired)
            {
                var valid = productFinancial.PropertyValidString(productFinancial.Name, "Name");
                if (valid)
                    await _iproductFinancial.Update(productFinancial);
            }

        }
    }
}
