using Domain.Entities;

namespace Domain.Interfaces;

public interface IQuestionCategoryRepository
{
    Task AddAsync(QuestionCategory entity);

    Task<QuestionCategory?> GetByIdAsync(Guid id);

    Task<List<QuestionCategory>> GetListAsync();

    Task UpdateAsync(QuestionCategory entity);

    Task<bool> ExistsAsync(Guid id);
}