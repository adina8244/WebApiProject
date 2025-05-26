using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entites;
using DTO;

namespace DisneyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase   
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO order)
        {
            try
            {
                OrderDTO result = await _orderService.AddOrder(order);
                return Ok(result);  
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); 
            }
        }
    }
}
