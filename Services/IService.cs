using Entites;

namespace Services
{
    public interface IService
    {
        User addUserRegister(User newUser);
        User logIn(UserLogin userLogin);
        User UpdateUser(int id, User updatedUser);
        bool validPassword(string password);
    }
}