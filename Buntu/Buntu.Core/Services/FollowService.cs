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

        public async Task AddFollowerAsync(FollowInfoModel model)
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

        public async Task<IEnumerable<FollowInfoModel>> GetUserFollowersAsync(string userId)
        {
            return await repository.AllReadonly<Follow>()
                .Where(x=>x.UserId == userId)
                .Select(x=> new FollowInfoModel() 
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
    }
}
