using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Configurations.Extensions;

namespace Infrastructure.Persistence.Configurations;

public class GeneratedExamConfiguration : IEntityTypeConfiguration<GeneratedExam>
{
    public void Configure(EntityTypeBuilder<GeneratedExam> builder)
    {
        builder.ToTable("generated_exams");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.GeneratedAt)
            .IsRequired();

        builder.Property(x => x.IsPublished)
            .IsRequired();

        builder.HasOne(x => x.ExamBlueprint)
            .WithMany()
            .HasForeignKey(x => x.ExamBlueprintId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}