namespace Application.Features.Assignments.GetAssignmentList;

public class GetAssignmentListResponse
{
    public Guid Id { get; set; }

    public Guid TeacherId { get; set; }

    public Guid? AssistantId { get; set; }

    public Guid CatechismClassId { get; set; }

    public Guid SemesterId { get; set; }

    public bool IsMainTeacher { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Note { get; set; }
}