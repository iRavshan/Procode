using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.DTO;
using Procode.Data.Interfaces;
using Procode.Domain.Models;
using Procode.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Procode.Controllers
{

    public class AccountController : Controller
    {
        private readonly IUserRepository userRepos;

        public AccountController(IUserRepository userRepos)
        {
            this.userRepos = userRepos;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel
            {
                PageTitle = "Hisobga kirish"
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "user@gmail.com" && model.Password == "Ravshan-01981")
                {
                    var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.Name, "Ravshan")
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home");
                }

            }

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
