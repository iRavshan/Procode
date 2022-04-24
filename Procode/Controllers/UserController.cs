using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.DTO.Requests;
using Procode.Data.Interfaces;
using Procode.Domain.Models;
using Procode.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Procode.Controllers
{
    [Route("{Username}/[action]")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepo;
        private readonly IPostRepository postRepo;

        public UserController(IUserRepository userRepo, IPostRepository postRepo)
        {
            this.userRepo = userRepo;
            this.postRepo = postRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            Guid Id = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            User user = await userRepo.GetById(Id);

            SettingsViewModel model = new SettingsViewModel
            {
                Username = user.Username,
                Email = user.Email
            };

            return View(model);
        }

        public IActionResult Profile()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewPost(Post post)
        {
            if (ModelState.IsValid)
            {
                Post exPost = new Post
                {
                    Id = Guid.NewGuid(),
                    Title = post.Title,
                    ShortDescription = post.ShortDescription,
                    Tags = post.Tags,
                    Text = post.Text,
                    AuthorUsername = User.Identity.Name,
                    CreatedTime = DateTime.Now
                };

                await postRepo.Create(exPost);

                return RedirectToAction("blog", "home");
            }

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
    }
}
