using System.ComponentModel.DataAnnotations;

namespace Application.Features.CatechismClasses.UpdateCatechismClass;

public class UpdateCatechismClassRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public int MaxStudents { get; set; }

    public bool IsActive { get; set; }
}