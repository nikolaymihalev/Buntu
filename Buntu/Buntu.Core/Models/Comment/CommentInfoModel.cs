namespace Buntu.Core.Models.Comment
{
    /// <summary>
    /// Model for comment info
    /// </summary>
    public class CommentInfoModel
    {
        public CommentInfoModel(
            int id,
            string content,
            int postId,
            string userId,
            string username,
            DateTime creationDate)
        {
            Id = id;
            Content = content;
            PostId = postId;
            UserId = userId;
            Username = username;
            CreatedDate = creationDate;
        }

        /// <summary>
        /// Comment identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Comment content
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Post identifier
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// User username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
