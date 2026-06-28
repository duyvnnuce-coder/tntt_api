using Domain.Entities;

namespace Domain.Interfaces;

public interface IQuestionRepository
{
    Task AddAsync(Question question);

    Task<Question?> GetByIdAsync(Guid id);

    Task<List<Question>> GetListAsync();

    Task UpdateAsync(Question question);

    Task DeleteAsync(Question question);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsCodeAsync(string code);
}