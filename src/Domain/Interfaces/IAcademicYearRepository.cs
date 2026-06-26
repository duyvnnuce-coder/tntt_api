using Domain.Entities;

namespace Domain.Interfaces;

public interface IAcademicYearRepository
{
    Task AddAsync(AcademicYear academicYear);

    Task<AcademicYear?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsCurrentAsync(Guid parishId);
}