namespace Application.Features.GeneratedExams.UpdateGeneratedExam;

public class UpdateGeneratedExamResponse
{
    public Guid Id { get; set; }

    public Guid ExamBlueprintId { get; set; }

    public string ExamBlueprintName { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateTime GeneratedAt { get; set; }

    public bool IsPublished { get; set; }
}