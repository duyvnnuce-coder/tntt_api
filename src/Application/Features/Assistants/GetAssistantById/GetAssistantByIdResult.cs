namespace Application.Features.Assistants.GetAssistantById;

public class GetAssistantByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetAssistantByIdResponse? Data { get; set; }
}