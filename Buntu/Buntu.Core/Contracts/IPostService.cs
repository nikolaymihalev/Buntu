using Buntu.Core.Models.Post;

namespace Buntu.Core.Contracts
{
    public interface IPostService
    {
        Task<PostPageModel> GetPostsForPageAsync(string? userId = null, int currentPage = 1);
        Task<IEnumerable<PostInfoModel>> GetAllUserPostsAsync(string userId);
        Task<IEnumerable<PostInfoModel>> GetAllPostsWhithoutUsersAsync(string userId);
        Task AddPostAsync(PostFormModel model);
        Task EditPostAsync(PostFormModel model);
        Task DeletePostAsync(int id);
        Task<PostInfoModel?> GetPostByIdAsync(int id);
    }
}
