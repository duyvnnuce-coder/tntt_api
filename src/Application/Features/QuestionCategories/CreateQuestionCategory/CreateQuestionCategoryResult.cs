namespace Application.Features.QuestionCategories.CreateQuestionCategory;

public class CreateQuestionCategoryResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateQuestionCategoryResponse? Data { get; set; }
}