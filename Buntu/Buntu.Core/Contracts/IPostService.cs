using Buntu.Core.Models.Post;

namespace Buntu.Core.Contracts
{
    public interface IPostService
    {
        Task<PostPageModel> GetPostsForPageAsync(int currentPage = 1);
        Task<IEnumerable<PostInfoModel>> GetAllPostsAsync();
        Task AddPostAsync(PostFormModel model);
        Task EditPostAsync(PostFormModel model);
        Task DeletePostAsync(int id);
        Task<PostInfoModel?> GetPostByIdAsync(int id);
    }
}
