using Buntu.Core.Models.Comment;

namespace Buntu.Core.Contracts
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentInfoModel>> GetCommentsForPostAsync(int postId);
        Task AddCommentAsync(CommentFormModel model);
        Task EditCommentAsync(CommentFormModel model);
        Task DeleteCommentAsync(int id);
        Task<CommentInfoModel?> GetCommentByIdAsync(int id);
        Task<CommentInfoModel?> GetLastCommentForPostAsync(int postId);
    }
}