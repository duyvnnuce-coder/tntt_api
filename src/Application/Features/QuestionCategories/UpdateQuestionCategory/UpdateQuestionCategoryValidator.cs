namespace Application.Features.QuestionCategories.UpdateQuestionCategory;

public static class UpdateQuestionCategoryValidator
{
    public static List<string> Validate(
        UpdateQuestionCategoryRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId is required.");

        if (string.IsNullOrWhiteSpace(request.Code))
            errors.Add("Code is required.");

        if (string.IsNullOrWhiteSpace(request.Name))
            errors.Add("Name is required.");

        return errors;
    }
}