using InvestmentManagement.Domain.Interfaces.IFinancialSystem;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FinancialSystemController : ControllerBase
    {
        private readonly IFinancialSystem _iFinancialSystem;
        private readonly IFinancialSystemService _iFinancialSystemService;
        public FinancialSystemController(IFinancialSystem iFinancialSystem,
            IFinancialSystemService iFinancialSystemService)
        {
            _iFinancialSystem = iFinancialSystem;
            _iFinancialSystemService = iFinancialSystemService;
        }

        [HttpGet("/api/GetFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> GetFinancialSystem(string userEmail)
        {
            return await _iFinancialSystem.GetUserFinancialSystemList(userEmail);
        }

        [HttpPost("/api/CreateFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> CreateFinancialSystem(FinancialSystem financialSystem)
        {
            await _iFinancialSystemService.AddFinancialSystem(financialSystem);

            return Task.FromResult(financialSystem);
        }

        [HttpPut("/api/UpdateFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> UpdateFinancialSystem(FinancialSystem financialSystem)
        {
            await _iFinancialSystemService.UpdateFinancialSystem(financialSystem);

            return Task.FromResult(financialSystem);
        }


        [HttpDelete("/api/DeleteFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> DeleteFinancialSystem(int id)
        {
            try
            {
                var financialSystem = await _iFinancialSystem.GetById(id);

                await _iFinancialSystem.Delete(financialSystem);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
