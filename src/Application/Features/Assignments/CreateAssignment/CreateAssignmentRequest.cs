using System.ComponentModel.DataAnnotations;

namespace Application.Features.Assignments.CreateAssignment;

public class CreateAssignmentRequest
{
    [Required]
    public Guid SemesterId { get; set; }

    [Required]
    public Guid CatechismClassId { get; set; }

    [Required]
    public Guid TeacherId { get; set; }

    public Guid? AssistantId { get; set; }

    public bool IsMainTeacher { get; set; } = true;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public string? Note { get; set; }
}