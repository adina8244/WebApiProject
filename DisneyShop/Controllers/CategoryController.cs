using Services;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Services;
using Entites;
using Services;
using System.Collections;
using System.Collections.Generic;
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
        public async Task<ActionResult<List<Category>>>getCategory()
        {
            List<Category> categories = await _categoriesService.getCategory();
            if (categories == null)
                return NotFound();

            return Ok(categories);
        }

        
    }
   
    
}
