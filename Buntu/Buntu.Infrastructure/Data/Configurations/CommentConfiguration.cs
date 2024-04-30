using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buntu.Infrastructure.Data.Configurations
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            var seed = new SeedData();

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(new []{ seed.NiceCar, seed.Nature });
        }
    }
}
