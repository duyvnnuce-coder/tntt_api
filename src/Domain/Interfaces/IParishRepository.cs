using Domain.Entities;

namespace Domain.Interfaces;

public interface IParishRepository
{
    Task AddAsync(
        Parish parish,
        CancellationToken cancellationToken = default);

    Task<Parish?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<List<Parish>> GetListAsync(
        CancellationToken cancellationToken = default);

    Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task UpdateAsync(
        Parish parish,
        CancellationToken cancellationToken = default);

    Task DeleteAsync(
        Parish parish,
        CancellationToken cancellationToken = default);
}