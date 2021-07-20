using Candystore.Data;
using Candystore.Entities;
using Candystore.Repository.Interfaces;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candystore.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DataContext _dataContext;

        public ShoppingCartRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void Add(ShoppingCart shoppingCart)
        {
            _dataContext.Add(shoppingCart);
            _dataContext.SaveChanges();

        }

        public void Delete(int Id)
        {
            var shoppingCart = GetShoppingCartById(Id);
            _dataContext.ShoppingCarts.Remove(shoppingCart);
            _dataContext.SaveChanges();

        }

        public void DeleteBycandyId(int candyId)
        {
            var shoppingCart = GetShoppingCartByCandyId(candyId);
            _dataContext.ShoppingCarts.Remove(shoppingCart);
            _dataContext.SaveChanges();
        }
        public void DeleteBycoffeId(int coffeId)
        {
            var shoppingCart = GetShoppingCartByCoffeId(coffeId);
            _dataContext.ShoppingCarts.Remove(shoppingCart);
            _dataContext.SaveChanges();
        }
        public void DeleteByapetisaniId(int apetisaniId)
        {
            var shoppingCart = GetShoppingCartByApetisaniId(apetisaniId);
            _dataContext.ShoppingCarts.Remove(shoppingCart);
            _dataContext.SaveChanges();
        }

        public IEnumerable<ShoppingCart> GetAllItemsInCart()
        {
            var result = _dataContext.ShoppingCarts.AsEnumerable();
            return result;
        }

        public IEnumerable<ShoppingCart> GetAllCandyItemsInCartByUserId(string userId)
        {
            var result = _dataContext.ShoppingCarts.AsEnumerable().Where
                (x => x.UserId == userId).DistinctBy(x => x.CandyId);
            return result;
        }
        public IEnumerable<ShoppingCart> GetAllCoffeItemsInCartByUserId(string userId)
        {
            var result = _dataContext.ShoppingCarts.AsEnumerable().Where
                (x => x.UserId == userId).DistinctBy(x => x.CoffeId);
            return result;
        }
        public IEnumerable<ShoppingCart> GetAllApetisaniItemsInCartByUserId(string userId)
        {
            var result = _dataContext.ShoppingCarts.AsEnumerable().Where
                (x => x.UserId == userId).DistinctBy(x => x.ApetisaniId);
            return result;
        }

        public ShoppingCart GetShoppingCartById(int Id)
        {
            var result = _dataContext.ShoppingCarts.FirstOrDefault(x => x.ID == Id);
            return result;
        }

        public ShoppingCart GetShoppingCartByCandyId(int productID)
        {
            var result = _dataContext.ShoppingCarts.FirstOrDefault(x => x.CandyId == productID);
            return result;
        }
        public ShoppingCart GetShoppingCartByCoffeId(int productID)
        {
            var result = _dataContext.ShoppingCarts.FirstOrDefault(x => x.CoffeId == productID);
            return result;
        }
        public ShoppingCart GetShoppingCartByApetisaniId(int productID)
        {
            var result = _dataContext.ShoppingCarts.FirstOrDefault(x => x.ApetisaniId == productID);
            return result;
        }
    }
}
