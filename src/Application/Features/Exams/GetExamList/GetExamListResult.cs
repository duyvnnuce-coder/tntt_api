namespace Application.Features.Exams.GetExamList;

public class GetExamListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetExamListResponse> Data { get; set; } = new();
}