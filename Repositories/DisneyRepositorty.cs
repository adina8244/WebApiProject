using DTO;
using Entites;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbContext;

namespace Repositories
{
    public class DisneyRepositorty : IDisneyRepositorty
    {
        webApiDB8192Context _webApiDB8192Context;
        public DisneyRepositorty(webApiDB8192Context webApiDB8192Context)
        {
            _webApiDB8192Context = webApiDB8192Context;
        }
        public async Task<User> addUserRegister(User user)
        {
       
            await _webApiDB8192Context.Users.AddAsync(user);
            await _webApiDB8192Context.SaveChangesAsync();
            return await Task.FromResult(user);
        }

        public async Task<User> logIn(UserLogin userLogin)
        {
            return await _webApiDB8192Context.Users.FirstOrDefaultAsync(user => user.UserName == userLogin.UserName && user.Password == userLogin.Password);
        }

        public async Task<User> UpdateUser(int id, User updatedUser)
        {
            var existingUser = await _webApiDB8192Context.Users.FindAsync(id);
            if (existingUser == null)
                return null;

            // עדכן את השדות הרלוונטיים בלבד
            existingUser.UserName = updatedUser.UserName;
            existingUser.Password = updatedUser.Password;
            existingUser.FirstName = updatedUser.FirstName;
            existingUser.LastName = updatedUser.LastName;

            await _webApiDB8192Context.SaveChangesAsync();
            return existingUser;
        }
    }
}
