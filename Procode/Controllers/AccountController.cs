using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.DTO;
using Procode.Data.DTO.Requests;
using Procode.Data.DTO.Responses;
using Procode.Data.Interfaces;
using Procode.Domain.Models;
using Procode.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Procode.Controllers
{

    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel
            {
                PageTitle = "Hisobga kirish"
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private readonly IUserRepository userRepos;

        public AccountController(IUserRepository userRepos)
        {
            this.userRepos = userRepos;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserLoginRequest request = new UserLoginRequest
                {
                    Email = model.Email,
                    Password = model.Password
                };

                AuthResponse res = await userRepos.Login(request);

                if (res.Succes)
                {

                    User user = new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "iRavshan"
                    };

                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.GivenName, user.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, "user")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserRegisterRequest request = new UserRegisterRequest
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmedPassword = model.ConfirmedPassword
                };

                AuthResponse res = await userRepos.Register(request);

                if (res.Succes)
                {

                    User user = new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "iRavshan"
                    };

                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.GivenName, user.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, "user")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }


        private JwtSecurityToken DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var claimToken = handler.ReadToken(token) as JwtSecurityToken;
            return claimToken;
        }
    }
}
