using Buntu.Infrastructure.Constants;
using System.ComponentModel.DataAnnotations;

namespace Buntu.Core.Models.User
{
    public class LoginModel
    {
        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessageConstants.RequireErrorMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
