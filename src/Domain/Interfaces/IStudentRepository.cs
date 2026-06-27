using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(Guid id);

    Task<Student?> GetByCodeAsync(string code);

    Task<bool> ExistsAsync(Guid id);

    Task<List<Student>> GetListAsync();

    Task UpdateAsync(Student student);

    Task DeleteAsync(Student student);

    Task AddAsync(
        Student student,
        StudentEnrollment enrollment,
        StudentCard studentCard);
}