using Domain.Entities;

namespace Domain.Interfaces;

public interface IParishRepository
{
    Task<Parish?> GetByIdAsync(Guid id);



    Task AddAsync(Parish parish);

    Task<bool> ExistsAsync(Guid id);

    Task<int> SaveChangesAsync();
}