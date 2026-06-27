namespace Application.Features.Exams.GetExamById;

public class GetExamByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetExamByIdResponse? Data { get; set; }
}