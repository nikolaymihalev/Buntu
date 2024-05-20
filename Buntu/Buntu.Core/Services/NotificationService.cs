using Buntu.Core.Contracts;
using Buntu.Core.Models.Notification;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Constants;
using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Buntu.Core.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IRepository repository;

        public NotificationService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddNotificationAsync(NotificationModel model)
        {
            var entity = new Notification()
            {
                UserId = model.UserId,
                OtherUserId = model.OtherUserId,
                Type = model.Type,
                RelatedId = model.RelatedId,
                IsRead = false,
                CreationDate = DateTime.Now,
            };

            try
            {
                await repository.AddAsync<Notification>(entity);
                await repository.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new ArgumentException(ErrorMessageConstants.OperationFailedErrorMessage);
            }
        }

        public async Task DeleteNotificationAsync(int id)
        {
            var notification = await repository.GetByIdAsync<Notification>(id);

            if (notification == null)
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            await repository.DeleteAsync<Notification>(id);

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<NotificationModel>> GetUserNotificationsAsync(string userId)
        {
            return await repository.AllReadonly<Notification>()
                .Where(x => x.UserId == userId)
                .Select(x => new NotificationModel()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    OtherUserId = x.OtherUserId,
                    Type = x.Type,
                    RelatedId = x.RelatedId,
                    IsRead = x.IsRead,
                    CreationDate = x.CreationDate
                })
                .OrderByDescending(x=>x.CreationDate)
                .ThenBy(x=>x.IsRead)
                .ToListAsync();
        }

        public async Task MarkNotificationAsReadAsync(int id)
        {
            var notification = await repository.GetByIdAsync<Notification>(id);

            if (notification == null) 
            {
                throw new ArgumentException(ErrorMessageConstants.DoesntExistErrorMessage);
            }

            notification.IsRead = true;

            await repository.SaveChangesAsync();
        }

        public async Task<int> GetUnreadNotificationsCountAsync(string userId) 
        {
            return await repository.AllReadonly<Notification>()
                .Where(x => x.UserId == userId && x.IsRead == false)
                .CountAsync();
        }
    }
}
