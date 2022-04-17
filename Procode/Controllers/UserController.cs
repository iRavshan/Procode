using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.DTO.Requests;
using Procode.Data.Interfaces;
using Procode.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace Procode.Controllers
{
    [Route("{Username}/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepo;

        public UserController(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(SettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                ChangePasswordRequest request = new ChangePasswordRequest
                {
                    CurrentPassword = model.CurrentPassword,
                    NewPassword = model.NewPassword,
                    ConfirmNewPassword = model.ConfirmNewPassword
                };

                if (!model.NewPassword.Equals(model.ConfirmNewPassword))
                {
                    return View();
                }

                await userRepo.ChangePassword(request);

                return View();
            }

            return View();
        }

        public IActionResult Saveds()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            NewPostViewModel model = new NewPostViewModel
            {
                PageTitle = "Yangi post"
            };

            return View(model);
        }
    }
}
