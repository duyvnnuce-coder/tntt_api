namespace Application.Features.Exams.CreateExam;

public class CreateExamResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}