using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Configurations.Extensions;

namespace Infrastructure.Persistence.Configurations;

public class ParishConfiguration : IEntityTypeConfiguration<Parish>
{
    public void Configure(EntityTypeBuilder<Parish> builder)
    {
        builder.ToTable("parishes");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Address)
            .HasMaxLength(500);

        builder.Property(x => x.Phone)
            .HasMaxLength(20);

        builder.Property(x => x.Description)
            .HasMaxLength(1000);

        builder.HasIndex(x => x.IsDeleted);

        builder.Property(x => x.RowVersion)
            .IsRowVersion();
    }
}