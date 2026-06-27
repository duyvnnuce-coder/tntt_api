namespace Application.Features.ExamScores.UpdateExamScore;

public static class UpdateExamScoreValidator
{
    public static List<string> Validate(
        UpdateExamScoreRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        if (request.ExamId == Guid.Empty)
            errors.Add("ExamId is required.");

        if (request.StudentId == Guid.Empty)
            errors.Add("StudentId is required.");

        if (request.Score < 0)
            errors.Add("Score must be greater than or equal to 0.");

        return errors;
    }
}