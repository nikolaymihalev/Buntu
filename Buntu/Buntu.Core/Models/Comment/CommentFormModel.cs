using Buntu.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace Buntu.Core.Models.Comment
{
    /// <summary>
    /// Model for adding or editing comment
    /// </summary>
    public class CommentFormModel
    {
        /// <summary>
        /// Comment identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Comment content
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.ContentMaxLength, 
            MinimumLength = ValidationConstants.ContentMinLength, 
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Post identifier
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
