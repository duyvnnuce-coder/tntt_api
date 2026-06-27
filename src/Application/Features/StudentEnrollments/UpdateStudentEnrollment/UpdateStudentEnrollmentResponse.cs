namespace Application.Features.StudentEnrollments.UpdateStudentEnrollment;

public class UpdateStudentEnrollmentResponse
{
    public Guid Id { get; set; }

    public Guid StudentId { get; set; }

    public Guid CatechismClassId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? LeaveDate { get; set; }

    public bool IsCurrent { get; set; }

    public string? Note { get; set; }
}