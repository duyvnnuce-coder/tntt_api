namespace Application.Features.Assistants.CreateAssistant;

public class CreateAssistantResponse
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;
}