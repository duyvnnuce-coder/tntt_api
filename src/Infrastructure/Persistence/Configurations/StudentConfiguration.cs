using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("students");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.ChristianName)
            .HasMaxLength(100);

        builder.Property(x => x.FullName)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasMaxLength(100);

        builder.Property(x => x.Address)
            .HasMaxLength(300);

        builder.Property(x => x.FatherName)
            .HasMaxLength(150);

        builder.Property(x => x.MotherName)
            .HasMaxLength(150);

        builder.Property(x => x.ParentPhone)
            .HasMaxLength(20);

        builder.HasIndex(x => new { x.ParishId, x.Code })
            .IsUnique();

        builder.HasOne(x => x.Parish)
            .WithMany()
            .HasForeignKey(x => x.ParishId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}