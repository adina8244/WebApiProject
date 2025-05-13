using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Services;
using Entites;
using System.Collections;
using System.Collections.Generic;

namespace DisneyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proudct>>> Get()
        {
            try
            {
                List<Proudct> result = await _productService.GetProudct();
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
