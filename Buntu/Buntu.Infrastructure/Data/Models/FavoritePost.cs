using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buntu.Infrastructure.Data.Models
{
    [Comment("User favorite post")]
    public class FavoritePost
    {
        [Key]
        [Comment("Favorite post identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Comment("Post identifier")]
        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
