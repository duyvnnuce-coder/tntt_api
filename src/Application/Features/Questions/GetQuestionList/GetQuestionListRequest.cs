namespace Application.Features.Questions.GetQuestionList;

public class GetQuestionListRequest
{
    public string? Keyword { get; set; }

    public Guid? QuestionCategoryId { get; set; }

    public Guid? CatechismGradeId { get; set; }

    public bool? IsActive { get; set; }
}