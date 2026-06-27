namespace Application.Features.ExamBlueprintDetails.CreateExamBlueprintDetail;

public static class CreateExamBlueprintDetailValidator
{
    public static List<string> Validate(
        CreateExamBlueprintDetailRequest request)
    {
        var errors = new List<string>();

        if (request.ExamBlueprintId == Guid.Empty)
            errors.Add("ExamBlueprintId is required.");

        if (request.QuestionCategoryId == Guid.Empty)
            errors.Add("QuestionCategoryId is required.");

        if (request.EasyQuestions < 0)
            errors.Add("EasyQuestions must be greater than or equal to 0.");

        if (request.MediumQuestions < 0)
            errors.Add("MediumQuestions must be greater than or equal to 0.");

        if (request.HardQuestions < 0)
            errors.Add("HardQuestions must be greater than or equal to 0.");

        return errors;
    }
}