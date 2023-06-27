using ShopOnline.API.Entities;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Extensions;

public static class DtoConversions
{
    public static IEnumerable<ProductDto> ConvertDto(this IEnumerable<Product> products,
        IEnumerable<ProductCategory> productCategories)
    {
        return (from product in products
            join productCategory in productCategories
                on product.CategoryId equals productCategory.Id
            select new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageURL = product.ImageURL,
                Price = product.Price,
                Qty = product.Qty,
                CategoryId = product.CategoryId,
                CategoryName = productCategory.Name
            }).ToList();
    }

    public static ProductDto ConvertToDto(this Product product, ProductCategory productCategory)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            ImageURL = product.ImageURL,
            Price = product.Price,
            Qty = product.Qty,
            CategoryId = product.CategoryId,
            CategoryName = productCategory.Name
        };
    }

    public static IEnumerable<CartItemDto> ConvertToDto( this IEnumerable<CartItem> cartItems, IEnumerable<Product> products)
    {
        return (from cartItem in cartItems
                join product in products
                    on cartItem.ProductId equals product.Id
                    select new CartItemDto
                    {
                        Id = cartItem.Id,
                        ProductId = cartItem.ProductId,
                        ProductName = product.Name,
                        ProductDescription = product.Description,
                        ProductImageURL = product.ImageURL,
                        Price = product.Price,
                        CartId = cartItem.CartId,
                        Qty = cartItem.Qty,
                        TotalPrice = product.Price * cartItem.Qty
                    }).ToList();
    }
    
    public static CartItemDto ConvertToDto(this CartItem cartItem,
        Product product)
    {
        return new CartItemDto
        {
            Id = cartItem.Id,
            ProductId = cartItem.ProductId,
            ProductName = product.Name,
            ProductDescription = product.Description,
            ProductImageURL = product.ImageURL,
            Price = product.Price,
            CartId = cartItem.CartId,
            Qty = cartItem.Qty,
            TotalPrice = product.Price * cartItem.Qty
        };
    }
}
/* This code defines an extension method ConvertDto within a static class DtoConversions.
 The purpose of this method is to convert a collection of Product entities into a collection of ProductDto objects.

The ConvertDto method takes two parameters: products, which is an IEnumerable of Product objects, and productCategories, which is an IEnumerable of ProductCategory objects. 
It performs a join operation between the products and productCategories based on their CategoryId and Id properties, respectively.

Inside the select statement, a new ProductDto object is created for each matching pair of product and productCategory. 
The properties of the ProductDto object are populated with values from the corresponding Product and ProductCategory objects.

Finally, the result of the conversion is returned as a List of ProductDto objects.

To summarize, this code provides a method that converts a collection of Product entities into a collection of ProductDto objects by performing a join operation with a collection of ProductCategory entities and mapping the properties accordingly.
*/
