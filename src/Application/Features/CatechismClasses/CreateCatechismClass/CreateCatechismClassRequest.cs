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
    [MaxLength(20)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public int MaxStudents { get; set; } = 50;
}