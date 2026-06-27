namespace Application.Features.StudentCards.CreateStudentCard;

public static class CreateStudentCardValidator
{
    public static List<string> Validate(CreateStudentCardRequest request)
    {
        var errors = new List<string>();

        if (request.StudentId == Guid.Empty)
            errors.Add("StudentId is required.");

        if (string.IsNullOrWhiteSpace(request.CardNumber))
            errors.Add("CardNumber is required.");

        if (request.CardNumber.Length > 50)
            errors.Add("CardNumber tối đa 50 ký tự.");

        return errors;
    }
}