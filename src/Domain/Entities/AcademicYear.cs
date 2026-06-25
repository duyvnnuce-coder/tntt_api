using Domain.Common;

namespace Domain.Entities;

public class AcademicYear : BaseEntity
{
    public Guid ParishId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }

    // Navigation
    public Parish Parish { get; set; } = null!;

    public ICollection<Semester> Semesters { get; set; } = new List<Semester>();
}