namespace Application.Features.AcademicYears.CreateAcademicYear;

public static class CreateAcademicYearValidator
{
    public static List<string> Validate(CreateAcademicYearRequest request)
    {
        var errors = new List<string>();

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        return errors;
    }
}