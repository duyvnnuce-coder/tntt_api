using Domain.Entities;

namespace Domain.Interfaces;

public interface IQuestionRepository
{
    Task AddAsync(Question entity);

    Task<Question?> GetByIdAsync(Guid id);

    Task<List<Question>> GetListAsync();

    Task UpdateAsync(Question entity);

    Task<bool> ExistsAsync(Guid id);
}