using Buntu.Core.Contracts;
using Buntu.Core.Enums;
using Buntu.Core.Models.Comment;
using Buntu.Core.Models.FavoritePost;
using Buntu.Core.Models.Like;
using Buntu.Core.Models.Notification;
using Buntu.Core.Models.Post;
using Buntu.Infrastructure.Data.Models;
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
        private readonly INotificationService notificationService;
        private readonly IFollowService followService;

        public PostController(
            IPostService _postService, 
            ILikeService _likeService,
            ICommentService _commentService,
            IFavoritePostService _favoritePostService,
            INotificationService _notificationService,
            IFollowService _followService)
        {
            postService = _postService;
            likeService = _likeService;
            commentService = _commentService;
            favoritePostService = _favoritePostService;
            notificationService = _notificationService;
            followService = _followService;
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

            var like = await likeService.GetLikeByPostAndUserIdAsync(postId, User.Id());
            var post = await postService.GetPostByIdAsync(postId);
            var notification = new NotificationModel()
            {
                UserId = post.UserId,
                OtherUserId = User.Id(),
                Type = "Like",
            };

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
                notification.RelatedId = like.Id;
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
                    notification.RelatedId = entity.Id;
                    operation = "add";
                }
                catch (Exception)
                {
                }

            }

            if (post.UserId != User.Id()) 
            {
                try
                {
                    await notificationService.AddNotificationAsync(notification);
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
                var like = await likeService.GetLikeByPostAndUserIdAsync(postId, User.Id());
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

                var post = await postService.GetPostByIdAsync(postId);
                var notification = new NotificationModel()
                {
                    UserId = post.UserId,
                    OtherUserId = User.Id(),
                    Type = "Comment",
                    RelatedId = postId
                };

                if (post.UserId != User.Id())
                {
                    await notificationService.AddNotificationAsync(notification);                    
                }

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

        [HttpGet]
        public IActionResult Add() 
        {
            var model = new PostFormModel()
            {
                Statuses = postService.GetStatusesAsync<PostStatus>()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(PostFormModel model) 
        {
            model.UserId = User.Id();

            if (!ModelState.IsValid) 
            {
                model.Statuses = postService.GetStatusesAsync<PostStatus>();

                return View(model);
            }

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    model.ImageFile.CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();

                    model.Image = imageBytes;

                    try
                    {
                        await postService.AddPostAsync(model);

                        var followers = await followService.GetUserFollowersAsync(User.Id());
                        foreach (var follower in followers)
                        {
                            var notification = new NotificationModel()
                            {
                                UserId = follower.FollowerId,
                                OtherUserId = User.Id(),
                                Type = "Post",
                                RelatedId = model.Id
                            };

                            await notificationService.AddNotificationAsync(notification);
                        }
                    }
                    catch (Exception)
                    {
                        model.Statuses = postService.GetStatusesAsync<PostStatus>();
                        return View(model);
                    }
                }
                return RedirectToAction(nameof(Home));
            }

            model.Statuses = postService.GetStatusesAsync<PostStatus>();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int postId, int notId) 
        {
            var post = await postService.GetPostByIdAsync(postId);

            if (post != null) 
            {
                try
                {
                    await notificationService.MarkNotificationAsReadAsync(notId);
                }
                catch (Exception)
                {
                    return RedirectToAction("Notifications","User");
                }

                return View(post);
            }

            return RedirectToAction("Notifications", "User");
        }
    }
}
