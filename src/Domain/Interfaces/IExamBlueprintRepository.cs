using Domain.Entities;

namespace Domain.Interfaces;

public interface IExamBlueprintRepository
{
    Task AddAsync(ExamBlueprint entity);

    Task<ExamBlueprint?> GetByIdAsync(Guid id);

    Task<List<ExamBlueprint>> GetListAsync();

    Task UpdateAsync(ExamBlueprint entity);

    Task<bool> ExistsAsync(Guid id);
}