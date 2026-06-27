namespace Application.Features.Questions.CreateQuestion;

public class CreateQuestionResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateQuestionResponse? Data { get; set; }
}