using Domain.Entities;

namespace Domain.Interfaces;

public interface ICatechismClassRepository
{
    Task<CatechismClass?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);
}