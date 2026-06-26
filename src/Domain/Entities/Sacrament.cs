using Domain.Common;

namespace Domain.Entities;

public class Sacrament : BaseEntity
{
    public Guid StudentId { get; set; }

    public SacramentType Type { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public string? ChurchName { get; set; }

    public string? Minister { get; set; }

    public string? CertificateNumber { get; set; }

    public string? Note { get; set; }

    // Navigation
    public Student Student { get; set; } = null!;
}