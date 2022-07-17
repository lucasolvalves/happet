using Happet.Extensions;
using Happet.Interfaces;
using Happet.Models;
using Happet.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPetRepository _petRepository;

        public HomeController(ILogger<HomeController> logger, IPetRepository petRepository)
        {
            _logger = logger;
            _petRepository = petRepository;
        }

        public IActionResult Index(string filter)
        {
            var pets = GetPets();

            if (!string.IsNullOrEmpty(filter))
                return View(pets.Where(p => p.Name.Contains(filter)));

            return View(pets);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IEnumerable<DetailPetViewModel> GetPets()
        {
            return _petRepository.GetPets()
                .Where(x => x.Status == EStatusPet.Activated)
                .Select(item => item.ToViewModel());
        }
    }
}
