using Buntu.Core.Models.FavoritePost;

namespace Buntu.Core.Contracts
{
    public interface IFavoritePostService
    {
        Task AddFavoriteAsync(FavoritePostModel model);
        Task RemoveFavoriteAsync(int id);
        Task<IEnumerable<FavoritePostModel>> GetUserFavoritePostsAsync(string userId);
        Task<bool> IsFavoritePostExistsAsync(int postId, string userId);
        Task<FavoritePostModel?> GetFavoritePostAsync(int postId, string userId);
    }
}
