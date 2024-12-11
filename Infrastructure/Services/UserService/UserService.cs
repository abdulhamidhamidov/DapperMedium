using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services.UserService;

public class UserService : IUserService
{
    private readonly DapperContext _context;
    public UserService()
    {
        _context = new DapperContext();
    }
    
    public List<Users> GetUsers()
    {
        var sql = $"Select * from users";
        var result = _context.Connection().Query<Users>(sql).ToList();
        return result;
    }

    public Users GetUserById(int id)
    {
        var sql = $"Select * from users where id={@id}";
        var result = _context.Connection().QueryFirstOrDefault(sql);
        return result;
    }

    public string AddUser(Users user)
    {
        var sql = $"insert into users(username,firstname,lastname,phone,address,email,birthdate)" +
                  $"values('{user.Username}','{user.FirstName}','{user.Lastname}','{user.Phone}','{user.Address}','{user.Email}','{user.BirthDate}')";
        var result = _context.Connection().Execute(sql);
        if (result > 0)
        {
            return "User added to db";
        }
        return "Error in adding user to db";
    }

    public string UpdateUser(Users user)
    {
        var sql = $"update users set username='{user.Username}',firstname='{user.FirstName}',lastname='{user.Lastname}'," +
                  $"phone='{user.Phone}',address='{user.Address}',email='{user.Address}',birthdate={user.BirthDate} where id={user.Id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0)
        {
            return "User updated";
        }
        return "Error in updating user";
    }

    public bool DeleteUser(int id)
    {
        var sql = $"Delete from users where id={@id}";
        var result = _context.Connection().Execute(sql);
        if (result > 0)
        {
            return true;
        }
        return false;
    }
}