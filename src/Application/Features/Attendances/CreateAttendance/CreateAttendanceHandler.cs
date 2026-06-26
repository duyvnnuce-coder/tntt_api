using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.Attendances.CreateAttendance;

public class CreateAttendanceHandler
{
    private readonly IAttendanceRepository _attendanceRepository;
    private readonly IAttendanceSessionRepository _sessionRepository;
    private readonly IStudentRepository _studentRepository;

    public CreateAttendanceHandler(
        IAttendanceRepository attendanceRepository,
        IAttendanceSessionRepository sessionRepository,
        IStudentRepository studentRepository)
    {
        _attendanceRepository = attendanceRepository;
        _sessionRepository = sessionRepository;
        _studentRepository = studentRepository;
    }

    public async Task<CreateAttendanceResult> Handle(CreateAttendanceRequest request)
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

        if (!await _sessionRepository.ExistsAsync(request.AttendanceSessionId))
        {
            return new CreateAttendanceResult
            {
                Success = false,
                Message = "Buổi học không tồn tại."
            };
        }

        if (!await _studentRepository.ExistsAsync(request.StudentId))
        {
            return new CreateAttendanceResult
            {
                Success = false,
                Message = "Học sinh không tồn tại."
            };
        }

        if (await _attendanceRepository.ExistsAsync(
                request.AttendanceSessionId,
                request.StudentId))
        {
            return new CreateAttendanceResult
            {
                Success = false,
                Message = "Học sinh đã được điểm danh."
            };
        }

        var attendance = new Domain.Entities.Attendance
        {
            AttendanceSessionId = request.AttendanceSessionId,
            StudentId = request.StudentId,
            IsPresent = request.IsPresent,
            IsExcused = request.IsExcused,
            Note = request.Note
        };

        await _attendanceRepository.AddAsync(attendance);

        return new CreateAttendanceResult
        {
            Success = true,
            Message = "Điểm danh thành công.",
            Data = new CreateAttendanceResponse
            {
                Id = attendance.Id,
                AttendanceSessionId = attendance.AttendanceSessionId,
                StudentId = attendance.StudentId,
                IsPresent = attendance.IsPresent,
                IsExcused = attendance.IsExcused
            }
        };
    }
}