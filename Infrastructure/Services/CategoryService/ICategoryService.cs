using Domain.Models;

namespace Infrastructure.Services.CategoryService;

public interface ICategoryService
{
    List<Categories> GetCategories();
    Categories GetCategoryById(int id);
    string AddCategory(Categories categorie);
    string UpdateCategory(Categories categorie);
    bool DeleteCategory(int id);
}