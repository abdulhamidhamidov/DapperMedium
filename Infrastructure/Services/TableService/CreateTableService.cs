using Dapper;
using Infrastructure.DataContext;

namespace Infrastructure.Services.TableService;

public class CreateTableService:ICreateTableService
{
    private readonly DapperContext _context;

    public CreateTableService()
    {
        _context = new DapperContext();
    }
    public string CreateTable(string code)
    {
        _context.Connection().Execute(code);
        return "Successfully created table";
    }
}