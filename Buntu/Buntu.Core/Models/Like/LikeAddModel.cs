using Buntu.Core.Enums;

namespace Buntu.Core.Models.Like
{
    /// <summary>
    /// Model for add or editing like for post
    /// </summary>
    public class LikeAddModel
    {
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
        /// Like variant number
        /// </summary>
        public int Variant { get; set; }

        /// <summary>
        /// Collection of like variants
        /// </summary>
        public IList<LikeVariant> Variants { get; set; } = new List<LikeVariant>();
    }
}
