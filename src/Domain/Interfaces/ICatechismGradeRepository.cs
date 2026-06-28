using Domain.Entities;

namespace Domain.Interfaces;

public interface ICatechismGradeRepository
{
    Task AddAsync(CatechismGrade grade);

    Task<List<CatechismGrade>> GetListAsync();

    Task<CatechismGrade?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task UpdateAsync(CatechismGrade grade);

    Task DeleteAsync(CatechismGrade grade);
}