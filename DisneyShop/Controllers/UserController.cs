using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private string filePath = "Users.txt";

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Adina", "Sara" };
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var users = System.IO.File.ReadAllLines(filePath);
            foreach (var line in users)
            {
                var user = JsonSerializer.Deserialize<User>(line);
                if (user?.UserName == request.UserName && user?.Password == request.Password)
                {
                    return Ok(new { UserId = user.id }); // מחזירים את ה-ID של המשתמש לאחר התחברות
                }
            }
            return Unauthorized("Incorrect email or password");
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var users = System.IO.File.ReadAllLines(filePath);
            var user = users.Select(line => JsonSerializer.Deserialize<User>(line)).FirstOrDefault(u => u?.id == id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            user.id = System.IO.File.ReadLines(filePath).Count() + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + "\n");
            return CreatedAtAction(nameof(Get), new { id = user.id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User updatedUser)
        {
            var users = System.IO.File.ReadAllLines(filePath).ToList();
            for (int i = 0; i < users.Count; i++)
            {
                var user = JsonSerializer.Deserialize<User>(users[i]);
                if (user?.id == id)
                {
                    updatedUser.id = id;
                    users[i] = JsonSerializer.Serialize(updatedUser);
                    System.IO.File.WriteAllLines(filePath, users);
                    return Ok(updatedUser);
                }
            }
            return NotFound();
        }
    }
}
