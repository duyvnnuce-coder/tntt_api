using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Exam>
{
    public void Configure(EntityTypeBuilder<Exam> builder)
    {
        builder.ToTable("exams");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.ExamDate)
            .IsRequired();

        builder.Property(x => x.MaxScore)
            .HasPrecision(5, 2)
            .IsRequired();

        builder.Property(x => x.IsPublished)
            .IsRequired();

        builder.HasOne(x => x.Assignment)
            .WithMany()
            .HasForeignKey(x => x.AssignmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.AssignmentId,
            x.Code
        }).IsUnique();
    }
}