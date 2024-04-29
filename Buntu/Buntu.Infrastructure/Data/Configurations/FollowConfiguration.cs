using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buntu.Infrastructure.Data.Configurations
{
    internal class FollowConfiguration : IEntityTypeConfiguration<Follow>
    {
        public void Configure(EntityTypeBuilder<Follow> builder)
        {
            var seed = new SeedData();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Follows)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Follower)
                .WithMany(x => x.Followers)
                .HasForeignKey(x=>x.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new { seed.Followee, seed.Follower });
        }
    }
}
