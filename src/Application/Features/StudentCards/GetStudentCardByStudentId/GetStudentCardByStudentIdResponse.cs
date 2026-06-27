using Domain.Enums;

namespace Application.Features.StudentCards.GetStudentCardByStudentId;

public class GetStudentCardByStudentIdResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public string StudentCode { get; set; } = string.Empty;

    public string ChristianName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public string? CardNumber { get; set; }

    public DateOnly IssuedDate { get; set; }

    public DateOnly? ExpiredDate { get; set; }

    public StudentCardStatus Status { get; set; }

    public int PrintCount { get; set; }
}