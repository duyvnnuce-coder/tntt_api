namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailList;

public class GetExamBlueprintDetailListRequest
{
    public Guid? ExamBlueprintId { get; set; }

    public Guid? QuestionCategoryId { get; set; }

    public string? Keyword { get; set; }
}