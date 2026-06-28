namespace Application.Features.Assignments.GetAssignmentById;

public class GetAssignmentByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetAssignmentByIdResponse? Data { get; set; }
}