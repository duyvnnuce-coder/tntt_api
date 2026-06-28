using Domain.Interfaces;

namespace Application.Features.AttendanceSessions.DeleteAttendanceSession;

public class DeleteAttendanceSessionHandler
{
    private readonly IAttendanceSessionRepository _repository;

    public DeleteAttendanceSessionHandler(
        IAttendanceSessionRepository repository)
    {
        _repository = repository;
    }

    public async Task<DeleteAttendanceSessionResult> Handle(
        DeleteAttendanceSessionRequest request)
    {
        var attendanceSession = await _repository.GetByIdAsync(request.Id);

        if (attendanceSession is null)
        {
            return new DeleteAttendanceSessionResult
            {
                Success = false,
                Message = "Không tìm thấy buổi điểm danh."
            };
        }

        await _repository.DeleteAsync(attendanceSession);

        return new DeleteAttendanceSessionResult
        {
            Success = true,
            Message = "Xóa buổi điểm danh thành công."
        };
    }
}