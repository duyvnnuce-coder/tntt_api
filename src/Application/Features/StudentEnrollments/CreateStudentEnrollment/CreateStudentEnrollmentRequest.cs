namespace Application.Features.StudentEnrollments.CreateStudentEnrollment;

public class CreateStudentEnrollmentRequest
{
    public Guid StudentId { get; set; }

    public Guid CatechismClassId { get; set; }

    public DateOnly JoinDate { get; set; }

    public string? Note { get; set; }
}