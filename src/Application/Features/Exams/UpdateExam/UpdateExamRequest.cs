namespace Application.Features.Exams.UpdateExam;

public class UpdateExamRequest
{
    public Guid Id { get; set; }

    public Guid AssignmentId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateOnly ExamDate { get; set; }

    public decimal MaxScore { get; set; }

    public bool IsPublished { get; set; }
}