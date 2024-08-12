using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Domain.Interfaces.ITrade;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InvestmentManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITrade _iTrade;
        private readonly ITradeService _iTradeService;
        public TradeController(ITrade iTrade, ITradeService iTradeService)
        {
            _iTrade = iTrade;
            _iTradeService = iTradeService;
        }

        [HttpGet("/api/GetTradesForUser")]
        [Produces("application/json")]
        public async Task<object> GetTradesForUser([Required] string userEmail, [Required] string NameProduct, [FromQuery] DateTime? tradeDate = null)
        {
        
            return await _iTrade.GetTradesForUserAsync(userEmail, NameProduct, tradeDate);
        }

        [HttpPost("/api/Trade")]
        [Produces("application/json")]
        public async Task<object> Trade(Trade trade)
        {
            await _iTradeService.TradeAsync(trade);

            return trade;
        }
    }
}
