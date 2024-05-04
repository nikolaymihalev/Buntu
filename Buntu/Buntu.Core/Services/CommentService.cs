using Buntu.Core.Contracts;
using Buntu.Core.Models.Comment;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository repository;

        public CommentService(
            IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddCommentAsync(CommentFormModel model)
        {
            var comment = new Comment()
            {
                Content = model.Content,
                PostId = model.PostId,
                UserId = model.UserId,
                CreatedDate = DateTime.Now,
            };

            try
            {
                await repository.AddAsync<Comment>(comment);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await repository.GetByIdAsync<Comment>(id);

            if (comment is null) 
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            await repository.DeleteAsync<Comment>(id);
        }

        public async Task EditCommentAsync(CommentFormModel model)
        {
            var comment = await repository.GetByIdAsync<Comment>(model.Id);

            if (comment is null)
            {
                throw new ArgumentException(ErrorMessageConstants.InvalidModelErrorMessage);
            }

            comment.Content = model.Content;

            await repository.SaveChangesAsync();
        }

        public async Task<CommentInfoModel?> GetCommentByIdAsync(int id)
        {
            var comment = await repository.GetByIdAsync<Comment>(id);

            if (comment is null)
                return null;

            return new CommentInfoModel(
                comment.Id,
                comment.Content,
                comment.PostId,
                comment.UserId,
                "",
                comment.CreatedDate);
        }

        public async Task<IEnumerable<CommentInfoModel>> GetCommentsForPostAsync(int postId)
        {
            return await repository.AllReadonly<Comment>()
                .Where(x=>x.PostId==postId)
                .Select(x => new CommentInfoModel(
                    x.Id,
                    x.Content,
                    x.PostId,
                    x.UserId,
                    x.User.UserName,
                    x.CreatedDate))
                .ToListAsync();
        }

        public async Task<CommentInfoModel?> GetLastCommentForPostAsync(int postId)
        {
            var comments = await GetCommentsForPostAsync(postId);

            return comments.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
        }
    }
}
