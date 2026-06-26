namespace Application.Features.CatechismGrades.CreateCatechismGrade;

public static class CreateCatechismGradeValidator
{
    public static List<string> Validate(CreateCatechismGradeRequest request)
    {
        var errors = new List<string>();

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId is required.");

        if (string.IsNullOrWhiteSpace(request.Code))
            errors.Add("Code is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        return errors;
    }
}