using Domain.Entities;

namespace Domain.Interfaces;

public interface ISemesterRepository
{
    Task AddAsync(Semester semester);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsCurrentAsync(Guid academicYearId);
}