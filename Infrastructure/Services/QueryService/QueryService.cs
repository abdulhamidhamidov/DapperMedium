
using Infrastructure.DataContext;

namespace Infrastructure.Services.QueryService;

public class QueryService : IQueryService
{
    private readonly DapperContext _context;

    public QueryService()
    {
        _context = new DapperContext();
    }

   
}