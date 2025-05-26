using DTO;
using Entites;

namespace Services
{
    public interface IService
    {
        Task<User> addUserRegister(User newUser);
        Task<User> logIn(UserLoginDTO userLogin);
        Task<User> UpdateUser(int id, User updatedUser);
        bool validPassword(string password);
    }
}