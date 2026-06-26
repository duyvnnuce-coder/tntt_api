using System.ComponentModel.DataAnnotations;

namespace Application.Features.AcademicYears.CreateAcademicYear;

public class CreateAcademicYearRequest
{
    [Required]
    public Guid ParishId { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public bool IsCurrent { get; set; }

    public int DisplayOrder { get; set; }
}