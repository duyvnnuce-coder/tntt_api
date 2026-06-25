using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ExamScoreConfiguration : IEntityTypeConfiguration<ExamScore>
{
    public void Configure(EntityTypeBuilder<ExamScore> builder)
    {
        builder.ToTable("exam_scores");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Score)
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(x => x.Note)
            .HasMaxLength(500);

        builder.HasOne(x => x.Exam)
            .WithMany()
            .HasForeignKey(x => x.ExamId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Student)
            .WithMany()
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.ExamId,
            x.StudentId
        }).IsUnique();
    }
}