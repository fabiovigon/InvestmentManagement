using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Domain.Interfaces.ITrade;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<object> GetTradesForUser(string userEmail)
        {
            return await _iTrade.GetTradesForUserAsync(userEmail);
        }

        [HttpPost("/api/CreateTrade")]
        [Produces("application/json")]
        public async Task<object> CreateTrade(Trade trade)
        {
            await _iTradeService.CreateTradeAsync(trade);

            return trade;
        }
    }
}
