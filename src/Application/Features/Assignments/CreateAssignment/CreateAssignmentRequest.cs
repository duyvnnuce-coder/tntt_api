using System.ComponentModel.DataAnnotations;

namespace Application.Features.Assignments.CreateAssignment;

public class CreateAssignmentRequest
{
    [Required]
    public Guid TeacherId { get; set; }

    public Guid? AssistantId { get; set; }

    [Required]
    public Guid CatechismClassId { get; set; }

    [Required]
    public Guid SemesterId { get; set; }

    public bool IsMainTeacher { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    [MaxLength(500)]
    public string? Note { get; set; }
}