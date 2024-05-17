using Buntu.Core.Models.Post;

namespace Buntu.Core.Models.Like
{
    /// <summary>
    /// Model for like information for post
    /// </summary>
    public class LikeInfoModel
    {
        public LikeInfoModel(
            int id,
            int postId,
            string userId,
            string variant)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            Variant = variant;
        }

        /// <summary>
        /// Like identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post identifier
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Like variant
        /// </summary>
        public string Variant { get; set; }

        /// <summary>
        /// Model for post information
        /// </summary>
        public PostInfoModel Post { get; set; }
    }
}
