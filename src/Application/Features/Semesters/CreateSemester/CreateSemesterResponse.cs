namespace Application.Features.Semesters.CreateSemester;

public class CreateSemesterResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}