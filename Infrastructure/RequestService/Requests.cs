using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.RequestService;
using Npgsql;
using Dapper;
public class Requests
{
    private readonly DapperContext _context;
    public Requests()
    {
        _context= new DapperContext();
    }
    public List<CategoryRating> GetCategoryRatings()
    {
        var sql = @"select c.id,c.name,count(u.id) as rating from categories c
        join products p on p.categoryId=c.id
        join markets m on m.id=p.marketid
        join users u on u.id=m.userid
        group by c.id,c.name 
        order by rating
       ";
        var res = _context.Connection().Query<CategoryRating>(sql).ToList();
        return res;
    }
    public List<UserMarkentName> UserMarkentNames()
    {
        var sql = @"select u.Id,u.Username,u.FirstName,u.LastName,u.Phone,u.Address,u.Email,u.BirthDate,m.MarketName from users u
join markets m on m.UserId=u.Id";
        var res = _context.Connection().Query<UserMarkentName>(sql).ToList();
        return res;
    }
    public List<ProductCategories> GetProductCategories()
    {
        var sql = @"select p.id,p.name,p.price,p.MarketId,p.CategoryId,c.name as CategoryName from products p
join Categories c on c.id=p.CategoryId";
        var res = _context.Connection().Query<ProductCategories>(sql).ToList();
        return res;
    }
    public List<UserTotalAmount> GetUserTotalAmounts()
    {
        var sql = @"select u.Id,u.Username,u.FirstName,u.LastName,u.Phone,u.Address,u.Email,u.BirthDate,sum(p.price) as TotalAmount from users u
join markets m on m.UserId=u.Id
join products p on p.marketid=m.id
group by  u.Id,u.Username,u.FirstName,u.LastName,u.Phone,u.Address,u.Email,u.BirthDate";
        var res = _context.Connection().Query<UserTotalAmount>(sql).ToList();
        return res;
    }
}