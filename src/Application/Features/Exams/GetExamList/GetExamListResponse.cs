namespace Application.Features.Exams.GetExamList;

public class GetExamListResponse
{
    public Guid Id { get; set; }

    public Guid AssignmentId { get; set; }

    public string AssignmentCode { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateOnly ExamDate { get; set; }

    public decimal MaxScore { get; set; }

    public bool IsPublished { get; set; }
}