using Domain.Interfaces;

namespace Application.Features.AttendanceSessions.GetAttendanceSessionList;

public class GetAttendanceSessionListHandler
{
    private readonly IAttendanceSessionRepository _repository;

    public GetAttendanceSessionListHandler(
        IAttendanceSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAttendanceSessionListResponse>> Handle(
        GetAttendanceSessionListRequest request)
    {
        var data = await _repository.GetListAsync();

        return data.Select(x => new GetAttendanceSessionListResponse
        {
            Id = x.Id,
            AssignmentId = x.AssignmentId,
            AttendanceDate = x.AttendanceDate,
            LessonNumber = x.LessonNumber,
            Topic = x.Topic,
            IsLocked = x.IsLocked
        }).ToList();
    }
}