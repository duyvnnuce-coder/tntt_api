namespace Application.Features.StudentCards.GetStudentCardByStudentId;

public static class GetStudentCardByStudentIdValidator
{
    public static List<string> Validate(
        GetStudentCardByStudentIdRequest request)
    {
        var errors = new List<string>();

        if (request.StudentId == Guid.Empty)
            errors.Add("StudentId is required.");

        return errors;
    }
}