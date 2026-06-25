using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ParishConfiguration : IEntityTypeConfiguration<Parish>
{
    public void Configure(EntityTypeBuilder<Parish> builder)
    {
        builder.ToTable("parishes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property(x => x.Address)
            .HasMaxLength(300);

        builder.Property(x => x.Phone)
            .HasMaxLength(20);

        builder.Property(x => x.Description)
            .HasMaxLength(500);

        builder.HasIndex(x => x.IsDeleted);

        builder.Property(x => x.RowVersion)
            .IsRowVersion();
    }
}