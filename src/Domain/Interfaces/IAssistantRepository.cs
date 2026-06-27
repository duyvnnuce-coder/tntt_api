using Domain.Entities;

namespace Domain.Interfaces;

public interface IAssistantRepository
{
    Task AddAsync(
        Assistant assistant,
        CancellationToken cancellationToken = default);

    Task<Assistant?> GetByIdAsync(Guid id);

    Task<List<Assistant>> GetListAsync();

    Task UpdateAsync(Assistant assistant);

    Task DeleteAsync(Assistant assistant);

    Task<bool> ExistsAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}