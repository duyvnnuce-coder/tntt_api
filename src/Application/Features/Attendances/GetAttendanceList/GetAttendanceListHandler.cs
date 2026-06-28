using Domain.Interfaces;

namespace Application.Features.Attendances.GetAttendanceList;

public class GetAttendanceListHandler
{
    private readonly IAttendanceRepository _repository;

    public GetAttendanceListHandler(
        IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAttendanceListResponse>> Handle(
        GetAttendanceListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetAttendanceListResponse
        {
            Id = x.Id,
            AttendanceSessionId = x.AttendanceSessionId,
            StudentId = x.StudentId,
            IsPresent = x.IsPresent,
            IsExcused = x.IsExcused,
            Note = x.Note
        }).ToList();
    }
}