using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel
            {
                PageTitle = "Hisobga kirish"
            };

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel
            {
               PageTitle = "Ro'yxatdan o'tish"
            };

            return View(model);
        }

        private readonly IUserRepository userRepos;

        public AccountController(IUserRepository userRepos)
        {
            this.userRepos = userRepos;
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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
                
                if (!res.Succes)
                {
                    LoginViewModel exModel = new LoginViewModel
                    {
                        Email = model.Email,
                        Password = model.Password,
                        Error = res.Errors.ToArray()[0]
                    };

                    return View(exModel);
                }

                if (res.Succes)
                {
                    var name = DecodeToken(res.Token).Claims.First(claim => claim.Type == "given_name").Value;
                    var email = DecodeToken(res.Token).Claims.First(claim => claim.Type == "email").Value;
                    string id = DecodeToken(res.Token).Claims.First(claim => claim.Type == "nameid").Value.ToString();
                    string role = DecodeToken(res.Token).Claims.First(claim => claim.Type == "role").Value.ToString();

                    User user = new User
                    {
                        Id = new Guid(id),
                        Username = name,
                        Email = email
                    };

                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.GivenName, user.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, role),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            LoginViewModel newModel = new LoginViewModel
            {
                Email = model.Email,
                Password = model.Password,
                Error = string.Empty
            };

            return View(newModel);  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

                if (!res.Succes)
                {
                    RegisterViewModel exModel = new RegisterViewModel
                    {
                        Email = model.Email,
                        Password = model.Password,
                        ConfirmedPassword = model.ConfirmedPassword,
                        Username = model.Username,
                        Error = res.Errors.ToArray()[0],
                        PageTitle = "Ro'yxatdan o'tish"
                    };

                    return View(exModel);
                }

                if (res.Succes)
                {

                    var name = DecodeToken(res.Token).Claims.First(claim => claim.Type == "given_name").Value;
                    var email = DecodeToken(res.Token).Claims.First(claim => claim.Type == "email").Value;
                    string id = DecodeToken(res.Token).Claims.First(claim => claim.Type == "nameid").Value.ToString();
                    string role = DecodeToken(res.Token).Claims.First(claim => claim.Type == "role").Value.ToString();

                    User user = new User
                    {
                        Id = new Guid(id),
                        Username = name,
                        Email = email
                    };

                    var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.GivenName, user.Username),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Role, role),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Email, user.Email)
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
            }

            RegisterViewModel newModel = new RegisterViewModel
            {
                Email = model.Email,
                Password = model.Password,
                ConfirmedPassword = model.ConfirmedPassword,
                Username = model.Username,
                Error = string.Empty,
                PageTitle = "Ro'yxatdan o'tish"
            };

            return View(newModel);
        }

        private JwtSecurityToken DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var claimToken = handler.ReadToken(token) as JwtSecurityToken;
            return claimToken;
        }
    }
}
