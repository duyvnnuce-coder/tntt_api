namespace Application.Features.Teachers.CreateTeacher;

public class CreateTeacherResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}