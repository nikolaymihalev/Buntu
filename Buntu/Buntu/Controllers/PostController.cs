using Buntu.Core.Contracts;
using Buntu.Core.Models.Like;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Buntu.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly ILikeService likeService;

        public PostController(
            IPostService _postService, 
            ILikeService _likeService)
        {
            postService = _postService;
            likeService = _likeService;
        }

        [HttpGet]
        public async Task<IActionResult> Home(int currentPage = 1)
        {
            var model = await postService.GetPostsForPageAsync(User.Id(), currentPage);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Like(string variant,int postId) 
        {
            int value = 0;
            string operation = "";

            switch (variant) 
            {
                case "Thumb": value = 1; break;
                case "Love": value = 2; break;
                case "Haha": value = 3; break;
                case "Wow": value = 4; break;
                case "Sad": value = 5; break;
                case "Angry": value = 6; break;
            }

            var like = await likeService.GetLikeByIdAsync(postId, User.Id());
            if (like != null)
            {
                var entity = new LikeAddModel()
                {
                    Id = like.Id,
                    PostId = postId,
                    UserId = User.Id(),
                    Variant = value
                };
                await likeService.EditLikeAsync(entity);
                operation = "edit";
            }
            else 
            {
                try
                {
                    var entity = new LikeAddModel()
                    {
                        PostId = postId,
                        UserId = User.Id(),
                        Variant = value
                    };
                    await likeService.AddLikeAsync(entity);
                    operation = "add";
                }
                catch (Exception)
                {
                }

            }

            return Json(new { success = true , operation = operation });
        }

        [HttpPost]
        public async Task<IActionResult> Unlike(int postId) 
        {
            string operation = "";
            try
            {
                var like = await likeService.GetLikeByIdAsync(postId, User.Id());
                if (like != null)
                {
                    await likeService.RemoveLikeAsync(postId, User.Id());
                    operation = "delete";
                }
            }
            catch (Exception)
            {
            }

            return Json(new { success = true, operation = operation });
        }

        [HttpPost]
        public async Task<IActionResult> Comment(int postId) 
        {
            return Json(new { success = true});
        }
    }
}
