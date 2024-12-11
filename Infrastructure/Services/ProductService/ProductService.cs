using Domain.Models;
using Dapper;
using Infrastructure.DataContext;
namespace Infrastructure.Services.ProductService;

public class ProductService:IProductService
{

    DapperContext dapperContext = new DapperContext();
    
    public List<Products> GetProducts()
    {
          

        var sql = "Select * from Products ";
        var result =dapperContext.Connection().Query<Products>(sql);
        return result.ToList();
    }

    public Products GetProductById(int id)
    {
        var sql = $"Select * from Products where id={@id} ";
        var result =dapperContext.Connection().QueryFirstOrDefault<Products>(sql);
        return result;
    }

    public string AddProduct(Products product)
    {
        var sql = $"INSERT INTO Products (name,price,marketid,categoryid)" +
                  $"values('{product.Name}', {product.Price}, {product.MarketId}, {product.CategoryId})";
        var result =dapperContext.Connection().Execute(sql);
        if (result > 0) return "Successfully added student";
        return "Failed to add student";

    }

    public string UpdateProduct(Products product)
    {
        var sql = $"Update Students SET  name='{product.Name}'" +
                  $", price={product.Price},marketid={product.MarketId}" +
                  $",categoryid={product.CategoryId} " +
                  $"where id={product.Id}";
            
        var result = dapperContext.Connection().Execute(sql);
        if (result > 0) return "Successfully updated product";
        return "Failed to update product";
    }

    public bool DeleteProduct(int id)
    {
        var sql = $"delete  from Products  as p where p.id={@id}";
        var result = dapperContext.Connection().Execute(sql);
        if(result>0) return true;
        return false;
    }
}