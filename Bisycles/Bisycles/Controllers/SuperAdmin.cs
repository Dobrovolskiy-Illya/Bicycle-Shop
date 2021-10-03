using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Controllers
{
    [Authorize(Roles = "super admin")]
    public class SuperAdmin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
