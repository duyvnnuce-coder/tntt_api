namespace Application.Features.QuestionCategories.GetQuestionCategoryList;

public class GetQuestionCategoryListResponse
{
    public Guid Id { get; set; }

    public Guid ParishId { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}