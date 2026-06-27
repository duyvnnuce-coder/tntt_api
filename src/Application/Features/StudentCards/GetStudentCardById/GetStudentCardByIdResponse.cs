using Domain.Enums;

namespace Application.Features.StudentCards.GetStudentCardById;

public class GetStudentCardByIdResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public string Token { get; set; } = string.Empty;

    public string? CardNumber { get; set; }

    public DateOnly IssuedDate { get; set; }

    public DateOnly? ExpiredDate { get; set; }

    public StudentCardStatus Status { get; set; }

    public int PrintCount { get; set; }
}