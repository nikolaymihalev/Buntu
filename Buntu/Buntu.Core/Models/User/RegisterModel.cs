using Buntu.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace Buntu.Core.Models.User
{
    public class RegisterModel
    {
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.NameMaxLength,
            MinimumLength = ValidationConstants.NameMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [EmailAddress]
        [StringLength(ValidationConstants.EmailMaxLength,
            MinimumLength = ValidationConstants.EmailMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [StringLength(ValidationConstants.PasswordMaxLength,
            MinimumLength = ValidationConstants.PasswordMinLength,
            ErrorMessage = ErrorMessageConstants.StringLengthErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
