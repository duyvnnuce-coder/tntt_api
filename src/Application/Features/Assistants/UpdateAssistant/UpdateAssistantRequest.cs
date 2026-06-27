namespace Application.Features.Assistants.UpdateAssistant;

public class UpdateAssistantRequest
{
    public Guid Id { get; set; }

    public string ChristianName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public DateOnly? DateOfBirth { get; set; }

    public bool Gender { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateOnly? JoinDate { get; set; }

    public bool IsActive { get; set; }
}