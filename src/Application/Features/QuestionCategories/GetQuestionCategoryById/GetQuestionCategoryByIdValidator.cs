namespace Application.Features.QuestionCategories.GetQuestionCategoryById;

public static class GetQuestionCategoryByIdValidator
{
    public static List<string> Validate(
        GetQuestionCategoryByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}