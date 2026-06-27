using System.ComponentModel.DataAnnotations;

namespace Application.Features.CatechismGrades.CreateCatechismGrade;

public class CreateCatechismGradeRequest
{
    [Required]
    public Guid ParishId { get; set; }

    [Required]
    [MaxLength(20)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;
}