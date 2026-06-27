namespace Application.Features.Sacraments.GetSacramentList;

public class GetSacramentListRequest
{
    public Guid? StudentId { get; set; }

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;
}