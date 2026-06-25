using Domain.Entities;
using Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("assignments");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.IsMainTeacher)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.HasIndex(x => new
        {
            x.SemesterId,
            x.ClassId,
            x.TeacherId
        });

        builder.HasOne(x => x.Teacher)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Assistant)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.AssistantId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Class)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.ClassId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Semester)
            .WithMany(x => x.Assignments)
            .HasForeignKey(x => x.SemesterId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Note)
            .HasMaxLength(500);
    }
}