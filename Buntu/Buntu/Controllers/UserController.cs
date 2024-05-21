using Buntu.Core.Contracts;
using Buntu.Core.Models.Follow;
using Buntu.Core.Models.Notification;
using Buntu.Core.Models.User;
using Buntu.Core.Models.UserInformation;
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
        private readonly IUserInformationService userInformationService;
        private readonly INotificationService notificationService; 

        public UserController(
            UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            IFollowService _followService,
            IUserInformationService _userInformationService,
            INotificationService _notificationService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            followService = _followService;
            userInformationService = _userInformationService;
            notificationService = _notificationService;
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

            await userInformationService.AddUserInformationAsync(new UserInformationModel() { UserId = user.Id });

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
        public async Task<IActionResult> Profile(string username, int notId = 0) 
        {
            var model = await userManager.FindByNameAsync(username);

            if (model == null)
                return BadRequest();

            if (notId != 0) 
            {
                try
                {
                    await notificationService.MarkNotificationAsReadAsync(notId);
                }
                catch (Exception)
                {
                }
            }

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
            else 
            {
                try
                {
                    await followService.AddFollowerAsync(new FollowModel() { UserId = userId, FollowerId = User.Id() });

                    var notification = new NotificationModel()
                    {
                        UserId = userId,
                        OtherUserId = User.Id(),
                        Type = "Follow",
                        RelatedId = 0
                    };

                    await notificationService.AddNotificationAsync(notification);
                }
                catch (Exception)
                {
                }
            }            

            return Json(new { success = success });
        }

        [HttpGet]
        public async Task<IActionResult> Notifications()
        {
            var model = await notificationService.GetUserNotificationsAsync(User.Id());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteNotification(int notId) 
        {
            try
            {
                await notificationService.DeleteNotificationAsync(notId);
            }
            catch (Exception)
            {
            }

            return RedirectToAction(nameof(Notifications));
        }
    }
}
