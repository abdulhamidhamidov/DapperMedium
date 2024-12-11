using Domain.Models;

namespace Infrastructure.Services.ProductService;

public interface IProductService
{
    List<Products> GetProducts();
    Products GetProductById(int id);
    string AddProduct(Products product);
    string UpdateProduct(Products product);
    bool DeleteProduct(int id);
}