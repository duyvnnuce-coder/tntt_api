namespace Application.Features.Assistants.CreateAssistant;

public class CreateAssistantValidator
{
    public static List<string> Validate(CreateAssistantRequest request)
    {
        var errors = new List<string>();

        if (request.ParishId == Guid.Empty)
            errors.Add("ParishId is required.");

        if (string.IsNullOrWhiteSpace(request.FullName))
            errors.Add("FullName is required.");

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