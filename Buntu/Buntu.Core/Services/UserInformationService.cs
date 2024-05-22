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

        public async Task<IEnumerable<ApplicationUser>> GetSearchedUserResultAsync(string username) 
        {
            var list = await repository.AllReadonly<ApplicationUser>()
                .Where(x => x.UserName.Contains(username))
                .ToListAsync();

            var list2 = await repository.AllReadonly<ApplicationUser>()
                .Where(x => x.FirstName.Contains(username) || x.LastName.Contains(username))
                .ToListAsync();

            foreach (var item in list2) 
            {
                if(list.Any(x=>x.FirstName==item.FirstName || x.LastName == item.LastName) == false)
                    list.Add(item);
            }

            return list; 
        }
    }
}