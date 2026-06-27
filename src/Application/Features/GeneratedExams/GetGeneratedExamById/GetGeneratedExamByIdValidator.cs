namespace Application.Features.GeneratedExams.GetGeneratedExamById;

public static class GetGeneratedExamByIdValidator
{
    public static List<string> Validate(
        GetGeneratedExamByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}