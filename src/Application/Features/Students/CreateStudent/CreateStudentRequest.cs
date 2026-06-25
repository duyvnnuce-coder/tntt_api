namespace Application.Features.Students.CreateStudent;

public class CreateStudentRequest
{
    public Guid ParishId { get; set; }

    public Guid CatechismClassId { get; set; }

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

    public DateOnly? JoinDate { get; set; }
}