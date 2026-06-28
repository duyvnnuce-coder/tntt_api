using System.ComponentModel.DataAnnotations;

namespace Application.Features.CatechismClasses.CreateCatechismClass;

public class CreateCatechismClassRequest
{
    [Required]
    public Guid ParishId { get; set; }

    [Required]
    public Guid AcademicYearId { get; set; }

    [Required]
    public Guid CatechismGradeId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public int MaxStudents { get; set; }

    public bool IsActive { get; set; } = true;
}