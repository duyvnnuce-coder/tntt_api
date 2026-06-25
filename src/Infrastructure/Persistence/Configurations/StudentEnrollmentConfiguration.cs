using Domain.Entities;
using Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StudentEnrollmentConfiguration : IEntityTypeConfiguration<StudentEnrollment>
{
    public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
    {
        builder.ToTable("student_enrollments");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.JoinDate)
            .IsRequired();

        builder.Property(x => x.IsCurrent)
            .IsRequired();

        builder.Property(x => x.Note)
            .HasMaxLength(500);

        builder.HasIndex(x => new
        {
            x.StudentId,
            x.CatechismClassId,
            x.JoinDate
        });

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Enrollments)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CatechismClass)
            .WithMany(x => x.Enrollments)
            .HasForeignKey(x => x.CatechismClassId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}