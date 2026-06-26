namespace Application.Features.Assignments.CreateAssignment;

public class CreateAssignmentResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateAssignmentResponse? Data { get; set; }
}