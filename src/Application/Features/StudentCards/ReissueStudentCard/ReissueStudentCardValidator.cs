namespace Application.Features.StudentCards.ReissueStudentCard;

public static class ReissueStudentCardValidator
{
    public static List<string> Validate(
        ReissueStudentCardRequest request)
    {
        var errors = new List<string>();

        if (request.StudentCardId == Guid.Empty)
            errors.Add("StudentCardId is required.");

        return errors;
    }
}