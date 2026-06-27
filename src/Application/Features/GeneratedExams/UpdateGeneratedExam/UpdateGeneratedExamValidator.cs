namespace Application.Features.GeneratedExams.UpdateGeneratedExam;

public static class UpdateGeneratedExamValidator
{
    public static List<string> Validate(
        UpdateGeneratedExamRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        if (request.ExamBlueprintId == Guid.Empty)
            errors.Add("ExamBlueprintId is required.");

        if (string.IsNullOrWhiteSpace(request.Code))
            errors.Add("Code is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        return errors;
    }
}