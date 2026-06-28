using Domain.Interfaces;

namespace Application.Features.AttendanceSessions.UpdateAttendanceSession;

public class UpdateAttendanceSessionHandler
{
    private readonly IAttendanceSessionRepository _repository;

    public UpdateAttendanceSessionHandler(
        IAttendanceSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateAttendanceSessionResult> Handle(
        UpdateAttendanceSessionRequest request)
    {
        var attendanceSession = await _repository.GetByIdAsync(request.Id);

        if (attendanceSession is null)
        {
            return new UpdateAttendanceSessionResult
            {
                Success = false,
                Message = "Không tìm thấy buổi điểm danh."
            };
        }

        attendanceSession.AssignmentId = request.AssignmentId;
        attendanceSession.AttendanceDate = request.AttendanceDate;
        attendanceSession.LessonNumber = request.LessonNumber;
        attendanceSession.Topic = request.Topic;
        attendanceSession.IsLocked = request.IsLocked;

        await _repository.UpdateAsync(attendanceSession);

        return new UpdateAttendanceSessionResult
        {
            Success = true,
            Message = "Cập nhật buổi điểm danh thành công."
        };
    }
}