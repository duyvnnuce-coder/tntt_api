namespace Application.Features.Questions.UpdateQuestion;

public static class UpdateQuestionValidator
{
    public static List<string> Validate(
        UpdateQuestionRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

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