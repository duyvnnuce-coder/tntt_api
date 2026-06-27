namespace Application.Features.ExamBlueprintDetails.UpdateExamBlueprintDetail;

public class UpdateExamBlueprintDetailResponse
{
    public Guid Id { get; set; }

    public Guid ExamBlueprintId { get; set; }

    public string ExamBlueprintCode { get; set; } = string.Empty;

    public string ExamBlueprintName { get; set; } = string.Empty;

    public Guid QuestionCategoryId { get; set; }

    public string QuestionCategoryCode { get; set; } = string.Empty;

    public string QuestionCategoryName { get; set; } = string.Empty;

    public int EasyQuestions { get; set; }

    public int MediumQuestions { get; set; }

    public int HardQuestions { get; set; }
}