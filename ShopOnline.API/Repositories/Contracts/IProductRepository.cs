using ShopOnline.API.Entities;

namespace ShopOnline.API.Repositories.Contracts;

//Repository design patters are used to abstract data handling layout
//Repositories are classes or components that encapsulate the logic required to access data sources
//We can use repositories to centralise common data access functionality.
//This facilitates better unit testing and maintainability and extenability 

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetItems();
    Task<IEnumerable<ProductCategory>> GetCategories();
    Task<Product> GetItem(int id);
    Task<ProductCategory> GetCategory(int id);

}