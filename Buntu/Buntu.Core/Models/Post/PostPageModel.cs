namespace Buntu.Core.Models.Post
{
    /// <summary>
    /// Post model for page
    /// </summary>
    public class PostPageModel
    {
        /// <summary>
        /// Collection of posts
        /// </summary>
        public IEnumerable<PostInfoModel> Posts { get; set; } = new List<PostInfoModel>();

        /// <summary>
        /// Pages count
        /// </summary>
        public double PagesCount { get; set; }

        /// <summary>
        /// Current page
        /// </summary>
        public int CurrentPage { get; set; }
    }
}
