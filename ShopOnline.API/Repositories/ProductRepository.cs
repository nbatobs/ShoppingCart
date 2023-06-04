using Microsoft.EntityFrameworkCore;
using ShopOnline.API.Data;
using ShopOnline.API.Entities;
using ShopOnline.API.Repositories.Contracts;

namespace ShopOnline.API.Repositories;

/*
 This code defines a class named ProductRepository that implements the IProductRepository interface. 
 The purpose of this class is to provide methods for accessing and retrieving data related to products and categories from a database using Entity Framework Core.

The ProductRepository class has a constructor that takes an instance of ShopOnlineDbContext as a parameter. This context represents the database context for the application
 */

public class ProductRepository:IProductRepository
{
    private readonly ShopOnlineDbContext shopOnlineDbContext;
    
    public ProductRepository(ShopOnlineDbContext shopOnlineDbContext)
    {
        this.shopOnlineDbContext = shopOnlineDbContext;
    }
    
    public async Task<IEnumerable<Product>> GetItems()
    {
        var products = await shopOnlineDbContext.Products.ToListAsync();

        return products;
    }

    public async Task<IEnumerable<ProductCategory>> GetCategories()
    {
        var categories = await shopOnlineDbContext.ProductCategories.ToListAsync();

        return categories;
    }

    public Task<Product> GetItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductCategory> GetCategory(int id)
    {
        throw new NotImplementedException();
    }
}