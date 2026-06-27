namespace Application.Features.Teachers.GetTeacherById;

public class GetTeacherByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetTeacherByIdResponse? Data { get; set; }
}