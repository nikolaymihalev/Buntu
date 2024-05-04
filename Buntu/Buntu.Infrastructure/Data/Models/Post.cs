using Buntu.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buntu.Infrastructure.Data.Models
{
    [Comment("Post")]
    public class Post
    {
        [Key]
        [Comment("Post identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Post content")]
        [MaxLength(ValidationConstants.ContentMaxLength)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Publisher identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Comment("Date of creation")]
        public DateTime CreatedDate { get; set; }

        [Comment("Post image")]
        public byte[] Image { get; set; } = new byte[128];

        [Required]
        [Comment("Post status")]
        public string Status { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
        public IEnumerable<Like> Likes { get; set; } = new List<Like>();
        public IEnumerable<FavoritePost> FavoritePosts { get; set; } = new List<FavoritePost>();
    }
}
