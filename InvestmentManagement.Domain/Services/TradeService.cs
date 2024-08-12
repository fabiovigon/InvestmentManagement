using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Domain.Interfaces.ITrade;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManagement.Domain.Services
{
    public class TradeService : ITradeService
    {
        private readonly IProductFinancialService _productFinancialService;
        private readonly IProductFinancial _productFinancial;
        private readonly ITrade _iTrade;

        public TradeService(IProductFinancialService productFinancialService, IProductFinancial productFinancial, ITrade iTrade)
        {
            _productFinancialService = productFinancialService;
            _productFinancial = productFinancial;
            _iTrade = iTrade;
        }

        public async Task<Trade> CreateTradeAsync(Trade trade)
        {
            if (trade.TradeType != "Buy" && trade.TradeType != "Sell")
            {
                throw new ArgumentException("Tipo de negociação inválido. Escolha entre 'Buy' ou 'Sell'.");
            }

            var product = await _productFinancial.GetById(trade.ProductId);
            if (product == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            if (trade.TradeType == "Buy")
            {
                trade.Quantity += trade.Quantity;
                product.Quantity -= trade.Quantity;


                trade.Amount = trade.Quantity * product.Value; 
            }

            else if (trade.TradeType == "Sell")
            {
                if (trade.Quantity < trade.Quantity)
                {
                    throw new ArgumentException("Quantidade insuficiente para venda.");
                }

                trade.Quantity -= trade.Quantity; 
                product.Quantity += trade.Quantity; 
            }

            await _productFinancialService.UpdateProductFinancial(product);

            trade.TradeDate = DateTime.UtcNow;

            await _iTrade.Add(trade);

            return trade;
        }

        public async Task<IEnumerable<Trade>> GetTradesForUserAsync(string userEmail, DateTime? tradeDate = null)
        {
            return await _iTrade.GetTradesForUserAsync(userEmail, tradeDate);
        }
    }
}
