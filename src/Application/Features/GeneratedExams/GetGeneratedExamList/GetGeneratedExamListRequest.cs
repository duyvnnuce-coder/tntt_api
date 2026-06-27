namespace Application.Features.GeneratedExams.GetGeneratedExamList;

public class GetGeneratedExamListRequest
{
    public string? Keyword { get; set; }

    public Guid? ExamBlueprintId { get; set; }

    public bool? IsPublished { get; set; }
}