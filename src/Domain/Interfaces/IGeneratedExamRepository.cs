using Domain.Entities;

namespace Domain.Interfaces;

public interface IGeneratedExamRepository
{
    Task AddAsync(GeneratedExam entity);

    Task<GeneratedExam?> GetByIdAsync(Guid id);

    Task<List<GeneratedExam>> GetListAsync();

    Task UpdateAsync(GeneratedExam entity);

    Task<bool> ExistsAsync(Guid id);
}