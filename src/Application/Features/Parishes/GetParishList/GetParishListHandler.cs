using Domain.Interfaces;

namespace Application.Features.Parishes.GetParishList;

public class GetParishListHandler
{
    private readonly IParishRepository _repository;

    public GetParishListHandler(
        IParishRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetParishListResponse>> Handle()
    {
        var data = await _repository.GetListAsync();

        return data
            .Select(x => new GetParishListResponse
            {
                Id = x.Id,
                Code = x.Code,
                Name = x.Name,

                IsActive = x.IsActive
            })
            .ToList();
    }
}