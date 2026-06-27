namespace Application.Features.StudentEnrollments.UpdateStudentEnrollment;

public class UpdateStudentEnrollmentResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public UpdateStudentEnrollmentResponse? Data { get; set; }
}