namespace Application.Features.Assistants.CreateAssistant;

public class CreateAssistantResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateAssistantResponse? Data { get; set; }
}