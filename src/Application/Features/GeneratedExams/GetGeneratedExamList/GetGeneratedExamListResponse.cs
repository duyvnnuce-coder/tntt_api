namespace Application.Features.GeneratedExams.GetGeneratedExamList;

public class GetGeneratedExamListResponse
{
    public Guid Id { get; set; }

    public Guid ExamBlueprintId { get; set; }

    public string ExamBlueprintCode { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateTime GeneratedAt { get; set; }

    public bool IsPublished { get; set; }
}