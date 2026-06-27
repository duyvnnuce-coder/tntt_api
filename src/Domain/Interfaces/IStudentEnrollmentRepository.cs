using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentEnrollmentRepository
{
    Task AddAsync(StudentEnrollment enrollment);

    Task<StudentEnrollment?> GetByIdAsync(Guid id);

    Task<List<StudentEnrollment>> GetListAsync();

    Task<StudentEnrollment?> GetCurrentByStudentIdAsync(Guid studentId);

    Task UpdateAsync(StudentEnrollment enrollment);

    Task<bool> ExistsAsync(Guid id);
}