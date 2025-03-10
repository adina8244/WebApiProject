public class User
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public int id { get; set; }
    public static int numberOfUsers =0;
    public User(string name, string password, string firstName, string lastName)
    {
        numberOfUsers++;
        Name = name;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }

}