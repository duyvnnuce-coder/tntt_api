using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Attendances.CreateAttendance;

public class CreateAttendanceHandler
{
    private readonly IAttendanceRepository _repository;
    private readonly IAttendanceSessionRepository _attendanceSessionRepository;
    private readonly IStudentRepository _studentRepository;

    public CreateAttendanceHandler(
        IAttendanceRepository repository,
        IAttendanceSessionRepository attendanceSessionRepository,
        IStudentRepository studentRepository)
    {
        _repository = repository;
        _attendanceSessionRepository = attendanceSessionRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateAttendanceResult> Handle(
        CreateAttendanceRequest request)
    {
        var errors = CreateAttendanceValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateAttendanceResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _attendanceSessionRepository.ExistsAsync(request.AttendanceSessionId))
        {
            return new CreateAttendanceResult
            {
                Success = false,
                Message = "Buổi điểm danh không tồn tại."
            };
        }

        if (!await _studentRepository.ExistsAsync(request.StudentId))
        {
            return new CreateAttendanceResult
            {
                Success = false,
                Message = "Thiếu nhi không tồn tại."
            };
        }

        var attendance = new Attendance
        {
            AttendanceSessionId = request.AttendanceSessionId,
            StudentId = request.StudentId,
            IsPresent = request.IsPresent,
            IsExcused = request.IsExcused,
            Note = request.Note
        };

        await _repository.AddAsync(attendance);

        return new CreateAttendanceResult
        {
            Success = true,
            Message = "Điểm danh thành công.",
            Data = new CreateAttendanceResponse
            {
                Id = attendance.Id,
                StudentId = attendance.StudentId,
                AttendanceSessionId = attendance.AttendanceSessionId
            }
        };
    }
}