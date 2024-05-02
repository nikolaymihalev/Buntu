using Buntu.Core.Enums;
using Buntu.Core.Models.Comment;

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
            string username,
            DateTime creationDate,
            string image,
            string status,
            string userProfileImage,
            int likesCount,
            string lastCommentUsername,
            string lastCommentContent)
        {
            Id = id;
            Content = content;
            UserId = userId;
            Username = username;
            CreatedDate = creationDate;
            Image = image;
            Status = status;
            UserProfileImage = userProfileImage;
            LikesCount = likesCount;
            LastCommentUsername = lastCommentUsername;
            LastCommentContent = lastCommentContent;
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
        /// User username
        /// </summary>
        public string Username { get; set; }

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
        public string Status { get; set; }

        /// <summary>
        /// User profile image
        /// </summary>
        public string UserProfileImage { get; set; }

        /// <summary>
        /// Post likes count
        /// </summary>
        public int LikesCount { get; set; }

        /// <summary>
        /// Post last comment user identifier
        /// </summary>
        public string? LastCommentUsername { get; set; }

        /// <summary>
        /// Post last comment content
        /// </summary>
        public string? LastCommentContent { get; set; }
    }
}
