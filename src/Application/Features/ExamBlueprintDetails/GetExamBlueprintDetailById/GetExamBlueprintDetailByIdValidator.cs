namespace Application.Features.ExamBlueprintDetails.GetExamBlueprintDetailById;

public static class GetExamBlueprintDetailByIdValidator
{
    public static List<string> Validate(
        GetExamBlueprintDetailByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}