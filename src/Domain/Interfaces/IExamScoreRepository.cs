using Domain.Entities;

namespace Domain.Interfaces;

public interface IExamScoreRepository
{
    Task AddAsync(ExamScore entity);

    Task<ExamScore?> GetByIdAsync(Guid id);

    Task<List<ExamScore>> GetListAsync();

    Task UpdateAsync(ExamScore entity);

    Task DeleteAsync(ExamScore entity);

    Task<bool> ExistsAsync(Guid id);
}