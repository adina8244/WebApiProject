using Entites;

namespace Repositories
{
    public interface IDisneyRepositorty
    {
        User addUserRegister(User user);
        User logIn(UserLogin userLogin);
        User UpdateUser(int id, User updatedUser);
    }
}