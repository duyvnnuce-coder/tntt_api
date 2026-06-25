using Domain.Common;

namespace Domain.Entities;

public class Semester : BaseEntity
{
    public Guid AcademicYearId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int SemesterOrder { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }

    // Navigation
    public AcademicYear AcademicYear { get; set; } = null!;

    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}