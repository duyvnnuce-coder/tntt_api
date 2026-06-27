namespace Application.Features.ExamBlueprints.GetExamBlueprintById;

public static class GetExamBlueprintByIdValidator
{
    public static List<string> Validate(
        GetExamBlueprintByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}