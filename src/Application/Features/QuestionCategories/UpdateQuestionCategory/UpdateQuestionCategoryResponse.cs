namespace Application.Features.QuestionCategories.UpdateQuestionCategory;

public class UpdateQuestionCategoryResponse
{
    public Guid Id { get; set; }

    public Guid ParishId { get; set; }

    public string ParishCode { get; set; } = string.Empty;

    public string ParishName { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}