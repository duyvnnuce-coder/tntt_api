using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Configurations.Extensions;

namespace Infrastructure.Persistence.Configurations;

public class ExamBlueprintDetailConfiguration : IEntityTypeConfiguration<ExamBlueprintDetail>
{
    public void Configure(EntityTypeBuilder<ExamBlueprintDetail> builder)
    {
        builder.ToTable("exam_blueprint_details");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.EasyQuestions)
            .IsRequired();

        builder.Property(x => x.MediumQuestions)
            .IsRequired();

        builder.Property(x => x.HardQuestions)
            .IsRequired();

        builder.HasOne(x => x.ExamBlueprint)
            .WithMany()
            .HasForeignKey(x => x.ExamBlueprintId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.QuestionCategory)
            .WithMany()
            .HasForeignKey(x => x.QuestionCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.ExamBlueprintId,
            x.QuestionCategoryId
        }).IsUnique();
    }
}