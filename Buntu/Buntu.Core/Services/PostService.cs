using Buntu.Core.Contracts;
using Buntu.Core.Models.Comment;
using Buntu.Core.Models.Post;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILikeService likeService;
        private readonly ICommentService commentService;

        public PostService(
            IRepository _repository,
            UserManager<ApplicationUser> _userManager,
            ILikeService _likeService,
            ICommentService _commentService)
        {
            repository = _repository;
            userManager = _userManager;
            likeService = _likeService;
            commentService = _commentService;
        }

        public async Task AddPostAsync(PostFormModel model)
        {
            var post = new Post()
            {
                Content = model.Content,
                UserId = model.UserId,
                CreatedDate = DateTime.Now,
                Image = model.Image,
                Status = model.Status
            };

            try
            {
                await repository.AddAsync<Post>(post);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await repository.GetByIdAsync<Post>(id);

            if (post == null) 
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            await repository.DeleteAsync<Post>(post);
        }

        public async Task EditPostAsync(PostFormModel model)
        {
            var post = await repository.GetByIdAsync<Post>(model.Id);

            if (post == null)
            {
                throw new ArgumentException(ErrorMessageConstants.InvalidModelErrorMessage);
            }

            post.Content = model.Content;
            post.Image = model.Image;
            post.Status = model.Status;

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostInfoModel>> GetAllUserPostsAsync(string userId)
        {
            var model = await repository.AllReadonly<Post>()
                .Where(x=>x.UserId==userId)
                .OrderByDescending(x=>x.CreatedDate)
                .Select(x => new PostInfoModel(
                    x.Id,
                    x.Content,
                    x.UserId,
                    "",
                    x.CreatedDate,
                    Convert.ToBase64String(x.Image),
                    x.Status,
                    "",
                    0,
                    "",
                    ""))
                .ToListAsync();

            foreach (var item in model)
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                CommentInfoModel? lastComment = await commentService.GetLastCommentForPostAsync(item.Id);

                if (user != null)
                {
                    item.UserProfileImage = Convert.ToBase64String(user.ProfileImage);
                    item.Username = user.UserName;
                }

                if (lastComment != null)
                {
                    item.LastCommentUsername = lastComment.Username;
                    item.LastCommentContent = lastComment.Content;
                }

                item.LikesCount = await likeService.GetLikesCountForPostAsync(item.Id);
            }

            return model;
        }

        public async Task<IEnumerable<PostInfoModel>> GetAllPostsWhithoutUsersAsync(string userId)
        {
            var model =  await repository.AllReadonly<Post>()
                .Where(x => x.UserId != userId)
                .OrderByDescending(x => x.CreatedDate)
                .Select(x => new PostInfoModel(
                    x.Id,
                    x.Content,
                    x.UserId,
                    "",
                    x.CreatedDate,
                    Convert.ToBase64String(x.Image),
                    x.Status,
                    "",
                    0,
                    "",
                    ""))                
                .ToListAsync();

            foreach (var item in model) 
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                CommentInfoModel? lastComment = await commentService.GetLastCommentForPostAsync(item.Id);

                if (user != null)
                {
                    item.UserProfileImage = Convert.ToBase64String(user.ProfileImage);
                    item.Username = user.UserName;
                }

                if (lastComment != null) 
                {
                    item.LastCommentUsername = lastComment.Username;
                    item.LastCommentContent = lastComment.Content;
                }

                item.LikesCount = await likeService.GetLikesCountForPostAsync(item.Id);
            }

            return model;
        }

        public async Task<PostInfoModel?> GetPostByIdAsync(int id)
        {
            var post = await repository.GetByIdAsync<Post>(id);

            if (post == null)
                return null;

            var user = await userManager.FindByIdAsync(post.UserId);
            CommentInfoModel? lastComment = await commentService.GetLastCommentForPostAsync(id);
            int likesCount = await likeService.GetLikesCountForPostAsync(id);

            return new PostInfoModel(
                post.Id,
                post.Content,
                post.UserId,
                user.UserName,
                post.CreatedDate,
                Convert.ToBase64String(post.Image),
                post.Status,
                Convert.ToBase64String(user.ProfileImage),
                likesCount,
                lastComment?.Username ?? "",
                lastComment?.Content ?? "");
        }

        public async Task<PostPageModel> GetPostsForPageAsync(string userId, bool? isProfilePage = null, int currentPage = 1)
        {
            var model = new PostPageModel();

            int formula = (currentPage - 1) * ValidationConstants.MaxPostsPerPage;

            if (currentPage <= 1)
            {
                formula = 0;
            }

            if (isProfilePage == true)
            {
                model.Posts = await GetAllUserPostsAsync(userId);
            }
            else 
            {
                model.Posts = await GetAllPostsWhithoutUsersAsync(userId);
            }

            model.PagesCount = Math.Ceiling((model.Posts.Count() / Convert.ToDouble(ValidationConstants.MaxPostsPerPage)));

            model.Posts = model.Posts
               .Skip(formula)
               .Take(ValidationConstants.MaxPostsPerPage);

            model.CurrentPage = currentPage;

            return model;
        }

        public List<string> GetStatusesAsync<T>() where T : Enum
        {
            return new List<string>(Enum.GetNames(typeof(T)));
        }
    }
}
