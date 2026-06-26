using Domain.Common;


namespace Domain.Entities;

public class Student : BaseEntity
{
    public Guid ParishId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string ChristianName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public bool Gender { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public string? AvatarUrl { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public string? ParentPhone { get; set; }

    public DateOnly? JoinDate { get; set; }

    public bool IsActive { get; set; } = true;

    public string? Note { get; set; }

    // Navigation
    public Parish Parish { get; set; } = null!;

    public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();

    public ICollection<StudentCard> StudentCards { get; set; } = new List<StudentCard>();

    public ICollection<Sacrament> Sacraments { get; set; } = new List<Sacrament>();
}