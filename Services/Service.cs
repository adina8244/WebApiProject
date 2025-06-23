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
        private readonly ILogger<Service> logger;// _logger

        IDisneyRepositorty repostery;// _repostery
        IMapper mapper;

        public Service(IDisneyRepositorty r, IMapper mapper, ILogger<Service> logger)
        {
            repostery = r;
            this.mapper = mapper;
            this.logger = logger;

            logger.LogInformation($"Application started at {DateTime.UtcNow}");
        }


        public async Task<User> addUserRegister(User newUser)//AddUserRegister
        {
            if (!validPassword(newUser.Password))
            {
                throw new ArgumentException("you need to enter a good password");
            }
            return await repostery.addUserRegister(newUser);
        }

        public async Task<User> logIn(UserLoginDTO userLogin)// LogIn
        {
            UserLogin userLogin1 = mapper.Map<UserLogin>(userLogin);
            var sendRepos = await repostery.logIn(userLogin1); // נניח שזה מחזיר User

            if (sendRepos != null)
            {
                logger.LogInformation($"User '{sendRepos.UserName}' logged in successfully at {DateTime.UtcNow}");
            }
            else
            {
                logger.LogWarning($"Failed login attempt for username '{userLogin.UserName}' at {DateTime.UtcNow}");
            }
            //sendRepos != null ? logger.LogInformation($"User '{sendRepos.UserName}' logged in successfully at {DateTime.UtcNow}"):
            // logger.LogWarning($"Failed login attempt for username '{userLogin.UserName}' at {DateTime.UtcNow}");


            return sendRepos;
        }

        public bool validPassword(string password)// ValidPassword
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            int score = result.Score;
            return score >= 2;
        }

        public async Task<User> UpdateUser(int id, User updatedUser)
        {
            logger.LogInformation($"Updating user with ID: {id}");
            if (!validPassword(updatedUser.Password))
            {
                throw new ArgumentException("you need to enter a good password");
            }
            User theUpdatedUser = await repostery.UpdateUser(id, updatedUser);
            // Suggestion: write in a shorter way (LAMBDA)
            // return theUpdatedUser ?? throw new KeyNotFoundException("you are not logged in");
            if (theUpdatedUser == null)
            {
                throw new KeyNotFoundException("you are not logged in");
            }
            return theUpdatedUser;
        }
    }
}