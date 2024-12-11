using Dapper;
using Domain.Models;
using Infrastructure.DataContext;

namespace Infrastructure.Services.CategoryService;

public class CategoryService:ICategoryService
{
    private readonly DapperContext _context;
    public CategoryService()
    {
        _context= new DapperContext();
    }
    public List<Categories> GetCategories()
    {
        var sql = "Select * from categories";
        var selected = _context.Connection().Query<Categories>(sql).ToList();
        return selected;

    }

    public Categories GetCategoryById(int id)
    {
        var sql = $"Select * from categories where id = @id";
        var selected = _context.Connection().QueryFirstOrDefault(sql);
        return selected;
    }

    public string AddCategory(Categories categorie)
    {
        var sql = $"Insert into categories(name)"+
                  $"values('{categorie.Name}')";
        var inserted = _context.Connection().Execute(sql);
        if (inserted > 0) return "Added Ok";
        return "Error";
    }

    public string UpdateCategory(Categories categorie)
    {
        var sql = $"Update categories set name = {categorie.Name}";
        var updated = _context.Connection().Execute(sql);
        if(updated > 0) return "Updated Ok";
        return "Error";;
    }

    public bool DeleteCategory(int id)
    {
        var sql = $"Delete from categories where id = @id";
        var deleted = _context.Connection().Execute(sql);
        if(deleted > 0) return true;
        return false;
    }
}