namespace Application.Features.GeneratedExams.CreateGeneratedExam;

public class CreateGeneratedExamRequest
{
    public Guid ExamBlueprintId { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsPublished { get; set; }
}