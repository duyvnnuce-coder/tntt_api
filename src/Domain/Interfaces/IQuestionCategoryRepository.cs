using Domain.Entities;

namespace Domain.Interfaces;

public interface IQuestionCategoryRepository
{
    Task AddAsync(QuestionCategory category);

    Task<QuestionCategory?> GetByIdAsync(Guid id);

    Task<List<QuestionCategory>> GetListAsync();

    Task UpdateAsync(QuestionCategory category);

    Task DeleteAsync(QuestionCategory category);

    Task<bool> ExistsAsync(Guid id);



    Task<bool> ExistsNameAsync(Guid parishId, string name);
}