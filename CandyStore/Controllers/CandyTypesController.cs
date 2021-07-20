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
    public class CandyTypesController : Controller
    {
        private readonly ICandyTypesService _candyTypesService;
        private readonly ILogger<CandyTypesController> _logger;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IWishlistService _wishlistService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CandyTypesController(ICandyTypesService candyTypesService, ILogger<CandyTypesController> logger, IShoppingCartService shoppingCartService, IWishlistService wishlistService, IHttpContextAccessor httpContextAccessor)
        {
            _candyTypesService = candyTypesService;
            _logger = logger;
            _shoppingCartService = shoppingCartService;
            _wishlistService = wishlistService;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var candies = _candyTypesService.GetAllCandy();

            return View(candies);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CandyTypes candy)
        {
            _candyTypesService.Add(candy);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var candytypes = _candyTypesService.GetCandyById(Id);
            return View(candytypes);
        }

        [HttpPost]
        public IActionResult Edit(CandyTypes candytypes)
        {
            _candyTypesService.Edit(candytypes);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var candytypes = _candyTypesService.GetCandyById(id);
            return View(candytypes);

        }
        [HttpPost]
        public IActionResult Delete(ApetisaniTypes apetisani)
        {
            _candyTypesService.Delete(apetisani.ID);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult UploadPhoto()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "CandyImages");
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
        public JsonResult AddCandyToWishlist(int id)
        {
            var getCandyById =
                _candyTypesService.GetCandyById(id);

            var CheckIfExistsInWishlist = _wishlistService.GetWishlistByCandyId(id);

            if (CheckIfExistsInWishlist == null)
            {
                // get logged in user id
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // get other data ids
                var candyId = getCandyById.ID;

                // init wishlist obj
                var wishlist = new Wishlist
                {
                    UserId = userId,
                    CandyId = candyId,
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
