namespace Application.Features.Semesters.GetSemesterById;

public class GetSemesterByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetSemesterByIdResponse? Data { get; set; }
}