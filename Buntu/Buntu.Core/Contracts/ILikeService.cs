using Buntu.Core.Models.Like;

namespace Buntu.Core.Contracts
{
    public interface ILikeService
    {
        Task AddLikeAsync(LikeAddModel model);
        Task EditLikeAsync(LikeAddModel model);
        Task RemoveLikeAsync(int id);
        Task<LikeInfoModel?> GetLikeByIdAsync(int id);
        Task<IEnumerable<LikeInfoModel>> GetLikesForPostAsync(int postId);
        Task<int> GetLikesCountForPostAsync(int postId);
    }
}
