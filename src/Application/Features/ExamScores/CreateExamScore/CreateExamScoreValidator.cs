namespace Application.Features.ExamScores.CreateExamScore;

public static class CreateExamScoreValidator
{
    public static string? Validate(CreateExamScoreRequest request)
    {
        if (request.ExamId == Guid.Empty)
            return "Kỳ thi không hợp lệ.";

        if (request.StudentId == Guid.Empty)
            return "Học sinh không hợp lệ.";

        if (request.Score < 0)
            return "Điểm không hợp lệ.";

        return null;
    }
}