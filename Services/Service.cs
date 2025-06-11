
using DTO;
using Entites;
using Repositories;
using Zxcvbn;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class Service : IService
    {
        private readonly ILogger<Service> _logger;
        IDisneyRepositorty repostery;
        IMapper mapper;

        public Service(IDisneyRepositorty r, IMapper mapper, ILogger<Service> logger)
        {
            repostery = r;
            this.mapper = mapper;
            _logger = logger;

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
            var sendRepos = await repostery.logIn(userLogin1); // נניח שזה מחזיר User
            return sendRepos;
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
            _logger?.LogInformation($"Updating user with ID: {id}");
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
