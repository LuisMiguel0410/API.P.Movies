using API.P.Movies.DAL.Models.Dtos;
using API.P.Movies.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.P.Movies.Controllers
{
    //controladores 
    [Route("api/[controller]")] //ruta o URL para poder navegar o hacer las consultas
    [ApiController]// Sin este no se puede convertir un controlador en una API
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] //indica que el resultado esperado es un 200 OK
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] 
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories); // Ok significa que la respuesta fue exitosa, http status code 200
        }

        [HttpGet("{id:int}", Name = "GetCategoryAsync")] // Este metodo siguien siendo un Get
        //http status codes
        [ProducesResponseType(StatusCodes.Status200OK)] //indica que el resultado esperado es un 200 OK
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] // Informo al cliente que la categoria no fue encontrada

        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(int id)
        {
            var categoryDto = await _categoryService.GetCategoryAsync(id);
            return Ok(categoryDto); // Ok significa que la respuesta fue exitosa, http status code 200
        }

        

    }
}
