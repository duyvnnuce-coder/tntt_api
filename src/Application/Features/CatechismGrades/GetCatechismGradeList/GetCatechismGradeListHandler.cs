using Domain.Interfaces;

namespace Application.Features.CatechismGrades.GetCatechismGradeList;

public class GetCatechismGradeListHandler
{
    private readonly ICatechismGradeRepository _repository;

    public GetCatechismGradeListHandler(
        ICatechismGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCatechismGradeListResponse>> Handle(
        GetCatechismGradeListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetCatechismGradeListResponse
        {
            Id = x.Id,
            ParishId = x.ParishId,
            Code = x.Code,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder,
            IsActive = x.IsActive
        }).ToList();
    }
}