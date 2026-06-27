namespace Application.Features.Assistants.GetAssistantList;

public class GetAssistantListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetAssistantListResponse> Data { get; set; } = [];
}