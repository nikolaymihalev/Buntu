using Buntu.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace Buntu.Core.Models.User
{
    /// <summary>
    /// User profile model for register
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// User first name
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// User last name
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        /// <summary>
        /// User username
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string Username { get; set; } = null!;

        /// <summary>
        /// User email
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [EmailAddress]
        [StringLength(ValidationConstants.EmailMaxLength,
            MinimumLength = ValidationConstants.EmailMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string Email { get; set; } = null!;

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.PasswordMaxLength,
            MinimumLength = ValidationConstants.PasswordMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
