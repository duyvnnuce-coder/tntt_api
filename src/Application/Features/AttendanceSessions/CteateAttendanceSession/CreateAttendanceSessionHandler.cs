using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Features.AttendanceSessions.CreateAttendanceSession;

public class CreateAttendanceSessionHandler
{
    private readonly IAttendanceSessionRepository _repository;
    private readonly IAssignmentRepository _assignmentRepository;

    public CreateAttendanceSessionHandler(
        IAttendanceSessionRepository repository,
        IAssignmentRepository assignmentRepository)
    {
        _repository = repository;
        _assignmentRepository = assignmentRepository;
    }

    public async Task<CreateAttendanceSessionResult> Handle(
        CreateAttendanceSessionRequest request)
    {
        var errors = CreateAttendanceSessionValidator.Validate(request);

        if (errors.Any())
        {
            return new CreateAttendanceSessionResult
            {
                Success = false,
                Message = string.Join(Environment.NewLine, errors)
            };
        }

        if (!await _assignmentRepository.ExistsAsync(request.AssignmentId))
        {
            return new CreateAttendanceSessionResult
            {
                Success = false,
                Message = "Phân công không tồn tại."
            };
        }

        var attendanceSession = new AttendanceSession
        {
            AssignmentId = request.AssignmentId,
            AttendanceDate = request.AttendanceDate,
            LessonNumber = request.LessonNumber,
            Topic = request.Topic,
            IsLocked = request.IsLocked
        };

        await _repository.AddAsync(attendanceSession);

        return new CreateAttendanceSessionResult
        {
            Success = true,
            Message = "Tạo buổi điểm danh thành công.",
            Data = new CreateAttendanceSessionResponse
            {
                Id = attendanceSession.Id,
                LessonNumber = attendanceSession.LessonNumber,
                AttendanceDate = attendanceSession.AttendanceDate
            }
        };
    }
}