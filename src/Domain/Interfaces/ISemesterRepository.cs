using Domain.Entities;

namespace Domain.Interfaces;

public interface ISemesterRepository
{
    Task AddAsync(Semester semester);

    Task<List<Semester>> GetListAsync();

    Task<Semester?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsCurrentAsync(Guid academicYearId);

    Task UpdateAsync(Semester semester);

    Task DeleteAsync(Semester semester);
}