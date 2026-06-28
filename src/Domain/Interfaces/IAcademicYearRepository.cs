using Domain.Entities;

namespace Domain.Interfaces;

public interface IAcademicYearRepository
{
    Task AddAsync(
        AcademicYear academicYear,
        CancellationToken cancellationToken = default);

    Task<AcademicYear?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<List<AcademicYear>> GetListAsync(
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        AcademicYear academicYear,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        AcademicYear academicYear,
        CancellationToken cancellationToken = default);
}