using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Repository.Interfaces
{
  public  interface IWishlistRepository
    {
        void Add(Wishlist wishlist);
        void Edit(Wishlist wishlist);
        void Delete(int id);
        IEnumerable<Wishlist> GetAllWishlists();
        Wishlist GetWishlistById(int id);
        Wishlist GetWishlistByCandyId(int candyID);
        Wishlist GetWishlistByCoffeId(int coffeID);
        Wishlist GetWishlistByApetisaniId(int apetisaniID);
        void DeleteByCandyId(int candyID);
        void DeleteByCoffeId(int coffeID);
        void DeleteByApetisaniId(int apetisaniID);

        // Important
        IEnumerable<Wishlist> GetAllCoffeProductsFromWishlistByUserId(string userId);
        IEnumerable<Wishlist> GetAllCandyProductsFromWishlistByUserId(string userId);
        IEnumerable<Wishlist> GetAllApetisaniProductsFromWishlistByUserId(string userId);
    }
}
