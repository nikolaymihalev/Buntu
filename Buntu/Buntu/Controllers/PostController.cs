using Buntu.Core.Contracts;
using Buntu.Core.Models.Comment;
using Buntu.Core.Models.FavoritePost;
using Buntu.Core.Models.Like;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Buntu.Controllers
{
    public class PostController : BaseController
    {
        private readonly IPostService postService;
        private readonly ILikeService likeService;
        private readonly ICommentService commentService;
        private readonly IFavoritePostService favoritePostService;

        public PostController(
            IPostService _postService, 
            ILikeService _likeService,
            ICommentService _commentService,
            IFavoritePostService _favoritePostService)
        {
            postService = _postService;
            likeService = _likeService;
            commentService = _commentService;
            favoritePostService = _favoritePostService;
        }

        [HttpGet]
        public async Task<IActionResult> Home(int currentPage = 1)
        {
            var model = await postService.GetPostsForPageAsync(User.Id(), false, currentPage);

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
        public async Task<IActionResult> Comment(int postId, string content) 
        {
            bool success = false;

            try
            {
                var comment = new CommentFormModel()
                {
                    Content = content,
                    PostId = postId,
                    UserId = User.Id()
                };

                await commentService.AddCommentAsync(comment);
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }

            return Json(new { success = success });
        }

        [HttpPost]
        public async Task<IActionResult> Favorite(int postId) 
        {
            bool success = true;

            if (await favoritePostService.IsFavoritePostExistsAsync(postId, User.Id()) == true)
            {
                var fvPost = await favoritePostService.GetFavoritePostAsync(postId, User.Id());

                if (fvPost != null)
                {
                    await favoritePostService.RemoveFavoriteAsync(fvPost.Id);
                }

                success = false;
            }
            else 
            {
                var newFv = new FavoritePostModel()
                {
                    PostId = postId,
                    UserId = User.Id()
                };

                await favoritePostService.AddFavoriteAsync(newFv);
            }            

            return Json(new { success = success });
        }

        [HttpGet]
        public async Task<IActionResult> Favorites() 
        {
            var model = await favoritePostService.GetUserFavoritePostsAsync(User.Id());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Liked()
        {
            var model = await likeService.GetUserLikedPostsAsync(User.Id());

            return View(model);
        }
    }
}
