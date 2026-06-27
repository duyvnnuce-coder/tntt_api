using Domain.Entities;

namespace Domain.Interfaces;

public interface ITeacherRepository
{
    Task<Teacher?> GetByIdAsync(Guid id);

    Task<List<Teacher>> GetListAsync();

    Task AddAsync(
        Teacher teacher,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Teacher teacher,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        Teacher teacher,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}