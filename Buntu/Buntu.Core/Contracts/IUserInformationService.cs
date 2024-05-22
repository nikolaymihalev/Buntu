using Buntu.Core.Models.User;
using Buntu.Infrastructure.Data.Models;

namespace Buntu.Core.Contracts
{
    public interface IUserInformationService
    {
        Task AddUserInformationAsync(UserInformationModel model);
        Task<UserInformationModel?> GetUserInformationAsync(string userId);
        Task<IEnumerable<ApplicationUser>> GetSearchedUserResultAsync(string username);
    }
}
