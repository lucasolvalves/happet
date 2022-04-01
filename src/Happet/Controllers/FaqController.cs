using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Controllers
{
    [AllowAnonymous]
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
