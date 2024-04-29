using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Buntu.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Comment("User first name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Comment("User last name")]
        public string LastName { get; set; } = string.Empty;

        [Comment("User full name")]
        public string FullName => $"{FirstName + LastName}";

        [Required]
        [Comment("User profile image")]
        public byte[] ProfileImage { get; set; } = new byte[128];

        public IEnumerable<Follow> Follows { get; set; } = new List<Follow>();
    }
}
