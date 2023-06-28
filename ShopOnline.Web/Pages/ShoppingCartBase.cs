using Microsoft.AspNetCore.Components;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;

namespace ShopOnline.Web.Pages;

public class ShoppingCartBase: ComponentBase
{
     [Inject]
     public IShoppingCartService _shoppingCartService { get; set; }
     
     public List<CartItemDto> ShoppingCartItems { get; set; }
     
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

     protected async Task DeleteCartItem_Click(int id)
     {
          var cartItemDto = await _shoppingCartService.DeleteItem(id);
          RemoveCartItem(id);
     }

     private CartItemDto GetCartItem(int id)
     {
          return ShoppingCartItems.FirstOrDefault(i => i.Id == id);
     }
     private async Task RemoveCartItem(int id)
     { 
          var cartItemDto = GetCartItem(id);

          ShoppingCartItems.Remove(cartItemDto);

     }
}