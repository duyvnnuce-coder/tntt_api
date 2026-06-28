namespace Application.Features.QuestionCategories.CreateQuestionCategory;

public class CreateQuestionCategoryResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}