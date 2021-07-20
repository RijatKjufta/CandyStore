using Candystore.Entities;
using Candystore.Repository.Interfaces;
using Candystore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service
{
   public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void Add(ShoppingCart shoppingCart)
        {
            _shoppingCartRepository.Add(shoppingCart);
        }

        public void Delete(int Id)
        {
            _shoppingCartRepository.Delete(Id);
        }

        public void DeleteBycandyId(int productId)
        {
            _shoppingCartRepository.DeleteBycandyId(productId);
        }
        public void DeleteBycoffeId(int productId)
        {
            _shoppingCartRepository.DeleteBycoffeId(productId);
        }
        public void DeleteByapetisaniId(int productId)
        {
            _shoppingCartRepository.DeleteByapetisaniId(productId);
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCart()
        {
            var result = _shoppingCartRepository.GetAllItemsInCart();
            return result;
        }

        public IEnumerable<ShoppingCart> GetAllCandyItemsInCartByUserId(string userId)
        {
            var result = _shoppingCartRepository.GetAllCandyItemsInCartByUserId(userId);
            return result;
        }
        public IEnumerable<ShoppingCart> GetAllCoffeItemsInCartByUserId(string userId)
        {
            var result = _shoppingCartRepository.GetAllCoffeItemsInCartByUserId(userId);
            return result;
        }
        public IEnumerable<ShoppingCart> GetAllApetisaniItemsInCartByUserId(string userId)
        {
            var result = _shoppingCartRepository.GetAllApetisaniItemsInCartByUserId(userId);
            return result;
        }

        public ShoppingCart GetShoppingCartById(int Id)
        {
            var result = _shoppingCartRepository.GetShoppingCartById(Id);
            return result;
        }
    }
}
