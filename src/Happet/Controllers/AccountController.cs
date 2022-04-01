using Happet.Extensions;
using Happet.Interfaces;
using Happet.Models;
using Happet.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Happet.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAccountRepository _accountRepository;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountRepository = accountRepository;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
                return View();

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, true, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                TempData["error-message"] = "Usuário ou senha Inválidos.";
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            if (returnUrl != null)
                return LocalRedirect(returnUrl);
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetProfile(ETypePeople typePeople)
        {
            if (typePeople == ETypePeople.Adopter)
                return RedirectToAction("RegisterAdopter");
            else
                return RedirectToAction("RegisterNgo");
        }

        public ActionResult RegisterAdopter()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdopter(RegisterAdopterViewModel registerAdopterViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var newUser = new IdentityUser { UserName = registerAdopterViewModel.Email, Email = registerAdopterViewModel.Email };

            if (!await CreateUser(newUser, registerAdopterViewModel.Password))
                return View();

            registerAdopterViewModel.UserId = newUser.Id;
            await _accountRepository.AddAdopterAsync(registerAdopterViewModel.ToAdopter());

            return RedirectToAction("Login");
        }

        public ActionResult RegisterNgo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterNgo(RegisterNgoViewModel registerNgoViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            var newUser = new IdentityUser { UserName = registerNgoViewModel.FantasyName, Email = registerNgoViewModel.Email };

            if (!await CreateUser(newUser, registerNgoViewModel.Password))
                return View();

            registerNgoViewModel.UserId = newUser.Id;
            await _accountRepository.AddNgoAsync(registerNgoViewModel.ToNgo());

            return RedirectToAction("Login");
        }

        private async Task<bool> CreateUser(IdentityUser identityUser, string password)
        {
            var identityResult = await _userManager.CreateAsync(identityUser, password);

            if (!identityResult.Succeeded)
                TempData["error-message"] = identityResult.Errors.Select(x => x.Description).ToList();

            return identityResult.Succeeded;
        }
    }
}
