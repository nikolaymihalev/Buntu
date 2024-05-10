using Buntu.Core.Contracts;
using Buntu.Core.Models.Follow;
using Buntu.Core.Models.User;
using Buntu.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Buntu.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IFollowService followService;

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IFollowService _followService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            followService = _followService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() 
        {
            if (User?.Identity?.IsAuthenticated ?? false) 
            {
                return RedirectToAction("Home", "Post");
            }

            var model = new RegisterModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel model) 
        {
            if (ModelState.IsValid == false) 
            {
                return View(model);
            }


            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Username,
            };

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string file = System.IO.Path.Combine(currentDirectory, @"..\..\..\Images\DefaultPicture.png");
            string filePath = Path.GetFullPath(file);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    user.ProfileImage = br.ReadBytes((int)fs.Length);
                }
            }

            var result = await userManager.CreateAsync(user, model.Password);

            foreach (var item in result.Errors) 
            {
                ModelState.AddModelError("", item.Description);
            }

            return RedirectToAction("Home", "Post");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() 
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Home", "Post");
            }

            var model = new LoginModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model) 
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded) 
                {
                    return RedirectToAction("Home", "Post");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile(string username) 
        {
            var model = await userManager.FindByNameAsync(username);

            if (model == null)
                return BadRequest();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Follow(string userId) 
        {
            bool success = true;

            if (await followService.IsProfileFollowedByUserAsync(userId, User.Id()) == true)
            {
                var follow = await followService.GetFollowAsync(userId, User.Id());
                if (follow != null)
                {
                    await followService.RemoveFollowerAsync(follow.Id);
                }

                success = false;
            }

            try
            {
                await followService.AddFollowerAsync(new FollowModel() { UserId = userId, FollowerId = User.Id() });
            }
            catch (Exception)
            {
            }

            return Json(new { success = success });
        }
    }
}
