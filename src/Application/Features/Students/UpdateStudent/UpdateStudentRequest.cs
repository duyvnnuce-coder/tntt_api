namespace Application.Features.Students.UpdateStudent;

public class UpdateStudentRequest
{
    public Guid Id { get; set; }

    public string ChristianName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public bool Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? ParentPhone { get; set; }

    public bool IsActive { get; set; }

    public string? Note { get; set; }
}