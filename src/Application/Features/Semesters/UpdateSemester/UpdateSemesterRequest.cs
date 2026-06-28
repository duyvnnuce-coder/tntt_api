namespace Application.Features.Semesters.UpdateSemester;

public class UpdateSemesterRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public int SemesterOrder { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }
}