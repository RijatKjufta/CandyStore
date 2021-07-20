using Candystore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service.Interfaces
{
    public interface IWishlistService
    {
        void Add(Wishlist wishlist);
        void Edit(Wishlist wishlist);
        void Delete(int id);
        void DeleteByCandyId(int candyID);
        void DeleteByCoffeId(int coffeID);
        void DeleteByApetisaniId(int apetisaniID);
        Wishlist GetWishlistById(int id);
        Wishlist GetWishlistByCandyId(int candyID);
        Wishlist GetWishlistByCoffeId(int coffeID);
        Wishlist GetWishlistByApetisaniId(int apetisaniID);

        IEnumerable<Wishlist> GetAllWishlists();
        IEnumerable<Wishlist> GetAllCoffeProductsFromWishlistByUserId(string userId);
        IEnumerable<Wishlist> GetAllCandyProductsFromWishlistByUserId(string userId);
        IEnumerable<Wishlist> GetAllApetisaniProductsFromWishlistByUserId(string userId);

    }
}
