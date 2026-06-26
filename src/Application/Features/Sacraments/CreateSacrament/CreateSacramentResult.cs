namespace Application.Features.Sacraments.CreateSacrament;

public class CreateSacramentResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateSacramentResponse? Data { get; set; }
}