using Domain.Entities;

namespace Domain.Interfaces;

public interface IAttendanceSessionRepository
{
    Task AddAsync(AttendanceSession attendanceSession);

    Task<AttendanceSession?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsDuplicateAsync(
        Guid assignmentId,
        DateOnly attendanceDate,
        int lessonNumber);
}