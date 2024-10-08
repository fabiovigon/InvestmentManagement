﻿using InvestmentManagement.Domain.Interfaces.Generics;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Interfaces.IProductFinancial
{
    public interface IProductFinancial : InterfaceGeneric<ProductFinancial>
    {
        Task<IList<ProductFinancial>> GetUserProductFinancialList(string userEmail);
        Task<IList<ProductFinancial>> GetProductFinancialList();
    }
}
