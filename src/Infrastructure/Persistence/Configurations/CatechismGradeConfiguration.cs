using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class CatechismGradeConfiguration : IEntityTypeConfiguration<CatechismGrade>
{
    public void Configure(EntityTypeBuilder<CatechismGrade> builder)
    {
        builder.ToTable("catechism_grades");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.DisplayOrder)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasIndex(x => new { x.ParishId, x.Code })
            .IsUnique();

        builder.HasOne(x => x.Parish)
            .WithMany(x => x.CatechismGrades)
            .HasForeignKey(x => x.ParishId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}