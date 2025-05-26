using DTO;
using Entites;

namespace Repositories
{
    public interface IDisneyRepositorty
    {
        Task<User> addUserRegister(User user);
        Task<User> logIn(UserLogin userLogin);
        Task<User> UpdateUser(int id, User updatedUser);
    }
}