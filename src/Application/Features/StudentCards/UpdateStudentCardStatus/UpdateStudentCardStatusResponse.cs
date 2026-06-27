using Domain.Enums;

namespace Application.Features.StudentCards.UpdateStudentCardStatus;

public class UpdateStudentCardStatusResponse
{
    public Guid Id { get; set; }

    public StudentCardStatus Status { get; set; }
}