using System.ComponentModel.DataAnnotations;

namespace Application.Features.Semesters.CreateSemester;

public class CreateSemesterRequest
{
    [Required]
    public Guid ParishId { get; set; }

    [Required]
    public Guid AcademicYearId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;



    public bool IsCurrent { get; set; }

    public int SemesterOrder { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}