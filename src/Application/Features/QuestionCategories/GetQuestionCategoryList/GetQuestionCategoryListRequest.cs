namespace Application.Features.QuestionCategories.GetQuestionCategoryList;

public class GetQuestionCategoryListRequest
{
    public string? Keyword { get; set; }

    public bool? IsActive { get; set; }
}