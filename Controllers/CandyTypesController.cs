using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyStore.Controllers
{
    public class CandyTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
