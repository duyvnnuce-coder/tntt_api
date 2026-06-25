using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Configurations.Extensions;

namespace Infrastructure.Persistence.Configurations;

public class CatechismGradeConfiguration : IEntityTypeConfiguration<CatechismGrade>
{
    public void Configure(EntityTypeBuilder<CatechismGrade> builder)
    {
        builder.ToTable("catechism_grades");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasIndex(x => new { x.ParishId, x.Code })
            .IsUnique();

        builder.HasIndex(x => x.ParishId);

        builder.HasIndex(x => x.DisplayOrder);

        builder.HasOne(x => x.Parish)
            .WithMany(x => x.CatechismGrades)
            .HasForeignKey(x => x.ParishId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}