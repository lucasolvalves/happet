using Happet.Extensions;
using Happet.Interfaces;
using Happet.Models;
using Happet.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Happet.Controllers
{
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

        public IActionResult Login()
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
                TempData["error-message-login"] = "Usuário ou senha Inválidos.";
                return View();
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
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
            await _accountRepository.AddAdopterAsync(registerAdopterViewModel.ToRegisterModel());

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

            var newUser = new IdentityUser { UserName = registerNgoViewModel.Email, Email = registerNgoViewModel.Email, };

            if (!await CreateUser(newUser, registerNgoViewModel.Password))
                return View();

            IEnumerable<Claim> claims = new List<Claim>()
            {
                new Claim("Pet", "Create"),
                new Claim("Pet", "Edit"),
                new Claim("Pet", "Delete"),
                new Claim("Pet", "DetailsAdopter"),
                new Claim("Donation", "View")
            };

            await _userManager.AddClaimsAsync(newUser, claims);

            registerNgoViewModel.UserId = newUser.Id;
            await _accountRepository.AddNgoAsync(registerNgoViewModel.ToRegisterModel());

            return RedirectToAction("Login");
        }

        private async Task<bool> CreateUser(IdentityUser identityUser, string password)
        {
            var identityResult = await _userManager.CreateAsync(identityUser, password);

            if (!identityResult.Succeeded)
                TempData["error-message-create-user"] = identityResult.Errors.Select(x => x.Description).ToList();

            return identityResult.Succeeded;
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var people = await _accountRepository.GetPeopleByUserIdAsync(userId);

            if (people.TypePeople == ETypePeople.Adopter)
            {
                var adopter = await _accountRepository.GetAdopterByPeopleIdAsync(people.Id);
                return View("EditAdopter", adopter.ToViewModelEdit());
            }
            else
            {
                var ngo = await _accountRepository.GetNgoByPeopleIdAsync(people.Id);
                return View("EditNgo", ngo.ToViewModelEdit());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdopter(EditAdopterViewModel editAdopterViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            if (string.IsNullOrEmpty(editAdopterViewModel.CurrentPassword) && string.IsNullOrEmpty(editAdopterViewModel.NewPassword))
            {
                await _accountRepository.UpdateAdopterAsync(editAdopterViewModel.ToEditModel());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (!await EditUser(editAdopterViewModel.Email, editAdopterViewModel.CurrentPassword, editAdopterViewModel.NewPassword))
                    return View();

                await _accountRepository.UpdateAdopterAsync(editAdopterViewModel.ToEditModel());
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNgo(EditNgoViewModel editNgoViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            if (string.IsNullOrEmpty(editNgoViewModel.CurrentPassword) && string.IsNullOrEmpty(editNgoViewModel.NewPassword))
            {
                await _accountRepository.UpdateNgoAsync(editNgoViewModel.ToEditModel());
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (!await EditUser(editNgoViewModel.Email, editNgoViewModel.CurrentPassword, editNgoViewModel.NewPassword))
                    return View();

                await _accountRepository.UpdateNgoAsync(editNgoViewModel.ToEditModel());
                return RedirectToAction("Index", "Home");
            }
        }

        private async Task<bool> EditUser(string email, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var identityResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!identityResult.Succeeded)
                TempData["error-message-edit-user"] = identityResult.Errors.Select(x => x.Description).ToList();

            return identityResult.Succeeded;
        }
    }
}