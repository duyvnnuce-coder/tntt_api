namespace Application.Features.StudentEnrollments.GetStudentEnrollmentList;

public class GetStudentEnrollmentListRequest
{
    public string? Keyword { get; set; }

    public bool? IsCurrent { get; set; }
}