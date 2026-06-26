namespace Application.Features.AcademicYears.CreateAcademicYear;

public class CreateAcademicYearResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateAcademicYearResponse? Data { get; set; }
}