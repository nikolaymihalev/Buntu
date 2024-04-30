using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buntu.Infrastructure.Data.Configurations
{
    internal class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            var seed = new SeedData();

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Likes)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new []{ seed.Heart, seed.Thumb });
        }
    }
}
