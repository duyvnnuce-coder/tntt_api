using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AttendanceSessionConfiguration : IEntityTypeConfiguration<AttendanceSession>
{
    public void Configure(EntityTypeBuilder<AttendanceSession> builder)
    {
        builder.ToTable("attendance_sessions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AttendanceDate)
            .IsRequired();

        builder.Property(x => x.LessonNumber)
            .IsRequired();

        builder.Property(x => x.Topic)
            .HasMaxLength(200);

        builder.Property(x => x.IsLocked)
            .IsRequired();

        builder.HasOne(x => x.Assignment)
            .WithMany()
            .HasForeignKey(x => x.AssignmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.AssignmentId,
            x.AttendanceDate,
            x.LessonNumber
        }).IsUnique();
    }
}