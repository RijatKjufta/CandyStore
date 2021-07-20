using Candystore.Entities;
using Candystore.Repository.Interfaces;
using Candystore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Candystore.Service
{
    public class WishlistService : IWishlistService
    {
        private readonly IWishlistRepository _wishlistRepository;

        public WishlistService(IWishlistRepository wishlistRepository)
        {
            _wishlistRepository = wishlistRepository;
        }
        public void Add(Wishlist wishlist)
        {
            _wishlistRepository.Add(wishlist);
        }

        public void Delete(int id)
        {
            _wishlistRepository.Delete(id);
        }

        public void DeleteByCandyId(int candyID)
        {
            _wishlistRepository.DeleteByCandyId(candyID);
        }
        public void DeleteByCoffeId(int coffeID)
        {
            _wishlistRepository.DeleteByCoffeId(coffeID);
        }
        public void DeleteByApetisaniId(int apetisaniID)
        {
            _wishlistRepository.DeleteByCandyId(apetisaniID);
        }

        public void Edit(Wishlist wishlist)
        {
            _wishlistRepository.Edit(wishlist);
        }

        public IEnumerable<Wishlist> GetAllCoffeProductsFromWishlistByUserId(string userId)
        {
            var result = _wishlistRepository.GetAllCoffeProductsFromWishlistByUserId(userId);
            return result;
        }
        public IEnumerable<Wishlist> GetAllCandyProductsFromWishlistByUserId(string userId)
        {
            var result = _wishlistRepository.GetAllCandyProductsFromWishlistByUserId(userId);
            return result;
        }
        public IEnumerable<Wishlist> GetAllApetisaniProductsFromWishlistByUserId(string userId)
        {
            var result = _wishlistRepository.GetAllApetisaniProductsFromWishlistByUserId(userId);
            return result;
        }

        public IEnumerable<Wishlist> GetAllWishlists()
        {
            var result = _wishlistRepository.GetAllWishlists();
            return result;
        }

        public Wishlist GetWishlistByCandyId(int candyID)
        {
            var result = _wishlistRepository.GetWishlistByCandyId(candyID);
            return result;
        }
        public Wishlist GetWishlistByCoffeId(int coffeID)
        {
            var result = _wishlistRepository.GetWishlistByCoffeId(coffeID);
            return result;
        }
        public Wishlist GetWishlistByApetisaniId(int apetisaniID)
        {
            var result = _wishlistRepository.GetWishlistByApetisaniId(apetisaniID);
            return result;
        }

        public Wishlist GetWishlistById(int id)
        {
            var result = _wishlistRepository.GetWishlistById(id);
            return result;
        }
    }
}
