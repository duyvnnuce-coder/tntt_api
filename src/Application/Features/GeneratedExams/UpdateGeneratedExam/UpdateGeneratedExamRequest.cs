namespace Application.Features.GeneratedExams.UpdateGeneratedExam;

public class UpdateGeneratedExamRequest
{
    public Guid Id { get; set; }

    public Guid ExamBlueprintId { get; set; }

    public string Name { get; set; } = string.Empty;

    public bool IsPublished { get; set; }
}