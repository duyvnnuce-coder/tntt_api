using Domain.Entities;

namespace Domain.Interfaces;

public interface IStudentEnrollmentRepository
{
    Task AddAsync(StudentEnrollment enrollment);
}