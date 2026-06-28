using Domain.Interfaces;

namespace Application.Features.AttendanceSessions.GetAttendanceSessionById;

public class GetAttendanceSessionByIdHandler
{
    private readonly IAttendanceSessionRepository _repository;

    public GetAttendanceSessionByIdHandler(
        IAttendanceSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAttendanceSessionByIdResult> Handle(
        GetAttendanceSessionByIdRequest request)
    {
        var attendanceSession = await _repository.GetByIdAsync(request.Id);

        if (attendanceSession is null)
        {
            return new GetAttendanceSessionByIdResult
            {
                Success = false,
                Message = "Không tìm thấy buổi điểm danh."
            };
        }

        return new GetAttendanceSessionByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetAttendanceSessionByIdResponse
            {
                Id = attendanceSession.Id,
                AssignmentId = attendanceSession.AssignmentId,
                AttendanceDate = attendanceSession.AttendanceDate,
                LessonNumber = attendanceSession.LessonNumber,
                Topic = attendanceSession.Topic,
                IsLocked = attendanceSession.IsLocked
            }
        };
    }
}