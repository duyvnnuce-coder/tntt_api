using Domain.Entities;

namespace Domain.Interfaces;

public interface IAttendanceRepository
{
    Task AddAsync(Attendance attendance);

    Task<Attendance?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsAsync(
        Guid attendanceSessionId,
        Guid studentId);
}