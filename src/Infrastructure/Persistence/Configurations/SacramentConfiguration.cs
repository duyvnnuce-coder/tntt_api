using Domain.Entities;
using Infrastructure.Persistence.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class SacramentConfiguration : IEntityTypeConfiguration<Sacrament>
{
    public void Configure(EntityTypeBuilder<Sacrament> builder)
    {
        builder.ToTable("sacraments");

        builder.ConfigureBaseEntity();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.ChurchName)
            .HasMaxLength(200);

        builder.Property(x => x.Minister)
            .HasMaxLength(150);

        builder.Property(x => x.CertificateNumber)
            .HasMaxLength(100);

        builder.Property(x => x.Note)
            .HasMaxLength(500);

        builder.HasOne(x => x.Student)
            .WithMany(x => x.Sacraments)
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.StudentId,
            x.Type
        }).IsUnique();
    }
}