using Entites;
using System.Text.Json;

namespace Repositories
{
    public class DisneyRepositorty
    {


        public User addUserRegister(User user)
        {
            string filePath = "Users.txt";
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return user;
        }

        public User logIn(UserLogin userLogin)
        {
            string filePath = "./Users.txt";
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User currentUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (userLogin.UserName == currentUser.UserName && currentUser.Password == userLogin.Password)
                    {

                        return currentUser;
                    }
                }
            }
            return null;

        }

        public User UpdateUser(int id, User updatedUser)
        {
            string filePath = "./Users.txt";
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.id == id)
                        textToReplace = currentUserInFile;
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(updatedUser));
                System.IO.File.WriteAllText(filePath, text);
                return updatedUser;
            }
            return null;
        }
    }
}
