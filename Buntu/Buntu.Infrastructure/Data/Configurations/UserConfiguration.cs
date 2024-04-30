using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buntu.Infrastructure.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var seed = new SeedData();

            builder.HasData(new []{ seed.Ivan, seed.Petur });
        }
    }
}
