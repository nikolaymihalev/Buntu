using Buntu.Core.Contracts;
using Buntu.Core.Models.User;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class UserInformationService : IUserInformationService
    {
        private readonly IRepository repository;

        public UserInformationService(IRepository _repository)
        {
            repository = _repository;            
        }

        public async Task AddUserInformationAsync(UserInformationModel model)
        {
            var entity = new UserInformation()
            {
                UserId = model.UserId,
            };

            try
            {
                await repository.AddAsync<UserInformation>(entity);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task<UserInformationModel?> GetUserInformationAsync(string userId)
        {
            return await repository.AllReadonly<UserInformation>()
                .Where(x => x.UserId == userId)
                .Select(x => new UserInformationModel()
                {
                    Id = x.Id,
                    UserId = userId,
                    Gender = x.Gender,
                    BirthDate = x.BirthDate,
                    Work = x.Work,
                    University = x.University,
                    School = x.School,
                    Residence = x.Residence,
                    Relationships = x.Relationships
                })
                .FirstOrDefaultAsync();
        }
    }
}