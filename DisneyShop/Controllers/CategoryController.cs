using Services;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Services;
using Entites;
using Services;
using System.Collections;
using System.Collections.Generic;
using DTO;
namespace DisneyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public CategoryController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>>getCategoryAsync()
        {
            try
            {
                List<CategoryDTO> result = await _categoriesService.getCategoryAsync();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
   
    
}
