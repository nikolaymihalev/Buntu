using Microsoft.AspNetCore.Http;
using Buntu.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;
using Buntu.Core.Enums;

namespace Buntu.Core.Models.Post
{
    /// <summary>
    /// Model for adding or editing post 
    /// </summary>
    public class PostFormModel
    {
        /// <summary>
        /// Post identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post content
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.ContentMaxLength, 
            MinimumLength = ValidationConstants.ContentMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string Content { get; set; } = string.Empty;
        
        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Post image 
        /// </summary>
        public byte[] Image { get; set; } = new byte[128];

        /// <summary>
        /// Image file
        /// </summary>
        public IFormFile? ImageFile { get; set; }

        /// <summary>
        /// Status number
        /// </summary>
        public int Status { get; set; } 

        /// <summary>
        /// Collection of post statuses
        /// </summary>
        public IEnumerable<PostStatus> Statuses { get; set; } = new List<PostStatus>();
    }
}
