namespace Application.Features.StudentCards.CreateStudentCard;

public class CreateStudentCardResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateStudentCardResponse? Data { get; set; }
}