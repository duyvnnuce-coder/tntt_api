using Domain.Common;

namespace Domain.Entities;

public class ExamBlueprintDetail : BaseEntity
{
    public Guid ExamBlueprintId { get; set; }

    public Guid QuestionCategoryId { get; set; }

    public int EasyQuestions { get; set; }

    public int MediumQuestions { get; set; }

    public int HardQuestions { get; set; }

    // Navigation
    public ExamBlueprint ExamBlueprint { get; set; } = null!;

    public QuestionCategory QuestionCategory { get; set; } = null!;
}