﻿using Buntu.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Buntu.Infrastructure.Data
{
    internal class SeedData
    {
        public ApplicationUser Ivan { get; private set; } = null!;
        public ApplicationUser Petur { get; private set; } = null!;
        public Post Holiday { get; private set; } = null!;
        public Post Car { get; private set; } = null!;
        public Comment NiceCar { get; private set; } = null!;
        public Comment Nature { get; private set; } = null!;
        public Like Heart { get; private set; } = null!;
        public Like Thumb { get; private set; } = null!;

        public SeedData()
        {
            SeedUsers();
            SeedPosts();
            SeedComments();
            SeedLikes();
        }

        private void SeedUsers() 
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            Ivan = new ApplicationUser()
            {
                Id = "c85a8e02-947d-408e-a604-1940eff71717",
                UserName = "Ivan123",
                NormalizedUserName = "IVAN123",
                Email = "ivanivanov@gmail.com",
                NormalizedEmail = "IVANIVANOV@GMAIL.COM",
                FirstName = "Ivan",
                LastName = "Ivanov",
                ProfileImage = File.ReadAllBytes(Path.Combine(@"Images", "DefaultPicture.png")),
            };

            Petur = new ApplicationUser()
            {
                Id = "6ee02d48-f214-4711-9f6a-a4fd0c143196",
                UserName = "Petur123",
                NormalizedUserName = "PETUR123",
                Email = "peturpetrov@gmail.com",
                NormalizedEmail = "PETURPETROV@GMAIL.COM",
                FirstName = "Petur",
                LastName = "Petrov",
                ProfileImage = File.ReadAllBytes(Path.Combine(@"Images", "DefaultPicture.png")),
            };

            Ivan.PasswordHash = hasher.HashPassword(Ivan, "1234Ivan");
            Petur.PasswordHash = hasher.HashPassword(Petur, "1234Petur");
        }

        private void SeedPosts() 
        {
            Holiday = new Post()
            {
                Id = 1,
                Content = "I'm in the Caribbean islands. It is very beautiful!",
                UserId = Ivan.Id,
                CreatedDate = Convert.ToDateTime("29/04/2024"),
                Image = File.ReadAllBytes(Path.Combine(@"Images", "Caribbean.jpg")),
                Status = "Happy"
            };

            Car = new Post()
            {
                Id = 2,
                Content = "Check out my new lamborghini. It is the new model!",
                UserId = Petur.Id,
                CreatedDate = Convert.ToDateTime("27/04/2024"),
                Image = File.ReadAllBytes(Path.Combine(@"Images", "Lamborghini.jpg")),
                Status = "Happy"
            };
        }

        private void SeedComments() 
        {
            NiceCar = new Comment()
            {
                Id = 1,
                Content = "Cool car! I want one too!",
                PostId = 2,
                UserId = Ivan.Id,
                CreatedDate = Convert.ToDateTime("28/04/2024"),
            };

            Nature = new Comment()
            {
                Id = 2,
                Content = "What a beautiful nature!",
                PostId = 1,
                UserId = Petur.Id,
                CreatedDate = Convert.ToDateTime("30/04/2024"),
            };
        }

        private void SeedLikes() 
        {
            Heart = new Like()
            {
                Id = 1,
                PostId = 1,
                UserId = Petur.Id,
                Variant = "Heart"
            };

            Thumb = new Like()
            {
                Id = 2,
                PostId = 2,
                UserId = Ivan.Id,
                Variant = "Thumb"
            };
        }
    }
}