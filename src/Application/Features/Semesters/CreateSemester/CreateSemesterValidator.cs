namespace Application.Features.Semesters.CreateSemester;

public static class CreateSemesterValidator
{
    public static List<string> Validate(CreateSemesterRequest request)
    {
        var errors = new List<string>();

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId is required.");

        if (request.AcademicYearId == Guid.Empty)
            errors.Add("AcademicYearId is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        return errors;
    }
}