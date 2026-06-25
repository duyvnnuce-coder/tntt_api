using Domain.Common;

namespace Domain.Entities;

public class CatechismClass : BaseEntity
{
    public Guid ParishId { get; set; }

    public Guid AcademicYearId { get; set; }

    public Guid CatechismGradeId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public int MaxStudents { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation
    public Parish Parish { get; set; } = null!;

    public AcademicYear AcademicYear { get; set; } = null!;

    public CatechismGrade CatechismGrade { get; set; } = null!;

    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();

    public ICollection<AttendanceSession> AttendanceSessions { get; set; } = new List<AttendanceSession>();
}