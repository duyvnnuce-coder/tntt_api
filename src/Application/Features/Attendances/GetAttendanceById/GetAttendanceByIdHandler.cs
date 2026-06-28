using Domain.Interfaces;

namespace Application.Features.Attendances.GetAttendanceById;

public class GetAttendanceByIdHandler
{
    private readonly IAttendanceRepository _repository;

    public GetAttendanceByIdHandler(
        IAttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetAttendanceByIdResult> Handle(
        GetAttendanceByIdRequest request)
    {
        var attendance = await _repository.GetByIdAsync(request.Id);

        if (attendance is null)
        {
            return new GetAttendanceByIdResult
            {
                Success = false,
                Message = "Không tìm thấy điểm danh."
            };
        }

        return new GetAttendanceByIdResult
        {
            Success = true,
            Message = "Thành công.",
            Data = new GetAttendanceByIdResponse
            {
                Id = attendance.Id,
                AttendanceSessionId = attendance.AttendanceSessionId,
                StudentId = attendance.StudentId,
                IsPresent = attendance.IsPresent,
                IsExcused = attendance.IsExcused,
                Note = attendance.Note
            }
        };
    }
}