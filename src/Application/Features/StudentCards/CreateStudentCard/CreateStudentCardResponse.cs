namespace Application.Features.StudentCards.CreateStudentCard;

public class CreateStudentCardResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public string CardNumber { get; set; } = string.Empty;
}