namespace Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;

public class CreateExamBlueprintDetailValidator
{
    public List<string> Validate(CreateExamBlueprintDetailRequest request)
    {
        var errors = new List<string>();

        if (request.ExamBlueprintId == Guid.Empty)
            errors.Add("ExamBlueprintId không hợp lệ.");

        if (request.QuestionCategoryId == Guid.Empty)
            errors.Add("QuestionCategoryId không hợp lệ.");

        if (request.EasyQuestions < 0)
            errors.Add("EasyQuestions phải >= 0.");

        if (request.MediumQuestions < 0)
            errors.Add("MediumQuestions phải >= 0.");

        if (request.HardQuestions < 0)
            errors.Add("HardQuestions phải >= 0.");

        return errors;
    }
}