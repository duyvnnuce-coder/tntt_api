using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Configurations.Extensions;

namespace Infrastructure.Persistence.Configurations;

public class AcademicYearConfiguration : IEntityTypeConfiguration<AcademicYear>
{
    public void Configure(EntityTypeBuilder<AcademicYear> builder)
    {
        builder.ToTable("academic_years");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.IsCurrent)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        builder.HasIndex(x => new { x.ParishId, x.Code })
            .IsUnique();

        builder.HasIndex(x => x.ParishId);

        builder.HasIndex(x => x.IsCurrent);

        builder.HasOne(x => x.Parish)
            .WithMany(x => x.AcademicYears)
            .HasForeignKey(x => x.ParishId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}