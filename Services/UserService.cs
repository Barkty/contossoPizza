using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class UserService
{
    static List<User> Users { get; }

    static int nextId = 2;

    static UserService()
    {
        Users = new List<User> 
            {
                new User { Id = 1, StaffId = "SAH-2346", StaffEmail = "admin@example.com", StaffName = "Tems Ayarr", Gender = "Male", Department = "Business Development", Role = User.UserRole.ADMIN, Password = "Password12345", Avatar = ""}
            };
    }

    public static List<User> GetUsers() => Users;

    public static User? GetUser(int id) => Users.FirstOrDefault(u => u.Id == id);

    public static void AddUser(User user)
    {
        user.Id = nextId++;
        Users.Add(user);
    }

    public static void DeleteUser(int id)
    {
        var user = GetUser(id);
        if(user is null)
            return;
        Users.Remove(user);
    }

    public static void UpdateUser(User user)
    {
        var index = Users.FindIndex(u => u.Id == user.Id);
        if(index == -1)
            return;
        Users[index] = user;
    }
}