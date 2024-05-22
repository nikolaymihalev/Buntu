using Buntu.Core.Models.User;

namespace Buntu.Core.Contracts
{
    public interface IUserInformationService
    {
        Task AddUserInformationAsync(UserInformationModel model);
        Task<UserInformationModel?> GetUserInformationAsync(string userId);
    }
}
