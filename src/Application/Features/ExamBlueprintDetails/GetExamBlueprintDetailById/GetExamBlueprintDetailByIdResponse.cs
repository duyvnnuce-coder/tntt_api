namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailById;

public class GetExamBlueprintDetailByIdResponse
{
    public Guid Id { get; set; }

    public Guid ExamBlueprintId { get; set; }

    public string ExamBlueprintName { get; set; } = string.Empty;

    public Guid QuestionCategoryId { get; set; }

    public string QuestionCategoryName { get; set; } = string.Empty;

    public int EasyQuestions { get; set; }

    public int MediumQuestions { get; set; }

    public int HardQuestions { get; set; }
}