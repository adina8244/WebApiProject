using Entites;
using Repositories;
using Zxcvbn;

namespace Services
{
    public class Service    
    {

        DisneyRepositorty repostery = new DisneyRepositorty();
        public User addUserRegister(User newUser)
        {
            if (!validPassword(newUser.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            return repostery.addUserRegister(newUser);
        }


        public User logIn(UserLogin userLogin)
        {

            User theLoggedInUser = repostery.logIn(userLogin);
            if (theLoggedInUser == null)
            {
                throw new KeyNotFoundException("User not found with the provided username and password.");
            }


            return theLoggedInUser;

        }
        public bool validPassword(string password)
        {

            var result = Zxcvbn.Core.EvaluatePassword(password);
            int score = result.Score;
            if ((score)<2)
                return false;
            return true;

        }
        public User UpdateUser(int id, User updatedUser)
        {
            if (!validPassword(updatedUser.Password))
            {
                throw new ArgumentException("you nead to enter a good password");
            }
            User theUpdatedUser = repostery.UpdateUser(id, updatedUser);
            if (theUpdatedUser==null)
            {
                throw new KeyNotFoundException("you are not logged in");
            }
            return theUpdatedUser;
        }


    }
}
