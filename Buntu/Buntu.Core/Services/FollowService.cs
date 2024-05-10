using Buntu.Core.Contracts;
using Buntu.Core.Models.Follow;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class FollowService : IFollowService
    {
        private readonly IRepository repository;

        public FollowService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddFollowerAsync(FollowModel model)
        {
            var entity = new Follow()
            {
                UserId = model.UserId,
                FollowerId = model.FollowerId
            };

            try
            {
                await repository.AddAsync<Follow>(entity);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task<IEnumerable<FollowModel>> GetUserFollowersAsync(string userId)
        {
            return await repository.AllReadonly<Follow>()
                .Where(x=>x.UserId == userId)
                .Select(x=> new FollowModel() 
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FollowerId = x.FollowerId
                })
                .ToListAsync();
        }

        public async Task RemoveFollowerAsync(int id)
        {
            var follow = await repository.GetByIdAsync<Follow>(id);

            if (follow is null) 
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            await repository.DeleteAsync<Follow>(id);

            await repository.SaveChangesAsync();
        }

        public async Task<int> GetUserFollowersCountAsync(string userId) 
        {
            return await repository.AllReadonly<Follow>()
                .Where(x => x.UserId == userId)
                .CountAsync();
        }

        public async Task<bool> IsProfileFollowedByUserAsync(string userId, string followerId) 
        {
            var entity = await repository.AllReadonly<Follow>()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FollowerId == followerId);

            if (entity == null)
                return false;

            return true;
        }

        public async Task<FollowModel?> GetFollowAsync(string userId, string followerId) 
        {
            return await repository.AllReadonly<Follow>()
                .Select(x=> new FollowModel() 
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    FollowerId = x.FollowerId
                })
                .FirstOrDefaultAsync(x => x.UserId == userId && x.FollowerId == followerId);
        }
    }
}
