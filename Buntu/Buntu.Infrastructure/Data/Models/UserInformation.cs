using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buntu.Infrastructure.Data.Models
{
    [Comment("General information about user")]
    public class UserInformation
    {
        [Key]
        [Comment("Information identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public string UserId { get; set; } = string.Empty;

        [Comment("User gender")]
        public string Gender { get; set; } = string.Empty;

        [Comment("User date of birth")]
        public DateTime BirthDate { get; set; }

        [Comment("User work")]
        public string Work { get; set; } = string.Empty;

        [Comment("User university degree")]
        public string University { get; set; } = string.Empty;

        [Comment("User school degree")]
        public string School { get; set; } = string.Empty;

        [Comment("User residence")]
        public string Residence { get; set; } = string.Empty;

        [Comment("User relationships")]
        public string Relationships { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; } = null!;
    }
}
