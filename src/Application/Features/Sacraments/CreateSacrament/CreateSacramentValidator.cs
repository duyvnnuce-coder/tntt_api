namespace Application.Features.Sacraments.CreateSacrament;

public static class CreateSacramentValidator
{
    public static List<string> Validate(CreateSacramentRequest request)
    {
        var errors = new List<string>();

        if (request.StudentId == Guid.Empty)
            errors.Add("StudentId is required.");

        return errors;
    }
}