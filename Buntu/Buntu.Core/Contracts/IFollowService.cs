using Buntu.Core.Models.Follow;

namespace Buntu.Core.Contracts
{
    public interface IFollowService
    {
        Task AddFollowerAsync(FollowInfoModel model);
        Task RemoveFollowerAsync(int id);
        Task<IEnumerable<FollowInfoModel>> GetUserFollowersAsync(string userId);
    }
}