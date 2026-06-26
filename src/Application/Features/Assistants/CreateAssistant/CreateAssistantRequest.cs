using System.ComponentModel.DataAnnotations;

namespace Application.Features.Assistants.CreateAssistant;

public class CreateAssistantRequest
{
    [Required]
    public Guid ParishId { get; set; }

    [Required]
    [MaxLength(200)]
    public string FullName { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ChristianName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public bool Gender { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [EmailAddress]
    [MaxLength(200)]
    public string? Email { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }

    public DateOnly? JoinDate { get; set; }
}