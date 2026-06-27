namespace Application.Features.Teachers.GetTeacherList;

public class GetTeacherListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetTeacherListResponse> Data { get; set; } = [];
}