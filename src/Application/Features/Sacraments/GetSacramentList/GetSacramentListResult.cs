namespace Application.Features.Sacraments.GetSacramentList;

public class GetSacramentListResult
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public List<GetSacramentListResponse> Data { get; set; } = [];
}