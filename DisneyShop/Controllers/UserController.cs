using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Services;
using Entites;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase    
    {
        IService service;
        public Users(IService s)
        {
            service = s;
        }

        
        // POST api/<Users>
        [HttpPost("register")]
        public async Task<IActionResult> addUserRegister([FromBody] User newUser)
        {
            try
            {
               User user =await  service.addUserRegister(newUser);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }           

        }

        //POST api/<Users>
        [HttpPost("logIn")]
        public async Task<IActionResult> logIn([FromBody] UserLogin userLogin)
        {
            try
            {
                User user = await service.logIn(userLogin);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //PUT api/<Users>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                User user = await service.UpdateUser(id, updatedUser); ;
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }


        }




        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
