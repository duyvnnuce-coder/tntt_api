using Domain.Entities;

namespace Domain.Interfaces;

public interface ITeacherRepository
{
    Task AddAsync(
        Teacher teacher,
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}