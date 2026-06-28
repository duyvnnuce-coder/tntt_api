namespace Application.Features.CatechismGrades.UpdateCatechismGrade;

public class UpdateCatechismGradeRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }
}