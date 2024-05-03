using Buntu.Core.Models.Like;

namespace Buntu.Core.Contracts
{
    public interface ILikeService
    {
        Task AddLikeAsync(LikeAddModel model);
        Task EditLikeAsync(LikeAddModel model);
        Task RemoveLikeAsync(int postId, string userId);
        Task<LikeInfoModel?> GetLikeByIdAsync(int postId, string userId);
        Task<IEnumerable<LikeInfoModel>> GetLikesForPostAsync(int postId);
        Task<int> GetLikesCountForPostAsync(int postId);
        Task<bool> IsPostLikedByUserAsync(int postId, string userId);
        Task<string> GetLikeVariantAsync(int postId, string userId);
    }
}
