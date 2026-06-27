namespace Application.Features.StudentEnrollments.CreateStudentEnrollment;

public class CreateStudentEnrollmentResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CatechismClassId { get; set; }

    public DateOnly JoinDate { get; set; }

    public bool IsCurrent { get; set; }
}