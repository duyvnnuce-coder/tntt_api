using Domain.Entities;

namespace Domain.Interfaces;

public interface IAttendanceRepository
{
    Task AddAsync(Attendance attendance);

    Task<List<Attendance>> GetListAsync();

    Task<Attendance?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task UpdateAsync(Attendance attendance);

    Task DeleteAsync(Attendance attendance);
}