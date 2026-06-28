namespace Application.Features.Parishes.GetParishById;

public class GetParishByIdResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;


    public string? Address { get; set; }

    public string? Phone { get; set; }


    public bool IsActive { get; set; }
}