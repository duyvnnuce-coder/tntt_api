namespace Application.Features.CatechismClasses.CreateCatechismClass;

public class CreateCatechismClassResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public CreateCatechismClassResponse? Data { get; set; }
}