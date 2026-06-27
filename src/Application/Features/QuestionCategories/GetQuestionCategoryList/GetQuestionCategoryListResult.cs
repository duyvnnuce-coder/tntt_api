namespace Application.Features.QuestionCategories.GetQuestionCategoryList;

public class GetQuestionCategoryListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetQuestionCategoryListResponse> Data { get; set; } = new();
}