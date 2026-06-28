using Domain.Entities;

namespace Domain.Interfaces;

public interface IExamBlueprintDetailRepository
{
    Task AddAsync(ExamBlueprintDetail entity);

    Task<ExamBlueprintDetail?> GetByIdAsync(Guid id);

    Task<List<ExamBlueprintDetail>> GetListAsync();

    Task UpdateAsync(ExamBlueprintDetail entity);

    Task DeleteAsync(ExamBlueprintDetail entity);

    Task<bool> ExistsAsync(Guid id);
}