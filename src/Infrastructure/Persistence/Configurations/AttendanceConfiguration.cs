using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("attendances");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsPresent)
            .IsRequired();

        builder.Property(x => x.IsExcused)
            .IsRequired();

        builder.Property(x => x.Note)
            .HasMaxLength(500);

        builder.HasOne(x => x.AttendanceSession)
            .WithMany()
            .HasForeignKey(x => x.AttendanceSessionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Student)
            .WithMany()
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.AttendanceSessionId,
            x.StudentId
        }).IsUnique();
    }
}