namespace Application.Features.Parishes.GetParishById;

public class GetParishByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetParishByIdResponse? Data { get; set; }
}