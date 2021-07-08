using Candystore.Entities;
using Candystore.Service.Interfaces;
using CandyStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CandyStore.Controllers
{
    public class ApetisaniTypesController : Controller
    {
        private readonly IApetisaniService _apetisaniService;
        private readonly ILogger<ApetisaniTypesController> _logger;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApetisaniTypesController(IApetisaniService apetisaniService, ILogger<ApetisaniTypesController> logger, IShoppingCartService shoppingCartService, IWishlistService wishlistService, IHttpContextAccessor httpContextAccessor)
        {
            _apetisaniService = apetisaniService;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var apetisani = _apetisaniService.GetAllProduct();

            return View(apetisani);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        //public IActionResult Create(ProductModel model)
        public IActionResult Create(ApetisaniTypes apetisani)
        {
            //var apetisani = new ApetisaniTypes();
            //apetisani.ID = model.ID;
            //apetisani.ApetisaniProduct = model.ApetisaniProduct;
            //apetisani.price = model.price;

            _apetisaniService.Add(apetisani);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var apetisani = _apetisaniService.GetApetisaniById(id);
            return View(apetisani);
        }

        [HttpPost]
        public IActionResult Edit(ApetisaniTypes apetisani)
        {
            _apetisaniService.Edit(apetisani);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var apetisani = _apetisaniService.GetApetisaniById(id);
            return View(apetisani);

        }
        [HttpPost]
        public IActionResult Delete(ApetisaniTypes apetisani)
        {
            _apetisaniService.Delete(apetisani.ID);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "ApetisaniImages");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = fileName;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error: " + ex);
            }
        }

        [HttpPost]
        public JsonResult AddApetisanToWishlist(int id)
        {
            var getApetisaniById =
                _apetisaniService.GetApetisaniById(id);

            var CheckIfExistsInWishlist = _wishlistService.GetWishlistByApetisaniId(id);

            if (CheckIfExistsInWishlist == null)
            {
                // get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // get other data ids
                var apetisaniId = getApetisaniById.ID;
                
                // init wishlist obj
                var wishlist = new Wishlist
                {
                    UserId = userId,
                    ApetisaniId = apetisaniId,
                    DateAdded = DateTime.Now
                };

                // add to wishlist
                _wishlistService.Add(wishlist);

                return new JsonResult(new { data = wishlist });
            }
            else
            {
                return new JsonResult(new { data = "" });
            }
        }

    }
}

