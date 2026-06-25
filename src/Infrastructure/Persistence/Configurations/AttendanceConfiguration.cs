using Domain.Entities;
using Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("attendances");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.IsPresent)
            .IsRequired();

        builder.Property(x => x.IsExcused)
            .IsRequired();

        builder.Property(x => x.Note)
            .HasMaxLength(500);

        builder.HasIndex(x => new
        {
            x.AttendanceSessionId,
            x.StudentId
        }).IsUnique();

        builder.HasOne(x => x.AttendanceSession)
            .WithMany(x => x.Attendances)
            .HasForeignKey(x => x.AttendanceSessionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Student)
            .WithMany()
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}