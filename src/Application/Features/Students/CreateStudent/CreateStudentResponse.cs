namespace Application.Features.Students.CreateStudent;

public class CreateStudentResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}