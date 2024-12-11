using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services.MarketService;

public class MarketService:IMarketService
{
    private readonly DapperContext _context;
    public MarketService()
    {
        _context = new DapperContext();
    }
    public List<Markets> GetMarkets()
    {
        var sql = $"Select * from markets"; 
        var result=_context.Connection().Query<Markets>(sql).ToList();
        return result;
    }

    public Markets GetMarketById(int id)
    {
        var sql = $"select * from markets where id={@id}";
        var result=_context.Connection().QueryFirstOrDefault(sql);
        return result;
    }

    public string AddMarket(Markets market)
    {
        var sql = $"insert into markets(market_name,address,description,startdate,userid)" +
                  $"values('{market.MarketName}','{market.Address}','{market.Description}','{market.StartDate}' ,{market.UserId})"; 
        var result= _context.Connection().Execute(sql);
        if (result>0)
        {
            return "Market added to DB";
        }
        return "Error in adding market to db";
    }

    public string UpdateMarket(Markets market)
    {
        var sql = $"update markets set market_name='{market.MarketName}',address='{market.Address}'," +
                  $"description='{market.Description}',startdate={market.StartDate},userid={market.UserId} where id={market.Id}"; 
        var result=_context.Connection().Execute(sql);
        if (result>0)
        {
            return "market updated";
        }
        return "Error in updating market";
    }

    public bool DeleteMarket(int id)
    {
        var sql = $"Delete from markets where id={@id}";
        var result=_context.Connection().Execute(sql);  
        if (result>0)
        {
            return true;
        }
        return false;
    }
}