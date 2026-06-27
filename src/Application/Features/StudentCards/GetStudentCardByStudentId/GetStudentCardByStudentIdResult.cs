namespace Application.Features.StudentCards.GetStudentCardByStudentId;

public class GetStudentCardByStudentIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetStudentCardByStudentIdResponse? Data { get; set; }
}