﻿using Buntu.Core.Contracts;
using Buntu.Core.Services;
using Buntu.Infrastructure.Common;
using Buntu.Infrastructure.Data;
using Buntu.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IFavoritePostService, FavoritePostService>();
            services.AddScoped<IUserInformationService, UserInformationService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string was not found.");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddScoped<IRepository, Repository>();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();

            return services;
        }
    }
}
