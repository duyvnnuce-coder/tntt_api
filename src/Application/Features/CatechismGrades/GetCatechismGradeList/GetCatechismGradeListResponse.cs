namespace Application.Features.CatechismGrades.GetCatechismGradeList;

public class GetCatechismGradeListResponse
{
    public Guid Id { get; set; }

    public Guid ParishId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public bool IsActive { get; set; }
}