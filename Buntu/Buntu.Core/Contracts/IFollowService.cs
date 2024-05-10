using Buntu.Core.Models.Follow;

namespace Buntu.Core.Contracts
{
    public interface IFollowService
    {
        Task AddFollowerAsync(FollowModel model);
        Task RemoveFollowerAsync(int id);
        Task<IEnumerable<FollowModel>> GetUserFollowersAsync(string userId);
        Task<int> GetUserFollowersCountAsync(string userId);
        Task<bool> IsProfileFollowedByUserAsync(string userId, string followerId);
        Task<FollowModel?> GetFollowAsync(string userId, string followerId);
    }
}