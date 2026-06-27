namespace Application.Features.ExamScores.GetExamScoreById;

public static class GetExamScoreByIdValidator
{
    public static List<string> Validate(
        GetExamScoreByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}