using Buntu.Core.Contracts;
using Buntu.Core.Enums;
using Buntu.Core.Models.Post;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IRepository repository;

        public PostService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddPostAsync(PostFormModel model)
        {
            var post = new Post()
            {
                Content = model.Content,
                UserId = model.UserId,
                CreatedDate = DateTime.Now,
                Image = model.Image,
                Status = model.Status.ToString()
            };

            try
            {
                await repository.AddAsync<Post>(post);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await repository.GetByIdAsync<Post>(id);

            if (post == null) 
            {
                throw new ArgumentException(ErrorMessageConstants.InvalidModelErrorMessage);
            }

            await repository.DeleteAsync<Post>(post);
        }

        public async Task EditPostAsync(PostFormModel model)
        {
            var post = await repository.GetByIdAsync<Post>(model.Id);

            if (post == null)
            {
                throw new ArgumentException(ErrorMessageConstants.InvalidModelErrorMessage);
            }

            post.Content = model.Content;
            post.Image = model.Image;
            post.Status = model.Status.ToString();

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<PostInfoModel>> GetAllPostsAsync()
        {
            return await repository.AllReadonly<Post>()
                .Select(x => new PostInfoModel(
                    x.Id,
                    x.Content,
                    x.UserId,
                    x.CreatedDate,
                    Convert.ToBase64String(x.Image),
                    (PostStatus)Enum.Parse(typeof(PostStatus), x.Status)))
                .ToListAsync();
        }

        public async Task<PostInfoModel?> GetPostByIdAsync(int id)
        {
            var post = await repository.GetByIdAsync<Post>(id);

            if (post == null)
                return null;

            return new PostInfoModel(
                post.Id,
                post.Content,
                post.UserId,
                post.CreatedDate,
                Convert.ToBase64String(post.Image),
                (PostStatus)Enum.Parse(typeof(PostStatus), post.Status));
        }

        public async Task<PostPageModel> GetPostsForPageAsync(int currentPage = 1)
        {
            var model = new PostPageModel();

            int formula = (currentPage - 1) * ValidationConstants.MaxPostsPerPage;

            if (currentPage <= 1)
            {
                formula = 0;
            }

            model.Posts = await GetAllPostsAsync();

            model.PagesCount = Math.Ceiling((model.Posts.Count() / Convert.ToDouble(ValidationConstants.MaxPostsPerPage)));

            model.Posts = model.Posts
               .Skip(formula)
               .Take(ValidationConstants.MaxPostsPerPage);

            model.CurrentPage = currentPage;

            return model;
        }
    }
}
