namespace Application.Features.Questions.GetQuestionById;

public class GetQuestionByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetQuestionByIdResponse? Data { get; set; }
}