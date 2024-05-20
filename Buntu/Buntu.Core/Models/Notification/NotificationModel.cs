namespace Buntu.Core.Models.Notification
{
    /// <summary>
    /// Model for notification
    /// </summary>
    public class NotificationModel
    {
        /// <summary>
        /// Notification identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Other user identifier
        /// </summary>
        public string OtherUserId { get; set; } = string.Empty;

        /// <summary>
        /// Tyte of notification
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Object identifier related with notification 
        /// </summary>
        public int RelatedId { get; set; }

        /// <summary>
        /// Is notification read from user
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// Notification creation date
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
