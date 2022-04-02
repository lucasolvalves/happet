using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Happet.ViewModel;

namespace Happet.Controllers
{
    public class PetController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public PetController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var userEmail = await _userManager.FindByIdAsync(userId);

            var pets = GetPetsByUserId(userId);

            return View(pets);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete()
        {
            return RedirectToAction("Index", "Pet");
        }

        public IActionResult Adopt(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adopt()
        {
            return RedirectToAction("Index", "Pet");
        }

        private IEnumerable<PetsGridViewModel> GetPetsByUserId(string userId)
        {
            return new List<PetsGridViewModel>()
            {
                new PetsGridViewModel(){
                    IdPet = Guid.NewGuid(),
                    Name = "Pipoca",
                    Breed = "SRD",
                    Color = "Amarelo",
                    Type = "Cachorro",
                    Genre = "Fêmea",
                    Status = "Ativo",
                    Viewer = true,
                    Edit = true,
                    Delete = true
                }
            };
        }
    }
}
