using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DisneyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hello", "everyOne" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] string Name, string LastName ,string FirstName, string Password)
        {
            var user = new User(Name, LastName, FirstName, Password);   
            int numberOfUsers = System.IO.File.ReadLines("M:\\webApi\\DisneyShop").Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("M:\\webApi\\DisneyShop", userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);

        }

        // PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //    string textToReplace = string.Empty;
        //    using (StreamReader reader = System.IO.File.OpenText("M:\\webApi\\DisneyShop"))
        //    {
        //        string currentUserInFile;
        //        while ((currentUserInFile = reader.ReadLine()) != null)
        //        {

        //            User user = JsonSerializer.Deserialize<User>(currentUserInFile);
        //            if (user.id == id)
        //                textToReplace = currentUserInFile;
        //        }
        //    }

        //    if (textToReplace != string.Empty)
        //    {
        //        string text = System.IO.File.ReadAllText("M:\\webApi\\DisneyShop");
        //        text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
        //        System.IO.File.WriteAllText("M:\\webApi\\DisneyShop", text);
        //    }

        //}

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
