using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Services;
using Entites;

namespace DisneyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                Order result = await _orderService.AddOrder(order);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
           
            
        }

        private IActionResult Ok(Order result)
        {
            throw new NotImplementedException();
        }

        private IActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }
    }
}
