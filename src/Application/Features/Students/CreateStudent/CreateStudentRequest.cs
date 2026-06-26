using System.ComponentModel.DataAnnotations;

namespace Application.Features.Students.CreateStudent;

public class CreateStudentRequest
{
    [Required]
    public Guid ParishId { get; set; }

    [Required]
    public Guid CatechismClassId { get; set; }

    [Required]
    public string ChristianName { get; set; } = string.Empty;

    [Required]
    public string FullName { get; set; } = string.Empty;

    public bool Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? ParentPhone { get; set; }

    public DateOnly JoinDate { get; set; }
}