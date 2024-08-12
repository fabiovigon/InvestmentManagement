using InvestmentManagement.Domain.Interfaces.ICategories;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategories _iCategories;
        private readonly ICategoryService _iCategoryService;

        public CategoryController(ICategories iCategories, ICategoryService iCategoryService)
        {
            _iCategories = iCategories;
            _iCategoryService = iCategoryService;
        }

        [HttpGet("/api/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _iCategories.GetUserCategoriesList(emailUsuario);
        }

        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categories categories)
        {
            await _iCategoryService.AddCategory(categories);

            return categories;
        }

        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categories categories)
        {
            await _iCategoryService.UpdateCategory(categories);

            return categories;
        }

        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _iCategories.GetById(id);
        }


        [HttpDelete("/api/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _iCategories.GetById(id);
                await _iCategories.Delete(categoria);

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
