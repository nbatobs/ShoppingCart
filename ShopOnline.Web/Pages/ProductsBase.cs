using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages;

public class ProductsBase:ComponentBase
{
    [Inject]
    public IProductService ProductService { get; set; }
    public IEnumerable<ProductDto> Products {get; set; }

    protected override async Task OnInitializedAsync()
    {
        Products = await ProductService.GetItems();
    }

    protected IEnumerable<IGrouping<int, ProductDto>> GetGroupedByProductsCategory()
    {
        return from product in Products
            group product by product.CategoryId
            into prodByCatGroup
            orderby prodByCatGroup.Key
            select prodByCatGroup;
    }

    protected string GetCategoryName(IGrouping<int, ProductDto> GroupedProductDtos)
    {
        return GroupedProductDtos.FirstOrDefault(pg => pg.CategoryId == GroupedProductDtos.Key).CategoryName;
    }
}