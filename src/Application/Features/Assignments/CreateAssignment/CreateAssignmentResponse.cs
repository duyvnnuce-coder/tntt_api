namespace Application.Features.Assignments.CreateAssignment;

public class CreateAssignmentResponse
{
    public Guid Id { get; set; }

    public Guid SemesterId { get; set; }

    public Guid CatechismClassId { get; set; }

    public Guid TeacherId { get; set; }

    public Guid? AssistantId { get; set; }
}