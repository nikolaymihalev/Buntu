using Buntu.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Buntu.Infrastructure.Data
{
    internal class SeedData
    {
        public SeedData()
        {
            SeedUsers();
            SeedPosts();
            SeedComments();
            SeedLikes();
            SeedFollows();
            SeedNotifications();
            SeedInformations();
        }

        public ApplicationUser Ivan { get; private set; } = null!;
        public ApplicationUser Petur { get; private set; } = null!;
        public Post Holiday { get; private set; } = null!;
        public Post Car { get; private set; } = null!;
        public Comment NiceCar { get; private set; } = null!;
        public Comment Nature { get; private set; } = null!;
        public Like Heart { get; private set; } = null!;
        public Like Thumb { get; private set; } = null!;
        public Follow Followee { get; private set; } = null!;
        public Follow Follower { get; private set; } = null!;
        public Notification Like { get; private set; } = null!;
        public Notification Comment { get; private set; } = null!;
        public UserInformation IvanInformation { get; private set; } = null!;
        public UserInformation PeturInformation { get; private set; } = null!;

        private void SeedUsers() 
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            Ivan = new ApplicationUser()
            {
                Id = "bbd4b588-917f-4634-8142-08f54ee760a1",
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
                Id = "68106d58-f54a-409c-92da-9184a75d55f7",
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
                UserId = "bbd4b588-917f-4634-8142-08f54ee760a1",
                CreatedDate = Convert.ToDateTime("29/04/2024"),
                Image = File.ReadAllBytes(Path.Combine(@"Images", "Caribbean.jpg")),
                Status = "Happy"
            };

            Car = new Post()
            {
                Id = 2,
                Content = "Check out my new lamborghini. It is the new model!",
                UserId = "68106d58-f54a-409c-92da-9184a75d55f7",
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
                UserId = "bbd4b588-917f-4634-8142-08f54ee760a1",
                CreatedDate = Convert.ToDateTime("28/04/2024"),
            };

            Nature = new Comment()
            {
                Id = 2,
                Content = "What a beautiful nature!",
                PostId = 1,
                UserId = "68106d58-f54a-409c-92da-9184a75d55f7",
                CreatedDate = Convert.ToDateTime("30/04/2024"),
            };
        }

        private void SeedLikes() 
        {
            Heart = new Like()
            {
                Id = 1,
                PostId = 1,
                UserId = "68106d58-f54a-409c-92da-9184a75d55f7",
                Variant = "Love"
            };

            Thumb = new Like()
            {
                Id = 2,
                PostId = 2,
                UserId = "bbd4b588-917f-4634-8142-08f54ee760a1",
                Variant = "Thumb"
            };
        }

        private void SeedFollows() 
        {
            Followee = new Follow()
            {
                Id = 1,
                UserId = "68106d58-f54a-409c-92da-9184a75d55f7",
                FollowerId = "bbd4b588-917f-4634-8142-08f54ee760a1"
            };

            Follower = new Follow()
            {
                Id = 2,
                UserId = "bbd4b588-917f-4634-8142-08f54ee760a1",
                FollowerId = "68106d58-f54a-409c-92da-9184a75d55f7",
            };
        }

        private void SeedNotifications() 
        {
            Like = new Notification()
            {
                Id = 1,
                UserId = "bbd4b588-917f-4634-8142-08f54ee760a1",
                OtherUserId= "68106d58-f54a-409c-92da-9184a75d55f7",
                Type = "Like",
                RelatedId = 1,
                IsRead = false
            };

            Comment = new Notification()
            {
                Id = 2,
                UserId = "68106d58-f54a-409c-92da-9184a75d55f7",
                OtherUserId = "bbd4b588-917f-4634-8142-08f54ee760a1",
                Type = "Comment",
                RelatedId = 1,
                IsRead = false
            };
        }

        private void SeedInformations() 
        {
            IvanInformation = new UserInformation()
            {
                Id = 1,
                UserId = "bbd4b588-917f-4634-8142-08f54ee760a1",
                Gender = "Male",
                BirthDate = Convert.ToDateTime("15/02/1999")
            };

            PeturInformation = new UserInformation()
            {
                Id = 2,
                UserId = "68106d58-f54a-409c-92da-9184a75d55f7",
                Gender = "Male",
                BirthDate = Convert.ToDateTime("15/02/1996")
            };
        }
    }
}
