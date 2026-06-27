namespace Application.Features.ExamBlueprints.GetExamBlueprintList;

public class GetExamBlueprintListRequest
{
    public string? Keyword { get; set; }

    public Guid? CatechismGradeId { get; set; }

    public bool? IsActive { get; set; }
}