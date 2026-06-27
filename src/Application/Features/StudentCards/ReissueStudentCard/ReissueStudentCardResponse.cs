using Domain.Enums;

namespace Application.Features.StudentCards.ReissueStudentCard;

public class ReissueStudentCardResponse
{
    public Guid Id { get; set; }

    public string Token { get; set; } = string.Empty;

    public string? CardNumber { get; set; }

    public int PrintCount { get; set; }

    public StudentCardStatus Status { get; set; }
}