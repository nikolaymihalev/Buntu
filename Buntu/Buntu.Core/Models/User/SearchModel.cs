using Buntu.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace Buntu.Core.Models.User
{
    /// <summary>
    /// Model for searching user
    /// </summary>
    public class SearchModel
    {
        /// <summary>
        /// User username
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.NameMaxLength, 
            MinimumLength = ValidationConstants.NameMinLength, 
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string Username { get; set; } = string.Empty;
    }
}
