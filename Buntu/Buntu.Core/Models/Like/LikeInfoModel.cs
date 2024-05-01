﻿using Buntu.Core.Enums;

namespace Buntu.Core.Models.Like
{
    /// <summary>
    /// Model for like information for post
    /// </summary>
    public class LikeInfoModel
    {
        public LikeInfoModel(
            int id,
            int postId,
            string userId,
            LikeVariant variant)
        {
            Id = id;
            PostId = postId;
            UserId = userId;
            Variant = variant;
        }

        /// <summary>
        /// Like identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Post identifier
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// User identifier
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// Like variant
        /// </summary>
        public LikeVariant Variant { get; set; } 
    }
}