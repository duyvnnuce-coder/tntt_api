using Domain.Common;

namespace Application.Features.Sacraments.GetSacramentById;

public class GetSacramentByIdResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public SacramentType Type { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public string? ChurchName { get; set; }

    public string? Minister { get; set; }

    public string? CertificateNumber { get; set; }

    public string? Note { get; set; }
}