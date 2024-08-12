using InvestmentManagement.Domain.Interfaces.IProductFinancial;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFinancialController : ControllerBase
    {
        private readonly IProductFinancial _iProductFinancial;
        private readonly IProductFinancialService _iProductFinancialService;
        public ProductFinancialController(IProductFinancial iProductFinancial, IProductFinancialService iProductFinancialService)
        {
            _iProductFinancial = iProductFinancial;
            _iProductFinancialService = iProductFinancialService;
        }

        [HttpGet("/api/GetUserProductFinancial")]
        [Produces("application/json")]
        public async Task<object> GetUserProductFinancial(string userEmail)
        {
            return await _iProductFinancial.GetUserProductFinancialList(userEmail);
        }

        [HttpPost("/api/AddProduct")]
        [Produces("application/json")]
        public async Task<object> AddProduct(ProductFinancial productFinancial)
        {
            await _iProductFinancialService.AddProductFinancial(productFinancial);

            return productFinancial;

        }

        [HttpPut("/api/Updateproduct")]
        [Produces("application/json")]
        public async Task<object> Updateproduct(ProductFinancial productFinancial)
        {
            await _iProductFinancialService.UpdateProductFinancial(productFinancial);

            return productFinancial;

        }


        [HttpGet("/api/GetProduct")]
        [Produces("application/json")]
        public async Task<object> GetProduct(int id)
        {
            return await _iProductFinancial.GetById(id);
        }


        [HttpDelete("/api/DeleteDespesa")]
        [Produces("application/json")]
        public async Task<object> DeleteDespesa(int id)
        {
            try
            {
                var categoria = await _iProductFinancial.GetById(id);
                await _iProductFinancial.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        [HttpGet("/api/GeneratePurchaseStatement")]
        [Produces("application/json")]
        public async Task<object> GeneratePurchaseStatement(string emailUsuario)
        {
            return await _iProductFinancialService.GeneratePurchaseStatement(emailUsuario);
        }
    }
}
