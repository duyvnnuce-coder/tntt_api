using Domain.Entities;

namespace Application.Features.Sacraments.GetSacramentList;

public class GetSacramentListResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public SacramentType Type { get; set; }

    public DateOnly? ReceivedDate { get; set; }

    public string? ChurchName { get; set; }
}