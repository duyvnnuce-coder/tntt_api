namespace Application.Features.Students.GetStudentList;

public class GetStudentListResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string ChristianName { get; set; } = string.Empty;

    public bool Gender { get; set; }
}