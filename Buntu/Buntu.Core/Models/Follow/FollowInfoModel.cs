﻿namespace Buntu.Core.Models.Follow
{
    /// <summary>
    /// Model for follower information
    /// </summary>
    public class FollowInfoModel
    {
        /// <summary>
        /// Follow identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Follower identifier
        /// </summary>
        public string FollowerId { get; set; } = string.Empty;
    }
}
