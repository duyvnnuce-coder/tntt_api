namespace Application.Features.Exams.GetExamById;

public static class GetExamByIdValidator
{
    public static List<string> Validate(
        GetExamByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}