using Domain.Common;

namespace Domain.Entities;

public class Teacher : BaseEntity
{
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

    public bool IsActive { get; set; } = true;

    // Navigation
    public Parish Parish { get; set; } = null!;

    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}