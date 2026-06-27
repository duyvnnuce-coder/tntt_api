namespace Application.Features.ExamScores.CreateExamScore;

public static class CreateExamScoreValidator
{
    public static List<string> Validate(
        CreateExamScoreRequest request)
    {
        var errors = new List<string>();

        if (request.ExamId == Guid.Empty)
            errors.Add("ExamId is required.");

        if (request.StudentId == Guid.Empty)
            errors.Add("StudentId is required.");

        if (request.Score < 0)
            errors.Add("Score must be greater than or equal to 0.");

        return errors;
    }
}