using Domain.Interfaces;

namespace Application.Features.AcademicYears.GetAcademicYearList;

public class GetAcademicYearListHandler
{
    private readonly IAcademicYearRepository _repository;

    public GetAcademicYearListHandler(
        IAcademicYearRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAcademicYearListResponse>> Handle()
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetAcademicYearListResponse
        {
            Id = x.Id,
            Code = x.Code,
            Name = x.Name,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            IsCurrent = x.IsCurrent
        }).ToList();
    }
}