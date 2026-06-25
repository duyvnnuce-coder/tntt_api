using Domain.Common;

namespace Domain.Entities;

public class Parish : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }

    // Navigation
    public ICollection<AcademicYear> AcademicYears { get; set; } = new List<AcademicYear>();

    public ICollection<CatechismGrade> CatechismGrades { get; set; } = new List<CatechismGrade>();
}