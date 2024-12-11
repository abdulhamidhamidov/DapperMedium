using Domain.Models;

namespace Infrastructure.Services.MarketService;

public interface IMarketService
{
    List<Markets> GetMarkets();
    Markets GetMarketById(int id);
    string AddMarket(Markets market);
    string UpdateMarket(Markets market);
    bool DeleteMarket(int id);
}