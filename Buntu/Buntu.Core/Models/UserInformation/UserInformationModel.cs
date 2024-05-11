using System.ComponentModel.DataAnnotations;

namespace Buntu.Core.Models.UserInformation
{
    /// <summary>
    /// General information about user
    /// </summary>
    public class UserInformationModel
    {
        /// <summary>
        /// Information identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        [Required]        
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// User gender
        /// </summary>
        public string Gender { get; set; } = string.Empty;

        /// <summary>
        /// User date of birth
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// User work
        /// </summary>
        public string Work { get; set; } = string.Empty;

        /// <summary>
        /// User university degree
        /// </summary>
        public string University { get; set; } = string.Empty;

        /// <summary>
        /// User school degree
        /// </summary>
        public string School { get; set; } = string.Empty;

        /// <summary>
        /// User residence
        /// </summary>
        public string Residence { get; set; } = string.Empty;

        /// <summary>
        /// User relationships
        /// </summary>
        public string Relationships { get; set; } = string.Empty;
    }
}
