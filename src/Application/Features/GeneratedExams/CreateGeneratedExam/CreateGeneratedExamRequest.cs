namespace Application.Features.GeneratedExams.CreateGeneratedExam;

public class CreateGeneratedExamRequest
{
    public Guid ExamBlueprintId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateTime GeneratedAt { get; set; }

    public bool IsPublished { get; set; }
}