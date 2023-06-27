using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages;

public class ShoppingCartBase: ComponentBase
{
     [Inject]
     public IShoppingCartService _shoppingCartService { get; set; }
     
     public IEnumerable<CartItemDto> ShoppingCartItems { get; set; }
     
     public string ErrorMessage { get; set; }

     protected override async Task OnInitializedAsync()
     {
          try
          {
               ShoppingCartItems = await _shoppingCartService.GetItems(HardCoded.UserId);
          }
          catch (Exception ex)
          {
               ErrorMessage = ex.Message;
          }
     }
}