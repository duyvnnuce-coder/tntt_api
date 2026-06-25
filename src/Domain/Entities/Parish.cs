using Domain.Common;

namespace Domain.Entities;

public class Parish : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public bool IsActive { get; set; } = true;

    public string? Description { get; set; }

    // Navigation
    public ICollection<AcademicYear> AcademicYears { get; set; } = new List<AcademicYear>();

    public ICollection<CatechismGrade> CatechismGrades { get; set; } = new List<CatechismGrade>();

    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();

    public ICollection<Assistant> Assistants { get; set; } = new List<Assistant>();

    public ICollection<Student> Students { get; set; } = new List<Student>();

    public ICollection<CatechismClass> CatechismClasses { get; set; } = new List<CatechismClass>();
}