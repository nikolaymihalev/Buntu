using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buntu.Infrastructure.Data.Models
{
    [Comment("Notification")]
    public class Notification
    {
        [Comment("Notification identifier")]
        public int Id { get; set; }

        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("Notification type")]
        public string Type { get; set; } = string.Empty;

        [Comment("Related type identifier (like, comment, follow)")]
        public object RelatedId { get; set; } = null!;

        [Comment("Is notification read")]
        public bool IsRead { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
