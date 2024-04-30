using Buntu.Core.Enums;

namespace Buntu.Core.Models.Post
{
    /// <summary>
    /// Model for post information
    /// </summary>
    public class PostInfoModel
    {
        public PostInfoModel(
            int id,
            string content,
            string userId,
            DateTime creationDate,
            string image,
            PostStatus status)
        {
            Id = id;
            Content = content;
            UserId = userId;
            CreatedDate = creationDate;
            Image = image;
            Status = status;
        }

        /// <summary>
        /// Post identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post content
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Date of creation of post 
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Post image 
        /// </summary>
        public string Image { get; set; } = string.Empty;

        /// <summary>
        /// Post status
        /// </summary>
        public PostStatus Status { get; set; } 
    }
}
