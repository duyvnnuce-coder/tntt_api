using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentCardRepository
{
    Task AddAsync(StudentCard studentCard);

    Task<StudentCard?> GetByIdAsync(Guid id);

    Task<StudentCard?> GetByStudentIdAsync(Guid studentId);

    Task<List<StudentCard>> GetListAsync();

    Task UpdateAsync(StudentCard studentCard);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsByStudentIdAsync(Guid studentId);
}