using Candystore.Entities;
using Candystore.Service.Interfaces;
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
    public class CoffeTypesController : Controller
    {
        private readonly ICoffeTypesService _coffeTypesService;
        private readonly ILogger<CoffeTypesController> _logger;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CoffeTypesController(ICoffeTypesService coffeTypesService, ILogger<CoffeTypesController> logger, IShoppingCartService shoppingCartService, IWishlistService wishlistService, IHttpContextAccessor httpContextAccessor)
        {
            _coffeTypesService = coffeTypesService;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var coffetypes = _coffeTypesService.GetAllCoffe();


            return View(coffetypes);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CoffeTypes coffetypes)
        {
            _coffeTypesService.Add(coffetypes);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var coffetypes = _coffeTypesService.GetCoffeById(id);
            return View(coffetypes);
        }

        [HttpPost]
        public IActionResult Edit(CoffeTypes coffetypes)
        {
            _coffeTypesService.Edit(coffetypes);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var coffetypes = _coffeTypesService.GetCoffeById(id);
            return View(coffetypes);

        }
        [HttpPost]
        public IActionResult Delete(CoffeTypes coffetypes)
        {
            _coffeTypesService.Delete(coffetypes.ID);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "CoffeImages");
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
        public JsonResult AddCoffeToWishlist(int id)
        {
            var getCoffeById =
                _coffeTypesService.GetCoffeById(id);

            var CheckIfExistsInWishlist = _wishlistService.GetWishlistByCoffeId(id);

            if (CheckIfExistsInWishlist == null)
            {
                // get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // get other data ids
                var coffeId = getCoffeById.ID;

                // init wishlist obj
                var wishlist = new Wishlist
                {
                    UserId = userId,
                    CoffeId = coffeId,
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

