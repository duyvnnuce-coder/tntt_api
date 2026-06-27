namespace Application.Features.GeneratedExams.CreateGeneratedExam;

public static class CreateGeneratedExamValidator
{
    public static List<string> Validate(
        CreateGeneratedExamRequest request)
    {
        var errors = new List<string>();

        if (request.ExamBlueprintId == Guid.Empty)
            errors.Add("ExamBlueprintId is required.");

        if (string.IsNullOrWhiteSpace(request.Code))
            errors.Add("Code is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        return errors;
    }
}