namespace Application.Features.Questions.GetQuestionList;

public class GetQuestionListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetQuestionListResponse> Data { get; set; } = new();
}