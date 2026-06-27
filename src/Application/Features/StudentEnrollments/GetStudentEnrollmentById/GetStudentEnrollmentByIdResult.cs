namespace Application.Features.StudentEnrollments.GetStudentEnrollmentById;

public class GetStudentEnrollmentByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetStudentEnrollmentByIdResponse? Data { get; set; }
}