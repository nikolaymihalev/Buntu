using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buntu.Infrastructure.Data.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            var seed = new SeedData();

            builder.HasData(new []{ seed.Holiday, seed.Car });
        }
    }
}
