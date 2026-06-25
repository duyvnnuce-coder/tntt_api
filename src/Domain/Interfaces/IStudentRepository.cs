using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(Guid id);

    Task<Student?> GetByCodeAsync(string code);

    Task<bool> ExistsAsync(Guid id);

    Task AddAsync(
        Student student,
        StudentEnrollment enrollment,
        StudentCard studentCard);
}