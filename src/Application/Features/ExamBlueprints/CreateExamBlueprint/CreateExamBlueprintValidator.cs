namespace Application.Features.ExamBlueprints.CreateExamBlueprint;

public static class CreateExamBlueprintValidator
{
    public static List<string> Validate(
        CreateExamBlueprintRequest request)
    {
        var errors = new List<string>();

        if (request.CatechismGradeId == Guid.Empty)
            errors.Add("CatechismGradeId is required.");

        if (string.IsNullOrWhiteSpace(request.Code))
            errors.Add("Code is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        if (request.TotalQuestions <= 0)
            errors.Add("TotalQuestions must be greater than 0.");

        if (request.DurationMinutes <= 0)
            errors.Add("DurationMinutes must be greater than 0.");

        return errors;
    }
}