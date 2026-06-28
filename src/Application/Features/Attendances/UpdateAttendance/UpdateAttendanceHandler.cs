using Domain.Interfaces;

namespace Application.Features.Attendances.UpdateAttendance;

public class UpdateAttendanceHandler
{
    private readonly IAttendanceRepository _repository;

    public UpdateAttendanceHandler(
        IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<UpdateAttendanceResult> Handle(
        UpdateAttendanceRequest request)
    {
        var attendance = await _repository.GetByIdAsync(request.Id);

        if (attendance is null)
        {
            return new UpdateAttendanceResult
            {
                Success = false,
                Message = "Không tìm thấy điểm danh."
            };
        }

        attendance.AttendanceSessionId = request.AttendanceSessionId;
        attendance.StudentId = request.StudentId;
        attendance.IsPresent = request.IsPresent;
        attendance.IsExcused = request.IsExcused;
        attendance.Note = request.Note;

        await _repository.UpdateAsync(attendance);

        return new UpdateAttendanceResult
        {
            Success = true,
            Message = "Cập nhật điểm danh thành công."
        };
    }
}