using Domain.Models;

namespace Infrastructure.Services.UserService;

public interface IUserService
{
    List<Users> GetUsers();
    Users GetUserById(int id);
    string AddUser(Users user);
    string UpdateUser(Users user);
    bool DeleteUser(int id);
}