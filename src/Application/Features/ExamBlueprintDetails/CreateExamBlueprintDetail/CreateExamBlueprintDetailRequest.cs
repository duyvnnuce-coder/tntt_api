namespace Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;

public class CreateExamBlueprintDetailRequest
{
    public Guid ExamBlueprintId { get; set; }

    public Guid QuestionCategoryId { get; set; }

    public int EasyQuestions { get; set; }

    public int MediumQuestions { get; set; }

    public int HardQuestions { get; set; }
}