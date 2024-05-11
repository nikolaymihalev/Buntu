using Buntu.Core.Models.UserInformation;

namespace Buntu.Core.Contracts
{
    public interface IUserInformationService
    {
        Task AddUserInformationAsync(UserInformationModel model);
        Task<UserInformationModel> GetUserInformationAsync(string userId);
    }
}
