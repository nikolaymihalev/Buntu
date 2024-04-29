using Buntu.Infrastructure.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buntu.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Comment("User first name")]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Comment("User last name")]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string LastName { get; set; } = string.Empty;

        [Comment("User full name")]
        public string FullName => $"{FirstName + LastName}";

        [Required]
        [Comment("User profile image")]
        public byte[] ProfileImage { get; set; } = new byte[128];

        public ICollection<Follow> Follows { get; set; } = new List<Follow>();

        public ICollection<Follow> Followers { get; set; } = new List<Follow>();
    }
}
