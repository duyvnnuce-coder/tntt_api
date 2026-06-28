namespace Application.Features.ExamBlueprintDetails.UpdateExamBlueprintDetail;

public class UpdateExamBlueprintDetailRequest
{
    public Guid Id { get; set; }

    public Guid QuestionCategoryId { get; set; }

    public int EasyQuestions { get; set; }

    public int MediumQuestions { get; set; }

    public int HardQuestions { get; set; }
}