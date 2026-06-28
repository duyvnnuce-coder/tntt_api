namespace Application.Features.AcademicYears.GetAcademicYearById;

public class GetAcademicYearByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetAcademicYearByIdResponse? Data { get; set; }
}