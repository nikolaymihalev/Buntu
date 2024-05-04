using Buntu.Core.Models.Post;

namespace Buntu.Core.Models.FavoritePost
{
    /// <summary>
    /// Model for information about user favorite post
    /// </summary>
    public class FavoritePostModel
    {
        /// <summary>
        /// Favorite post identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post identifier
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Post model
        /// </summary>
        public PostInfoModel Post { get; set; }
    }
}
