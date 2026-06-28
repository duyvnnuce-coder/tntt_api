using Domain.Entities;

namespace Domain.Interfaces;

public interface ICatechismClassRepository
{
    Task AddAsync(CatechismClass catechismClass);

    Task<List<CatechismClass>> GetListAsync();

    Task<CatechismClass?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task UpdateAsync(CatechismClass catechismClass);

    Task DeleteAsync(CatechismClass catechismClass);
}