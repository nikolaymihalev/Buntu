using Buntu.Core.Contracts;
using Buntu.Core.Enums;
using Buntu.Core.Models.Like;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository repository;

        public LikeService(IRepository _repository)
        {
            repository = _repository;
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

        public async Task<LikeInfoModel?> GetLikeByIdAsync(int postId, string userId)
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
    }
}
