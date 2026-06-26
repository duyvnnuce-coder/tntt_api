using Domain.Entities;

namespace Domain.Interfaces;

public interface IAssignmentRepository
{
    Task AddAsync(Assignment assignment);

    Task<Assignment?> GetByIdAsync(Guid id);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsDuplicateAsync(
        Guid semesterId,
        Guid classId,
        Guid teacherId);
}