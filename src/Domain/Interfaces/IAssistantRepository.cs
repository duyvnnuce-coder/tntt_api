using Domain.Entities;

namespace Domain.Interfaces;

public interface IAssistantRepository
{
    Task AddAsync(Assistant assistant);

    Task<bool> ExistsAsync(Guid id);
}