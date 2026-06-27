namespace Application.Features.QuestionCategories.GetQuestionCategoryById;

public class GetQuestionCategoryByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetQuestionCategoryByIdResponse? Data { get; set; }
}