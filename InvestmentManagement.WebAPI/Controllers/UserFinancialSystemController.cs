using InvestmentManagement.Domain.Interfaces.IUserFinancialSystem;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Domain.Services;
using InvestmentManagement.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserFinancialSystemController : ControllerBase
    {

        private readonly IUserFinancialSystem _iUserFinancialSystem;
        private readonly IUserFinancialSystemService _iUserFinancialSystemService;
        public UserFinancialSystemController(IUserFinancialSystem iUserFinancialSystem,
            IUserFinancialSystemService iUserFinancialSystemService)
        {
            _iUserFinancialSystem = iUserFinancialSystem;
            _iUserFinancialSystemService = iUserFinancialSystemService;
        }

        [HttpGet("/api/GetUserSystem")]
        [Produces("application/json")]
        public async Task<object> GetUserSystem(int idSystem)
        {
            return await _iUserFinancialSystem.GetUserFinancialSystemList(idSystem);
        }


        [HttpPost("/api/CreateUserInSystem")]
        [Produces("application/json")]
        public async Task<object> CreateUserInSystem(int idSystem, string userEmail)
        {
            try
            {
                await _iUserFinancialSystemService.CreateUserFinancialSystem(
                   new UserFinancialSystem
                   {
                       IdSystem = idSystem,
                       Email = userEmail,
                       Administrator = false,
                       CurrentSystem = true
                   });
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }

        [HttpDelete("/api/DeleteUserFinancialSystem")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var userFinancialSystem = await _iUserFinancialSystem.GetById(id);

                await _iUserFinancialSystem.Delete(userFinancialSystem);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);

        }
    }
}
