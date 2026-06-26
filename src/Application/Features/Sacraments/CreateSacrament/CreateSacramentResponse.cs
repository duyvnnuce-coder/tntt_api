using Domain.Entities;

namespace Application.Features.Sacraments.CreateSacrament;

public class CreateSacramentResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public SacramentType Type { get; set; }
}