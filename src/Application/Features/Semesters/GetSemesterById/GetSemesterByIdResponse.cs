namespace Application.Features.Semesters.GetSemesterById;

public class GetSemesterByIdResponse
{
    public Guid Id { get; set; }

    public Guid AcademicYearId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int SemesterOrder { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsCurrent { get; set; }
}