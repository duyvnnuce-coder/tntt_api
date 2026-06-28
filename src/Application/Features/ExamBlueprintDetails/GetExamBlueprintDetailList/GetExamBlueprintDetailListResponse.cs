namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailList;

public class GetExamBlueprintDetailListResponse
{
    public Guid Id { get; set; }

    public string ExamBlueprintName { get; set; } = string.Empty;

    public string QuestionCategoryName { get; set; } = string.Empty;

    public int EasyQuestions { get; set; }

    public int MediumQuestions { get; set; }

    public int HardQuestions { get; set; }
}