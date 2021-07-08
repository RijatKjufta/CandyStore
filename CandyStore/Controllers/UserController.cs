using Candystore.Entities.Logger;
using CandyStore.Areas.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Controllers
{
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private IPasswordHasher<IdentityUser> _passwordHasher;
        private readonly ILogger<UserController> _logger;

        public UserController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IPasswordHasher<IdentityUser> passwordHasher,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }
        // GET: UserController
        public ActionResult Index()
        {
            var users = _userManager.Users;
            _logger.LogInformation(loggerMessageDisplay.UsersListed) ;

            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            var roles = _roleManager.Roles;
            var userModel = new UserModel();
            userModel.Roles = GetSelectListRoles(roles, null);

            return View(userModel);
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                    EmailConfirmed = true
                };

                // istoto sto i gore
                //IdentityUser appUser = new IdentityUser();
                //appUser.UserName = user.Name;
                //appUser.Email = user.Email;
                //appUser.EmailConfirmed = true;

                IdentityResult result = await _userManager.CreateAsync(appUser, user.Password);
                _logger.LogInformation(loggerMessageDisplay.UserCreated);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, user.RoleName);
                    _logger.LogInformation(loggerMessageDisplay.UserAddedRole);

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    _logger.LogError(loggerMessageDisplay.UserNotCreatedModelStateInvalid) ;
                }
            }
            return View(user);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        #region Helper Methods

        private IQueryable<SelectListItem> GetSelectListRoles(IQueryable<IdentityRole> roles, string? currentRoleName)
        {
            var selectList = new List<SelectListItem>();
            selectList.Add(new SelectListItem
            {
                Value = "0",
                Text = "Select role...",
                Selected = false
            });
            foreach (var item in roles)
            {
                if (currentRoleName != null)
                {
                    if (item.Name.Equals(currentRoleName))
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = item.Id,
                            Text = item.Name,
                            Selected = true
                        });
                    }
                    else
                    {
                        selectList.Add(new SelectListItem
                        {
                            Value = item.Id,
                            Text = item.Name,
                            Selected = false
                        });
                    }
                }
                else
                {
                    selectList.Add(new SelectListItem
                    {
                        Value = item.Id,
                        Text = item.Name,
                        Selected = false
                    });
                }
            }

            return selectList.AsQueryable();
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        #endregion
    }


}


