using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Services;
using Entites;
using DTO;

namespace DisneyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase   // חשוב להוריש מ-ControllerBase
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
                return Ok(result);  // כאן זו המתודה המובנית שמחזירה 200 עם התוצאה
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // כאן מחזיר 400 עם ההודעה
            }
        }
    }
}
