using Domain.Entities;

namespace Domain.Interfaces;

public interface ICatechismGradeRepository
{
    Task AddAsync(CatechismGrade grade);

    Task<CatechismGrade?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);
}