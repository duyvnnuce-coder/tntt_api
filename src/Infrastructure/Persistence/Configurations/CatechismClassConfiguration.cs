using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Configurations.Extensions;

namespace Infrastructure.Persistence.Configurations;

public class CatechismClassConfiguration : IEntityTypeConfiguration<CatechismClass>
{
    public void Configure(EntityTypeBuilder<CatechismClass> builder)
    {
        builder.ToTable("catechism_classes");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        builder.Property(x => x.MaxStudents)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.Parish)
            .WithMany(x => x.CatechismClasses)
            .HasForeignKey(x => x.ParishId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AcademicYear)
            .WithMany(x => x.CatechismClasses)
            .HasForeignKey(x => x.AcademicYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CatechismGrade)
            .WithMany(x => x.CatechismClasses)
            .HasForeignKey(x => x.CatechismGradeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.ParishId,
            x.AcademicYearId,
            x.Code
        }).IsUnique();

        builder.HasIndex(x => x.ParishId);

        builder.HasIndex(x => x.AcademicYearId);

        builder.HasIndex(x => x.CatechismGradeId);
    }
}