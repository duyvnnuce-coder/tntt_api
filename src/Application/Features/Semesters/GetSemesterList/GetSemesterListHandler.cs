using Domain.Interfaces;

namespace Application.Features.Semesters.GetSemesterList;

public class GetSemesterListHandler
{
    private readonly ISemesterRepository _repository;

    public GetSemesterListHandler(
        ISemesterRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSemesterListResponse>> Handle()
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetSemesterListResponse
        {
            Id = x.Id,
            AcademicYearId = x.AcademicYearId,
            Code = x.Code,
            Name = x.Name,
            SemesterOrder = x.SemesterOrder,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            IsCurrent = x.IsCurrent
        }).ToList();
    }
}