namespace Application.Features.StudentEnrollments.GetStudentEnrollmentList;

public class GetStudentEnrollmentListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetStudentEnrollmentListResponse> Data { get; set; } = new();
}