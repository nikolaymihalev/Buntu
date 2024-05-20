using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buntu.Infrastructure.Data.Models
{
    [Comment("Notification")]
    public class Notification
    {
        [Key]
        [Comment("Notification identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [Comment("Other user identifier")]
        public string OtherUserId { get; set; } = string.Empty;

        [Required]
        [Comment("Notification type")]
        public string Type { get; set; } = string.Empty;

        [Comment("Related type identifier (like, comment, follow)")]
        public int RelatedId { get; set; }

        [Comment("Is notification read")]
        public bool IsRead { get; set; }

        [Required]
        [Comment("Notification creation date")]
        public DateTime CreationDate { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
