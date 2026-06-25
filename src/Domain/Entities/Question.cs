using Domain.Common;

namespace Domain.Entities;

public class Question : BaseEntity
{
    public Guid QuestionCategoryId { get; set; }

    public Guid CatechismGradeId { get; set; }

    public string Content { get; set; } = string.Empty;

    public string AnswerA { get; set; } = string.Empty;

    public string AnswerB { get; set; } = string.Empty;

    public string? AnswerC { get; set; }

    public string? AnswerD { get; set; }

    public string CorrectAnswer { get; set; } = string.Empty;

    public int DifficultyLevel { get; set; }

    public bool IsActive { get; set; }

    // Navigation
    public QuestionCategory QuestionCategory { get; set; } = null!;

    public CatechismGrade CatechismGrade { get; set; } = null!;
}