using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ExamBlueprintConfiguration : IEntityTypeConfiguration<ExamBlueprint>
{
    public void Configure(EntityTypeBuilder<ExamBlueprint> builder)
    {
        builder.ToTable("exam_blueprints");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.TotalQuestions)
            .IsRequired();

        builder.Property(x => x.DurationMinutes)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.CatechismGrade)
            .WithMany()
            .HasForeignKey(x => x.CatechismGradeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.CatechismGradeId,
            x.Code
        }).IsUnique();
    }
}