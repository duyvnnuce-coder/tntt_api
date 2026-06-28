namespace Application.Features.Parishes.UpdateParish;

public class UpdateParishRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}