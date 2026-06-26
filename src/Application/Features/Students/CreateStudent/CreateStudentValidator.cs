namespace Application.Features.Students.CreateStudent;

public class CreateStudentValidator
{
    public static List<string> Validate(CreateStudentRequest request)
    {
        var errors = new List<string>();

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId is required.");

        if (request.CatechismClassId == Guid.Empty)
            errors.Add("CatechismClassId is required.");

        if (string.IsNullOrWhiteSpace(request.ChristianName))
            errors.Add("Christian name is required.");

        if (string.IsNullOrWhiteSpace(request.FullName))
            errors.Add("Full name is required.");

        if (request.DateOfBirth == default)
            errors.Add("Date of birth is required.");

        if (request.JoinDate == default)
            errors.Add("Join date is required.");

        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            try
            {
                _ = new System.Net.Mail.MailAddress(request.Email);
            }
            catch
            {
                errors.Add("Email is invalid.");
            }
        }

        return errors;
    }
}