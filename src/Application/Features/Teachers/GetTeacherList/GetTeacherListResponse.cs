namespace Application.Features.Teachers.GetTeacherList;

public class GetTeacherListResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string ChristianName { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public bool Gender { get; set; }

    public string? Phone { get; set; }

    public bool IsActive { get; set; }
}