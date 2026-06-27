namespace Application.Features.Teachers.GetTeacherById;

public class GetTeacherByIdResponse
{
    public Guid Id { get; set; }

    public Guid ParishId { get; set; }

    public string Code { get; set; } = string.Empty;

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