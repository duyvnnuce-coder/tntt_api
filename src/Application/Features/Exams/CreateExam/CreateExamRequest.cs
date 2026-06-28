namespace Application.Features.Exams.CreateExam;

public class CreateExamRequest
{
    public Guid AssignmentId { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateOnly ExamDate { get; set; }

    public decimal MaxScore { get; set; }

    public bool IsPublished { get; set; }
}