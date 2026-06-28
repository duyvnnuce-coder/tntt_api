namespace Application.Features.Questions.CreateQuestion;

public class CreateQuestionResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}