using Domain.Entities;

namespace Domain.Interfaces;

public interface IAttendanceSessionRepository
{
    Task AddAsync(AttendanceSession attendanceSession);

    Task<List<AttendanceSession>> GetListAsync();

    Task<AttendanceSession?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task UpdateAsync(AttendanceSession attendanceSession);

    Task DeleteAsync(AttendanceSession attendanceSession);
}