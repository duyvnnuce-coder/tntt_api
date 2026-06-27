using Domain.Entities;

namespace Domain.Interfaces;

public interface IParishRepository
{
    Task AddAsync(
        Parish parish,
        CancellationToken cancellationToken = default);

    Task<Parish?> GetByIdAsync(Guid id);

    Task<List<Parish>> GetListAsync();

    Task UpdateAsync(Parish parish);

    Task DeleteAsync(Parish parish);

    Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}