using Domain.Common;

namespace Domain.Entities;

public class CatechismGrade : BaseEntity
{
    public Guid ParishId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation
    public Parish Parish { get; set; } = null!;

    public ICollection<CatechismClass> CatechismClasses { get; set; } = new List<CatechismClass>();
}