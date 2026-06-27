namespace Application.Features.StudentCards.ReissueStudentCard;

public class ReissueStudentCardResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public ReissueStudentCardResponse? Data { get; set; }
}