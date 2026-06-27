namespace Application.Features.Exams.UpdateExam;

public static class UpdateExamValidator
{
    public static List<string> Validate(
        UpdateExamRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        if (request.AssignmentId == Guid.Empty)
            errors.Add("AssignmentId is required.");

        if (string.IsNullOrWhiteSpace(request.Code))
            errors.Add("Code is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        if (request.MaxScore <= 0)
            errors.Add("MaxScore must be greater than 0.");

        return errors;
    }
}