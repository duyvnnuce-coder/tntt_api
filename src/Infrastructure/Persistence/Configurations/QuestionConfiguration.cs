using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infrastructure.Persistence.Configurations.Extensions;

namespace Infrastructure.Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Content)
            .HasMaxLength(2000)
            .IsRequired();

        builder.Property(x => x.AnswerA)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.AnswerB)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(x => x.AnswerC)
            .HasMaxLength(1000);

        builder.Property(x => x.AnswerD)
            .HasMaxLength(1000);

        builder.Property(x => x.CorrectAnswer)
            .HasMaxLength(1)
            .IsRequired();

        builder.Property(x => x.DifficultyLevel)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.QuestionCategory)
           .WithMany(x => x.Questions)
            .HasForeignKey(x => x.QuestionCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CatechismGrade)
            .WithMany()
            .HasForeignKey(x => x.CatechismGradeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.QuestionCategoryId,
            x.CatechismGradeId
        });
    }
}