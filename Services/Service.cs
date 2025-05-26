
using DTO;
using Entites;
using Repositories;
using Zxcvbn;
using AutoMapper;

namespace Services
{
    public class Service : IService
    {
        
        IDisneyRepositorty repostery;
        public Service(IDisneyRepositorty r)
        {
            repostery = r;
        }
        public async Task<User> addUserRegister(User newUser)
        {
            if (!validPassword(newUser.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            return await repostery.addUserRegister(newUser);
        }


        public async Task<User> logIn(UserLoginDTO userLogin)
        {
            UserLogin userLogin1 = mapper.Map<UserLogin>(userLogin);
            var sendRepos = await repostery.logIn(userLogin1);
            var Dto = mapper.Map<OrderDTO>(userLogin1);
            return mapper.Map<UserLogin>(Dto);
        }
        public bool validPassword(string password)
        {

            var result = Zxcvbn.Core.EvaluatePassword(password);
            int score = result.Score;
            if ((score) < 2)
                return false;
            return true;

        }
        public async Task<User> UpdateUser(int id, User updatedUser)
        {
            Console.WriteLine($"Updating user with ID: {id}");
            if (!validPassword(updatedUser.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            User theUpdatedUser = await repostery.UpdateUser(id, updatedUser);
            if (theUpdatedUser == null)
            {
                throw new KeyNotFoundException("you are not logged in");
            }
            return theUpdatedUser;
        }

       
    }
}
