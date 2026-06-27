namespace Application.Features.StudentCards.UpdateStudentCardStatus;

public class UpdateStudentCardStatusResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public UpdateStudentCardStatusResponse? Data { get; set; }
}