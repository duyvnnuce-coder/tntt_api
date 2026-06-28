using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentEnrollmentRepository
{
    Task AddAsync(StudentEnrollment enrollment);

    Task<StudentEnrollment?> GetByIdAsync(Guid id);

    Task<List<StudentEnrollment>> GetListAsync();

    Task<StudentEnrollment?> GetCurrentByStudentIdAsync(Guid studentId);

    Task<bool> ExistsCurrentAsync(Guid studentId);

    Task<bool> ExistsAsync(Guid id);

    Task UpdateAsync(StudentEnrollment enrollment);

    Task DeleteAsync(StudentEnrollment enrollment);
}