using Buntu.Core.Contracts;
using Buntu.Core.Models.Comment;
using Buntu.Core.Models.FavoritePost;
using Buntu.Core.Models.Post;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class FavoritePostService : IFavoritePostService
    {
        private readonly IRepository repository;
        private readonly ILikeService likeService;
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public FavoritePostService(
            IRepository _repository,
            ILikeService _likeService,
            UserManager<ApplicationUser> _userManager,
            ICommentService _commentService)
        {
            repository = _repository;
            likeService = _likeService;
            userManager = _userManager;
            commentService = _commentService;
        }

        public async Task AddFavoriteAsync(FavoritePostModel model)
        {
            var entity = new FavoritePost()
            {
                PostId = model.PostId,
                UserId = model.UserId,
            };

            try
            {
                await repository.AddAsync<FavoritePost>(entity);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task<bool> IsFavoritePostExistsAsync(int postId, string userId)
        {
            var entity = await repository.AllReadonly<FavoritePost>()
                .FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);

            if (entity != null) 
            {
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<FavoritePostModel>> GetUserFavoritePostsAsync(string userId)
        {
            var list = await repository.AllReadonly<FavoritePost>()
                .Where(x => x.UserId == userId)
                .Select(x => new FavoritePostModel()
                {
                    Id = x.Id,
                    PostId = x.PostId,
                    UserId = x.UserId,
                    Post = new PostInfoModel(
                        x.PostId,
                        x.Post.Content,
                        x.Post.UserId,
                        "",
                        x.Post.CreatedDate,
                        Convert.ToBase64String(x.Post.Image),
                        x.Post.Status,
                        "",
                        0,
                        "",
                        "")
                }).ToListAsync();

            foreach (var item in list) 
            {
                var user = await userManager.FindByIdAsync(item.UserId);
                CommentInfoModel? lastComment = await commentService.GetLastCommentForPostAsync(item.Id);

                if (user != null)
                {
                    item.Post.UserProfileImage = Convert.ToBase64String(user.ProfileImage);
                    item.Post.Username = user.UserName;
                }

                if (lastComment != null)
                {
                    item.Post.LastCommentUsername = lastComment.Username;
                    item.Post.LastCommentContent = lastComment.Content;
                }


                item.Post.LikesCount = await likeService.GetLikesCountForPostAsync(item.PostId);
            }

            return list;
        }

        public async Task RemoveFavoriteAsync(int id)
        {
            var entity = await repository.GetByIdAsync<FavoritePost>(id);

            if (entity != null) 
            {
                await repository.DeleteAsync<FavoritePost>(id);
                await repository.SaveChangesAsync();
            }
        }

        public async Task<FavoritePostModel?> GetFavoritePostAsync(int postId, string userId)
        {
            var entity = await repository.AllReadonly<FavoritePost>()
                .FirstOrDefaultAsync(x => x.PostId == postId && x.UserId == userId);

            if (entity != null) 
            {
                return new FavoritePostModel()
                {
                    Id = entity.Id,
                    UserId = userId,
                    PostId = postId,
                };
            }

            return null;
        }
    }
}
