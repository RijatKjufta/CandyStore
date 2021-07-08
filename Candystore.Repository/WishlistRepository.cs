using Candystore.Data;
using Candystore.Entities;
using Candystore.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Candystore.Repository
{
    public class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _dataContext;

        public WishlistRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Wishlist wishlist)
        {
            _dataContext.Wishlists.Add(wishlist);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var wishlist = GetWishlistById(id);
            _dataContext.Wishlists.Remove(wishlist);
            _dataContext.SaveChanges();
        }

        public void DeleteByCandyId(int Id)
        {
            var wishlist = GetWishlistByCandyId(Id);
            _dataContext.Wishlists.Remove(wishlist);
            _dataContext.SaveChanges();
        }
        public void DeleteByCoffeId(int Id)
        {
            var wishlist = GetWishlistByCoffeId(Id);
            _dataContext.Wishlists.Remove(wishlist);
            _dataContext.SaveChanges();
        }
        public void DeleteByApetisaniId(int Id)
        {
            var wishlist = GetWishlistByApetisaniId(Id);
            _dataContext.Wishlists.Remove(wishlist);
            _dataContext.SaveChanges();
        }

        public void Edit(Wishlist wishlist)
        {
            _dataContext.Wishlists.Update(wishlist);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Wishlist> GetAllCoffeProductsFromWishlistByUserId(string userId)
        {
            var result = _dataContext.Wishlists.AsEnumerable().Where(x => x.UserId == userId)
                .DistinctBy(x => x.CoffeId);
            return result;
        }
        public IEnumerable<Wishlist> GetAllCandyProductsFromWishlistByUserId(string userId)
        {
            var result = _dataContext.Wishlists.AsEnumerable().Where(x => x.UserId == userId)
                .DistinctBy(x => x.CandyId);
            return result;
        }
        public IEnumerable<Wishlist> GetAllApetisaniProductsFromWishlistByUserId(string userId)
        {
            var result = _dataContext.Wishlists.AsEnumerable().Where(x => x.UserId == userId)
                .DistinctBy(x => x.ApetisaniId);
            return result;
        }

        public IEnumerable<Wishlist> GetAllWishlists()
        {
            var result = _dataContext.Wishlists.AsEnumerable();
            return result;
        }

        public Wishlist GetWishlistById(int id)
        {
            var result = _dataContext.Wishlists.FirstOrDefault(x => x.ID == id);
            return result;
        }

        public Wishlist GetWishlistByCandyId(int candyID)
        {
            var result = _dataContext.Wishlists.FirstOrDefault(x => x.ID == candyID);
            return result;
        }
        public Wishlist GetWishlistByCoffeId(int coffeID)
        {
            var result = _dataContext.Wishlists.FirstOrDefault(x => x.ID == coffeID);
            return result;
        }
        public Wishlist GetWishlistByApetisaniId(int apetisaniID)
        {
            var result = _dataContext.Wishlists.FirstOrDefault(x => x.ID == apetisaniID);
            return result;
        }
    }
}
