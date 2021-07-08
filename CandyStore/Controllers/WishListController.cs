using System;
using System.Linq;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Candystore.Entities;
using CandyStore.Models;
using Candystore.Service.Interfaces;

namespace Bookstore.Controllers
{
    public class WishlistController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICandyTypesService _candyTypesService;
        private readonly ICoffeTypesService _coffeTypesService;
        private readonly IApetisaniService _apetisaniService;
        private readonly IShoppingCartService _shoppingCartService;

        public WishlistController(IWishlistService wishlistService, IHttpContextAccessor httpContextAccessor, ICandyTypesService candyTypesService, ICoffeTypesService coffeTypesService, IApetisaniService apetisaniService, IShoppingCartService shoppingCartService)
        {
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
            _candyTypesService = candyTypesService;
            _coffeTypesService = coffeTypesService;
            _apetisaniService = apetisaniService;
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            // init new array of books
            List<CandyTypes> AllCandyListFromWishlistByLoggedInUser = new List<CandyTypes>();
            List<CoffeTypes> AllCoffeListFromWishlistByLoggedInUser = new List<CoffeTypes>();
            List<ApetisaniTypes> AllApetisaniListFromWishlistByLoggedInUser = new List<ApetisaniTypes>();

            var TotalPriceCountCandy = 0.0;
            var TotalPriceCountCoffe = 0.0;
            var TotalPriceCountApetisani = 0.0;

            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var CoffeProductswishlists = _wishlistService.GetAllCoffeProductsFromWishlistByUserId(userId);
            var CandyProductswishlists = _wishlistService.GetAllCandyProductsFromWishlistByUserId(userId);
            var ApetisaniProductswishlists = _wishlistService.GetAllApetisaniProductsFromWishlistByUserId(userId);

            foreach (var item in CoffeProductswishlists)
            {
                var coffeProducts =
                    _coffeTypesService.GetCoffeById
                    (item.ID);
                if (coffeProducts != null)
                {
                    AllCoffeListFromWishlistByLoggedInUser.Add(coffeProducts);
                }
            }
            foreach (var item in CandyProductswishlists)
            {
                var candyProducts =
                    _candyTypesService.GetCandyById
                    (item.ID);
                if (candyProducts != null)
                {
                    AllCandyListFromWishlistByLoggedInUser.Add(candyProducts);
                }
            }
            foreach (var item in ApetisaniProductswishlists)
            {
                var apetisaniProducts =
                    _apetisaniService.GetApetisaniById
                    (item.ID);
                if (apetisaniProducts != null)
                {
                    AllApetisaniListFromWishlistByLoggedInUser.Add(apetisaniProducts);
                }
            }
            TotalPriceCountCandy = Math.Round(AllCandyListFromWishlistByLoggedInUser.Sum(x => x.price), 2);
            TotalPriceCountCoffe = Math.Round(AllCoffeListFromWishlistByLoggedInUser.Sum(x => x.Price), 2);
            TotalPriceCountApetisani = Math.Round(AllApetisaniListFromWishlistByLoggedInUser.Sum(x => x.price), 2);

            // init viewmodel

            var productViewModel = new ProductModel
            {
                AllCandyFromWishlistByLoggedInUser =
                AllCandyListFromWishlistByLoggedInUser,
                AllCoffeFromWishlistByLoggedInUser =
                AllCoffeListFromWishlistByLoggedInUser,
                AllApetisaniFromWishlistByLoggedInUser =
                AllApetisaniListFromWishlistByLoggedInUser,

                WishlistTotalPriceCandy =
                TotalPriceCountCandy,
                WishlistTotalPriceCoffe = TotalPriceCountCoffe,
                WishlistTotalPriceApetisani = TotalPriceCountApetisani,

                WishlistTotalPriceOfAllTables = TotalPriceCountCandy + TotalPriceCountCoffe + TotalPriceCountApetisani * 100 / 100
            };

            return View(productViewModel);
        }

        [HttpPost]
        public JsonResult DeleteCandy(int Id)
        {
            var getCandy =
                _candyTypesService.GetCandyById(Id);
            _wishlistService.DeleteByCandyId(Id);

            return new JsonResult(new { data = getCandy, url = Url.Action("Index", "Wishlist") });
        }
        [HttpPost]
        public JsonResult DeleteCoffe(int Id)
        {
            var getCoffe =
                _coffeTypesService.GetCoffeById(Id);
            _wishlistService.DeleteByCoffeId(Id);

            return new JsonResult(new { data = getCoffe, url = Url.Action("Index", "Wishlist") });
        }
        [HttpPost]
        public JsonResult DeleteApetisani(int Id)
        {
            var getApetisani =
                _apetisaniService.GetApetisaniById(Id);
            _wishlistService.DeleteByApetisaniId(Id);

            return new JsonResult(new { data = getApetisani, url = Url.Action("Index", "Wishlist") });
        }

        public JsonResult AddToCartFromWishlist(List<string> productsIds)
        {
            // add to temporary list
            List<string> productsIds_temp = productsIds;
            // get all book ids from bookIds / wishlist
            // and add to shopping cart table
            foreach (var product in productsIds_temp)
            {
                var getCandy =
                    _candyTypesService.GetCandyById(int.Parse(product));

                var getCoffe =
                    _coffeTypesService.GetCoffeById(int.Parse(product));

                var getApetisani =
                    _apetisaniService.GetApetisaniById(int.Parse(product));

                // get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // get other data ids

                var candyId = getCandy.ID;
                var coffeId = getCoffe.ID;
                var apetisaniId = getApetisani.ID;

                // init shopping cart obj
                var shoppingCart = new ShoppingCart
                {
                    UserId = userId,
                    CandyId = candyId,
                    CoffeId = coffeId,
                    ApetisaniId = apetisaniId,
                    PriceCandy = getCandy.price,
                    PriceCoffe = getCoffe.Price,
                    PriceApetisani = getApetisani.price,
                    DateAdded = DateTime.Now
                };

                // add single book from wishlist to shopping cart
                //_shoppingCartService.Add(shoppingCart);
            }

            // remove all selected items from wishlist
            foreach (var selectedItem in productsIds)
            {
                _wishlistService.DeleteByCandyId(int.Parse(selectedItem));
                _wishlistService.DeleteByCoffeId(int.Parse(selectedItem));
                _wishlistService.DeleteByApetisaniId(int.Parse(selectedItem));
            }

            return new JsonResult(new { data = "" });
        }

        public IActionResult GoToCart()
        {
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
