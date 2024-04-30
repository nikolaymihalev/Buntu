using Buntu.Core.Contracts;
using Buntu.Core.Models.Post;

namespace Buntu.Core.Services
{
    public class PostService : IPostService
    {
        public Task AddPostAsync(PostFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PostInfoModel>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PostInfoModel?> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PostPageModel> GetPostsForPageAsync(int currentPage = 1)
        {
            throw new NotImplementedException();
        }
    }
}
