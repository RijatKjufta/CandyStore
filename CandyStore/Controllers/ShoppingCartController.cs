using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Candystore.Service.Interfaces;
using Candystore.Entities;
using System.Security.Claims;
using CandyStore.Models;


namespace CandyStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICandyTypesService _candyTypesService;
        private readonly ICoffeTypesService _coffeTypesService;
        private readonly IApetisaniService _apetisaniService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;

        public ShoppingCartController(IWishlistService wishlistService, IHttpContextAccessor httpContextAccessor, ICandyTypesService candyTypesService, ICoffeTypesService coffeTypesService, IApetisaniService apetisaniService, IShoppingCartService shoppingCartService, IOrderService orderService)
        {
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
            _candyTypesService = candyTypesService;
            _coffeTypesService = coffeTypesService;
            _apetisaniService = apetisaniService;
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
        }

        public IActionResult Index()
        {

            List<CandyTypes> AllCandyListFromCartByLoggedInUser = new List<CandyTypes>();
            List<CoffeTypes> AllCoffeListFromCartByLoggedInUser = new List<CoffeTypes>();
            List<ApetisaniTypes> AllApetisaniListFromCartByLoggedInUser = new List<ApetisaniTypes>();

            //Tuple<CandyTypes, CoffeTypes, ApetisaniTypes> AllProductsListFromCartByLoggedInUser;


            var TotalPriceCountCandy = 0.0;
            var TotalPriceCountCoffe = 0.0;
            var TotalPriceCountApetisani = 0.0;
            var TotalPriceOfAllTables = 0.0;

            //double TotalShipping = 0.0;
            int NotificationCounter = 0;

            // get logged in user id

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //var userIdCandyProducts = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userIdCoffeProducts = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var userIdApetisaniProducts = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var CandyitemsInCart = _shoppingCartService.GetAllCandyItemsInCartByUserId(userId);
            var CoffeitemsInCart = _shoppingCartService.GetAllCoffeItemsInCartByUserId(userId);
            var ApetisaniitemsInCart = _shoppingCartService.GetAllApetisaniItemsInCartByUserId(userId);

            // convert all cart items to list of books

            AllCandyListFromCartByLoggedInUser = _orderService.ConvertAllItemsOfCandyInCartToList(CandyitemsInCart);
            AllCoffeListFromCartByLoggedInUser = _orderService.ConvertAllItemsOfCoffeInCartToList(CoffeitemsInCart);
            AllApetisaniListFromCartByLoggedInUser = _orderService.ConvertAllItemsOfApetisaniInCartToList(ApetisaniitemsInCart);

            // calculate total price of books in cart
            TotalPriceCountCandy = _orderService.CalculateTotalPriceCandy(AllCandyListFromCartByLoggedInUser);
            TotalPriceCountCoffe = _orderService.CalculateTotalPriceCoffe(AllCoffeListFromCartByLoggedInUser);
            TotalPriceCountApetisani = _orderService.CalculateTotalPriceApetisani(AllApetisaniListFromCartByLoggedInUser);



            // notification counter for items in cart
            NotificationCounter = _shoppingCartService.GetAllItemsInCart().Count();

            // convert all cart items to list of books
            //AllProductsListFromCartByLoggedInUser = _orderService.ConvertAllItemsInCartToList(itemsInCart);

            TotalPriceOfAllTables = TotalPriceCountCandy + TotalPriceCountCoffe + TotalPriceCountApetisani * 100 / 100;

            //TotalPriceCount = Math.Round(AllProductsListFromCartByLoggedInUser.Item1.price + AllProductsListFromCartByLoggedInUser.Item2.Price + AllProductsListFromCartByLoggedInUser.Item3.price);
            //NotificationCounter = _shoppingCartService.GetAllItemsInCart().Count();

            var shopCartViewModel = new ProductModel()
            {
                //AllProductsFromWishlistByLoggedInUser = AllProductsListFromCartByLoggedInUser,

                AllCandyFromWishlistByLoggedInUser = AllCandyListFromCartByLoggedInUser,
                AllCoffeFromWishlistByLoggedInUser = AllCoffeListFromCartByLoggedInUser,
                AllApetisaniFromWishlistByLoggedInUser = AllApetisaniListFromCartByLoggedInUser,


                WishlistTotalPriceOfAllTables = TotalPriceOfAllTables,

                //AddToCartTotalCounter = NotificationCounter
            };

            //var subTotal = _orderService.CalculateTotalShipping(TotalWeightCount, TotalPriceCount).Item1;
            //var shippingTotal = _orderService.CalculateTotalShipping(TotalWeightCount, TotalPriceCount).Item2;
            //var totalPrice = _orderService.CalculateTotalShipping(TotalWeightCount, TotalPriceCount).Item3;


            //shopCartViewModel.TotalPrice = totalPrice;
            //shopCartViewModel.SubTotal = subTotal;
            //shopCartViewModel.ShippingTotal = shippingTotal;

            ViewData["Counter"] = NotificationCounter;

            return View(shopCartViewModel);
            //return View();
        }


        public JsonResult AddApetisanToShoppingCart(int id)
        {
            // get book
            var getApetisanById = _apetisaniService.GetApetisaniById(id);
            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // get other data ids
            var apetisanId = getApetisanById.ID;

            //var publisherId = getBookById.PublisherID;
            //var authorId = getBookById.AuthorID;
            //var categoryId = getBookById.CategoryID;

            // init shopping cart obj
            var shoppingCart = new ShoppingCart
            {
                UserId = userId,
                ApetisaniId = apetisanId,
                Price = getApetisanById.price,
                DateAdded = DateTime.Now
            };

            // add to shopping cart
            _shoppingCartService.Add(shoppingCart);

            return new JsonResult(new { data = shoppingCart });
        }

        public JsonResult AddCandyToShoppingCart(int id)
        {
            // get book
            var getCandyById = _candyTypesService.GetCandyById(id);
            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // get other data ids
            var CandyID = getCandyById.ID;

            //var publisherId = getBookById.PublisherID;
            //var authorId = getBookById.AuthorID;
            //var categoryId = getBookById.CategoryID;

            // init shopping cart obj
            var shoppingCart = new ShoppingCart
            {
                UserId = userId,
                CandyId = CandyID,
                Price = getCandyById.price,
                DateAdded = DateTime.Now
            };

            // add to shopping cart
            _shoppingCartService.Add(shoppingCart);

            return new JsonResult(new { data = shoppingCart });
        }

        public JsonResult AddCoffeToShoppingCart(int id)
        {
            // get book
            var getCoffeById = _coffeTypesService.GetCoffeById(id);
            // get logged in user id
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // get other data ids
            var CoffeeID = getCoffeById.ID;

            //var publisherId = getBookById.PublisherID;
            //var authorId = getBookById.AuthorID;
            //var categoryId = getBookById.CategoryID;

            // init shopping cart obj
            var shoppingCart = new ShoppingCart
            {
                UserId = userId,
                CoffeId = CoffeeID,
                Price = getCoffeById.Price,
                DateAdded = DateTime.Now
            };

            // add to shopping cart
            _shoppingCartService.Add(shoppingCart);

            return new JsonResult(new { data = shoppingCart });
        }

        [HttpPost]
        public JsonResult Delete(int Id)
        {
            var getCandy = _candyTypesService.GetCandyById(Id);

            _shoppingCartService.DeleteBycandyId(Id);            
            // ~/ShoppingCart/Index
            return new JsonResult(new { data = getCandy, url = Url.Action("Index", "ShoppingCart") });
        }

        [HttpPost]
        public JsonResult DeleteCoffe(int Id)
        {
            var getCoffe = _coffeTypesService.GetCoffeById(Id);

            _shoppingCartService.DeleteBycoffeId(Id);
            // ~/ShoppingCart/Index
            return new JsonResult(new { data = getCoffe, url = Url.Action("Index", "ShoppingCart") });
        }

        [HttpPost]
        public JsonResult DeleteApetisan(int Id)
        {
            var getapetisan = _apetisaniService.GetApetisaniById(Id);

            _shoppingCartService.DeleteByapetisaniId(Id);
            // ~/ShoppingCart/Index
            return new JsonResult(new { data = getapetisan, url = Url.Action("Index", "ShoppingCart") });
        }

        public IActionResult Buy()
        {
            return RedirectToAction("Create", "Order");
        }

    }
}
