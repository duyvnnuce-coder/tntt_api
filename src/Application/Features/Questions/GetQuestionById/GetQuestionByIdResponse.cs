namespace Application.Features.Questions.GetQuestionById;

public class GetQuestionByIdResponse
{
    public Guid Id { get; set; }

    public Guid QuestionCategoryId { get; set; }

    public string QuestionCategoryCode { get; set; } = string.Empty;

    public string QuestionCategoryName { get; set; } = string.Empty;

    public Guid CatechismGradeId { get; set; }

    public string CatechismGradeCode { get; set; } = string.Empty;

    public string CatechismGradeName { get; set; } = string.Empty;

    public string Code { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string AnswerA { get; set; } = string.Empty;

    public string AnswerB { get; set; } = string.Empty;

    public string? AnswerC { get; set; }

    public string? AnswerD { get; set; }

    public string CorrectAnswer { get; set; } = string.Empty;

    public int DifficultyLevel { get; set; }

    public bool IsActive { get; set; }
}