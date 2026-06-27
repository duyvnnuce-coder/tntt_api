namespace Application.Features.StudentCards.UpdateStudentCardStatus;

public static class UpdateStudentCardStatusValidator
{
    public static List<string> Validate(UpdateStudentCardStatusRequest request)
    {
        var errors = new List<string>();

        if (request.Id == Guid.Empty)
            errors.Add("Id is required.");

        return errors;
    }
}