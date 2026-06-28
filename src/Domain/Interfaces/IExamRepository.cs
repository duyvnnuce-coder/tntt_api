using Domain.Entities;

namespace Domain.Interfaces;

public interface IExamRepository
{
    Task AddAsync(Exam entity);

    Task<Exam?> GetByIdAsync(Guid id);

    Task<List<Exam>> GetListAsync();

    Task UpdateAsync(Exam entity);

    Task DeleteAsync(Exam entity);

    Task<bool> ExistsAsync(Guid id);
}