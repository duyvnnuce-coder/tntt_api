namespace Application.Features.Sacraments.GetSacramentById;

public class GetSacramentByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetSacramentByIdResponse? Data { get; set; }
}