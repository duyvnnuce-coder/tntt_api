using Domain.Entities;
using Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class StudentCardConfiguration : IEntityTypeConfiguration<StudentCard>
{
    public void Configure(EntityTypeBuilder<StudentCard> builder)
    {
        builder.ToTable("student_cards");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Token)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.IssuedDate)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.PrintCount)
            .IsRequired();

        builder.HasIndex(x => x.Token)
            .IsUnique();

        builder.Property(x => x.CardNumber)
            .HasMaxLength(50);

        builder.HasOne(x => x.Student)
            .WithMany(x => x.StudentCards)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}