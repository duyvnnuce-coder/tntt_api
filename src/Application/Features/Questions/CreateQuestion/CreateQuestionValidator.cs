namespace Application.Features.Questions.CreateQuestion;

public static class CreateQuestionValidator
{
    public static List<string> Validate(
        CreateQuestionRequest request)
    {
        var errors = new List<string>();

        if (request.QuestionCategoryId == Guid.Empty)
            errors.Add("QuestionCategoryId is required.");

        if (request.CatechismGradeId == Guid.Empty)
            errors.Add("CatechismGradeId is required.");

        if (string.IsNullOrWhiteSpace(request.Code))
            errors.Add("Code is required.");

        if (string.IsNullOrWhiteSpace(request.Content))
            errors.Add("Content is required.");

        if (string.IsNullOrWhiteSpace(request.AnswerA))
            errors.Add("AnswerA is required.");

        if (string.IsNullOrWhiteSpace(request.AnswerB))
            errors.Add("AnswerB is required.");

        if (string.IsNullOrWhiteSpace(request.CorrectAnswer))
            errors.Add("CorrectAnswer is required.");

        return errors;
    }
}