namespace Application.Features.GeneratedExams.GetGeneratedExamList;

public class GetGeneratedExamListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetGeneratedExamListResponse> Data { get; set; } = new();
}