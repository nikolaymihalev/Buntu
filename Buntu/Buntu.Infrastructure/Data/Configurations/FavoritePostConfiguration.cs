using Buntu.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buntu.Infrastructure.Data.Configurations
{
    internal class FavoritePostConfiguration : IEntityTypeConfiguration<FavoritePost>
    {
        public void Configure(EntityTypeBuilder<FavoritePost> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.FavoritePosts)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
