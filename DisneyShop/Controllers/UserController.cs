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

        //// GET: api/<Users>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<Users>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<Users>
        [HttpPost("register")]
        public IActionResult addUserRegister([FromBody] User newUser)
        {
            try
            {
                User user = service.addUserRegister(newUser);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //POST api/<Users>
        [HttpPost("logIn")]
        public IActionResult logIn([FromBody] UserLogin userLogin)
        {
            try
            {
                User user = service.logIn(userLogin);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        //PUT api/<Users>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            try
            {
                User user = service.UpdateUser(id, updatedUser); ;
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
