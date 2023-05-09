using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.Seed;
using Domain.Extensions;

namespace Infrastructure.EntityConfiguration
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(200);

            builder.Property(x => x.CreatedAt)
             .HasDefaultValueSql("(UTC_TIMESTAMP)");
        }

    }
}