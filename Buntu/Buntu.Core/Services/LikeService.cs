using Buntu.Core.Contracts;
using Buntu.Core.Enums;
using Buntu.Core.Models.Comment;
using Buntu.Core.Models.Like;
using Buntu.Core.Models.Post;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICommentService commentService;

        public LikeService(
            IRepository _repository, 
            UserManager<ApplicationUser> _userManager,
            ICommentService _commentService)
        {
            repository = _repository;
            userManager = _userManager;
            commentService = _commentService;
        }

        public async Task AddLikeAsync(LikeAddModel model)
        {
            var entity = new Like()
            {
                PostId = model.PostId,
                UserId = model.UserId,
                Variant = ((LikeVariant)model.Variant).ToString()
            };

            try
            {
                await repository.AddAsync<Like>(entity);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task EditLikeAsync(LikeAddModel model)
        {
            var like = await repository.GetByIdAsync<Like>(model.Id);

            if (like is null) 
            {
                throw new ArgumentException(ErrorMessageConstants.InvalidModelErrorMessage);
            }

            like.Variant = ((LikeVariant)model.Variant).ToString();

            await repository.SaveChangesAsync();
        }

        public async Task<LikeInfoModel?> GetLikeByPostAndUserIdAsync(int postId, string userId)
        {
            var like = await repository.AllReadonly<Like>()
                .FirstOrDefaultAsync<Like>(x => x.PostId == postId && x.UserId == userId);

            if (like != null) 
            {
                return new LikeInfoModel(
                like.Id,
                like.PostId,
                like.UserId,
                like.Variant);
            }

            return null;
        }

        public async Task<IEnumerable<LikeInfoModel>> GetLikesForPostAsync(int postId)
        {
            return await repository.AllReadonly<Like>()
                .Where(x => x.PostId == postId)
                .Select(x => new LikeInfoModel(
                    x.Id,
                    x.PostId,
                    x.UserId,
                    x.Variant))
                .ToListAsync();
        }

        public async Task<IEnumerable<LikeInfoModel>> GetLikesPerVariantForPostAsync(int postId, string variant)
        {
            return await repository.AllReadonly<Like>()
                .Where(x => x.PostId == postId && x.Variant == variant)
                .Select(x => new LikeInfoModel(
                    x.Id,
                    x.PostId,
                    x.UserId,
                    x.Variant))
                .ToListAsync();
        }

        public async Task<int> GetLikesCountForPostAsync(int postId)
        {
            return await repository.AllReadonly<Like>()
                .Where(x => x.PostId == postId)
                .Select(x => new LikeInfoModel(
                    x.Id,
                    x.PostId,
                    x.UserId,
                    x.Variant))
                .CountAsync();
        }

        public async Task RemoveLikeAsync(int postId, string userId)
        {
            var like = await repository.AllReadonly<Like>()
                .FirstOrDefaultAsync(x=>x.PostId==postId && x.UserId == userId);

            if(like == null) 
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            await repository.DeleteAsync<Like>(like.Id);

            await repository.SaveChangesAsync();
        }

        public async Task<bool> IsPostLikedByUserAsync(int postId, string userId)
        {
            var entity = await repository.AllReadonly<Like>()
                .FirstOrDefaultAsync<Like>(x => x.PostId == postId && x.UserId == userId);

            if (entity is null)
                return false;

            return true;
        }

        public async Task<string> GetLikeVariantAsync(int postId, string userId)
        {
            var entity = await repository.AllReadonly<Like>()
                .FirstOrDefaultAsync<Like>(x => x.PostId == postId && x.UserId == userId);

            if (entity != null)
                return entity.Variant;

            return string.Empty;
        }

        public async Task<int> GetLikesVariantCountAsync(int postId, string variant) 
        {
            return await repository.AllReadonly<Like>()
                .Where(x => x.PostId == postId && x.Variant == variant)
                .CountAsync();
        }

        public async Task<IEnumerable<LikeInfoModel>> GetUserLikedPostsAsync(string userId) 
        {
            var list = await repository.AllReadonly<Like>()
                .Where(x => x.UserId == userId)
                .Select(x => new LikeInfoModel(
                    x.Id, 
                    x.PostId, 
                    x.UserId, 
                    x.Variant)
                {
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
                var user = await userManager.FindByIdAsync(item.Post.UserId);
                CommentInfoModel? lastComment = await commentService.GetLastCommentForPostAsync(item.PostId);

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


                item.Post.LikesCount = await GetLikesCountForPostAsync(item.PostId);
            }

            return list;
        }

        public async Task<LikeInfoModel?> GetLikeByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync<Like>(id);

            if(entity != null)
                return new LikeInfoModel(entity.Id,entity.PostId,entity.UserId,entity.Variant);

            return null;
        }
    }
}
