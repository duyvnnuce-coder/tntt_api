namespace Application.Features.CatechismClasses.CreateCatechismClass;

public static class CreateCatechismClassValidator
{
    public static List<string> Validate(
        CreateCatechismClassRequest request)
    {
        var errors = new List<string>();

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId is required.");

        if (request.AcademicYearId == Guid.Empty)
            errors.Add("AcademicYearId is required.");

        if (request.CatechismGradeId == Guid.Empty)
            errors.Add("CatechismGradeId is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        return errors;
    }
}