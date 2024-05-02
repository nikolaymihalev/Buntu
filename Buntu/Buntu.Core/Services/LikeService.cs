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
                Variant = model.Variants[model.Variant].ToString()
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

            like.Variant = model.Variants[model.Variant].ToString();

            await repository.SaveChangesAsync();
        }

        public async Task<LikeInfoModel?> GetLikeByIdAsync(int id)
        {
            var like = await repository.GetByIdAsync<Like>(id);

            if (like is null) 
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            return new LikeInfoModel(
                like.Id,
                like.PostId,
                like.UserId,
                like.Variant);
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

        public async Task RemoveLikeAsync(int id)
        {
            var like = await repository.GetByIdAsync<Like>(id);

            if(like == null) 
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            await repository.DeleteAsync<Like>(id);

            await repository.SaveChangesAsync();
        }
    }
}
