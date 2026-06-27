namespace Application.Features.StudentCards.GetStudentCardById;

public static class GetStudentCardByIdValidator
{
    public static List<string> Validate(GetStudentCardByIdRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}