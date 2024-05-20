using Buntu.Core.Models.Notification;

namespace Buntu.Core.Contracts
{
    public interface INotificationService
    {
        Task AddNotificationAsync(NotificationModel model);
        Task DeleteNotificationAsync(int id);
        Task MarkNotificationAsReadAsync(int id);
        Task<IEnumerable<NotificationModel>> GetUserNotificationsAsync(string userId);
        Task<int> GetUnreadNotificationsCountAsync(string userId);
    }
}
