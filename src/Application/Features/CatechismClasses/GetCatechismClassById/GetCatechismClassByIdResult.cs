namespace Application.Features.CatechismClasses.GetCatechismClassById;

public class GetCatechismClassByIdResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public GetCatechismClassByIdResponse? Data { get; set; }
}