namespace Application.Features.StudentEnrollments.CreateStudentEnrollment;

public class CreateStudentEnrollmentResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateStudentEnrollmentResponse? Data { get; set; }
}