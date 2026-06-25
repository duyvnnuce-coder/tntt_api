using Domain.Entities;
using Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AssistantConfiguration : IEntityTypeConfiguration<Assistant>
{
    public void Configure(EntityTypeBuilder<Assistant> builder)
    {
        builder.ToTable("assistants");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Code)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(x => x.ChristianName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.FullName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Phone)
            .HasMaxLength(20);

        builder.Property(x => x.Email)
            .HasMaxLength(200);

        builder.Property(x => x.Address)
            .HasMaxLength(500);

        builder.Property(x => x.Gender)
            .IsRequired();

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasIndex(x => new
        {
            x.ParishId,
            x.Code
        }).IsUnique();

        builder.HasIndex(x => x.FullName);

        builder.HasOne(x => x.Parish)
            .WithMany(x => x.Assistants)
            .HasForeignKey(x => x.ParishId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Assignments)
            .WithOne(x => x.Assistant)
            .HasForeignKey(x => x.AssistantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}