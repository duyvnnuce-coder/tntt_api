using Domain.Interfaces;

namespace Application.Features.CatechismClasses.GetCatechismClassList;

public class GetCatechismClassListHandler
{
    private readonly ICatechismClassRepository _repository;

    public GetCatechismClassListHandler(
        ICatechismClassRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetCatechismClassListResponse>> Handle(
        GetCatechismClassListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetCatechismClassListResponse
        {
            Id = x.Id,
            ParishId = x.ParishId,
            AcademicYearId = x.AcademicYearId,
            CatechismGradeId = x.CatechismGradeId,
            Code = x.Code,
            Name = x.Name,
            DisplayOrder = x.DisplayOrder,
            MaxStudents = x.MaxStudents,
            IsActive = x.IsActive
        }).ToList();
    }
}