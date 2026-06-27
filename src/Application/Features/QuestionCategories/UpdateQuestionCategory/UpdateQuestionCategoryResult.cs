namespace Application.Features.QuestionCategories.UpdateQuestionCategory;

public class UpdateQuestionCategoryResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public UpdateQuestionCategoryResponse? Data { get; set; }
}