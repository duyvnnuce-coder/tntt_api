namespace Application.Features.Questions.GetQuestionById;

public static class GetQuestionByIdValidator
{
    public static List<string> Validate(
        GetQuestionByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}