using Buntu.Infrastructure.Constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buntu.Infrastructure.Data.Models
{
    [Comment("Comment")]
    public class Comment
    {
        [Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Comment content")]
        [MaxLength(ValidationConstants.ContentMaxLength)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Comment("Post identifier")]
        public int PostId { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Comment("Publication date")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
