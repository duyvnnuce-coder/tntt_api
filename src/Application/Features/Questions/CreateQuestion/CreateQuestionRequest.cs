namespace Application.Features.Questions.CreateQuestion;

public class CreateQuestionRequest
{
    public Guid ParishId { get; set; }

    public Guid QuestionCategoryId { get; set; }

    public string Content { get; set; } = string.Empty;

    public string AnswerA { get; set; } = string.Empty;

    public string AnswerB { get; set; } = string.Empty;

    public string AnswerC { get; set; } = string.Empty;

    public string AnswerD { get; set; } = string.Empty;

    public string CorrectAnswer { get; set; } = string.Empty;

    public int DifficultyLevel { get; set; }

    public bool IsActive { get; set; } = true;
}