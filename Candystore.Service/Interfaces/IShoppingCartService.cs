using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service.Interfaces
{
    public interface IShoppingCartService
    {
        void Add(ShoppingCart shoppingCart);
        void Delete(int Id);
        void DeleteBycandyId(int candyId);
        void DeleteBycoffeId(int coffeId);
        void DeleteByapetisaniId(int apetisaniId);

        ShoppingCart GetShoppingCartById(int Id);

        IEnumerable<ShoppingCart> GetAllItemsInCart();

        IEnumerable<ShoppingCart> GetAllCandyItemsInCartByUserId(string userId);
        IEnumerable<ShoppingCart> GetAllCoffeItemsInCartByUserId(string userId);
        IEnumerable<ShoppingCart> GetAllApetisaniItemsInCartByUserId(string userId);


    }
}
