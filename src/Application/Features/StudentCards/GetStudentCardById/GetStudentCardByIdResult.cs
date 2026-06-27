namespace Application.Features.StudentCards.GetStudentCardById;

public class GetStudentCardByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetStudentCardByIdResponse? Data { get; set; }
}